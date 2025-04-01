﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Net;
using System.Net.Mail;

namespace _4RTools.Model
{

    public class ClientDTO
    {
        public int Index { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string HPAddress { get; set; }
        public string NameAddress { get; set; }

        public string MapAddress { get; set; }

        public int HPAddressPointer { get; set; }
        public int NameAddressPointer { get; set; }
        public int MapAddressPointer { get; set; }

        public ClientDTO() { }

        public ClientDTO(string name, string description, string hpAddress, string nameAddress, string mapAddress)
        {
            this.Name= name;
            this.Description = description;
            this.HPAddress = hpAddress;
            this.NameAddress = nameAddress;
            this.MapAddress = mapAddress;

            this.HPAddressPointer = Convert.ToInt32(hpAddress, 16);
            this.NameAddressPointer = Convert.ToInt32(nameAddress, 16);
            this.MapAddressPointer = Convert.ToInt32(mapAddress, 16);

        }

    }

    public sealed class ClientListSingleton
    {
        private static List<Client> Clients = new List<Client>();
        
        public static void AddClient(Client c)
        {
            Clients.Add(c);
        }

        public static void RemoveClient(Client c)
        {
            Clients.Remove(c);
        }

        public static List<Client> GetAll()
        {
            return Clients;
        }

        public static bool ExistsByProcessName(string processName)
        {
            return Clients.Exists(client => client.ProcessName == processName);
        }
    }

    public sealed class ClientSingleton
    {
        private static Client client;
        private ClientSingleton(Client client)
        {
            ClientSingleton.client = client;
        }

        public static ClientSingleton Instance(Client client)
        {
            return new ClientSingleton(client);
        }

        public static Client GetClient()
        {
            return client;
        }
    }

    public class Client
    {
        public Process Process { get; }

        public string ProcessName { get; private set; }
        private Utils.ProcessMemoryReader PMR { get; set; }
        public int CurrentNameAddress { get; set; }
        public int CurrentHPBaseAddress { get; set; }
        public int CurrentMapAddress { get; set; }
        private int StatusBufferAddress { get; set; }
        private int _num = 0;

        public Client(string processName, int currentHPBaseAddress, int currentNameAddress, int currentMapAddress)
        {
            this.CurrentNameAddress = currentNameAddress;
            this.CurrentHPBaseAddress = currentHPBaseAddress;
            this.CurrentMapAddress = currentMapAddress;
            this.ProcessName = processName;
            this.StatusBufferAddress = currentHPBaseAddress + 0x474;
        }

        public Client(ClientDTO dto)
        {
            this.ProcessName = dto.Name;
            this.CurrentHPBaseAddress = Convert.ToInt32(dto.HPAddress, 16);
            this.CurrentNameAddress = Convert.ToInt32(dto.NameAddress, 16);
            this.CurrentMapAddress = Convert.ToInt32(dto.MapAddress, 16);
            this.StatusBufferAddress = this.CurrentHPBaseAddress + 0x474;
        }

        public Client(string processName)
        {
            PMR = new Utils.ProcessMemoryReader();
            string rawProcessName = processName.Split(new string[] { ".exe - " }, StringSplitOptions.None)[0];
            int choosenPID = int.Parse(processName.Split(new string[] { ".exe - " }, StringSplitOptions.None)[1]);

            foreach (Process process in Process.GetProcessesByName(rawProcessName))
            {
                if (choosenPID == process.Id)
                {
                    this.Process = process;
                    PMR.ReadProcess = process;
                    PMR.OpenProcess();

                    try
                    {
                        Client c = GetClientByProcess(rawProcessName) ?? throw new Exception();
                        this.CurrentHPBaseAddress = c.CurrentHPBaseAddress;
                        this.CurrentNameAddress = c.CurrentNameAddress;
                        this.CurrentMapAddress = c.CurrentMapAddress;
                        this.StatusBufferAddress = c.StatusBufferAddress;
                    }
                    catch
                    {
                        MessageBox.Show("This client is not supported. Only Spammers and macro will works.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.CurrentHPBaseAddress = 0;
                        this.CurrentNameAddress = 0;
                        this.CurrentMapAddress = 0;
                        this.StatusBufferAddress = 0;
                    }
                   
                    //Do not block spammer for non supported Versions
                       
                }
            }
        }

        private string ReadMemoryAsString(int address)
        {
            byte[] bytes = PMR.ReadProcessMemory((IntPtr)address, 40u, out _num);
            List<byte> buffer = new List<byte>(); //Need a list with dynamic size 
            for (int i =0;i < bytes.Length;i++)
            {
                if (bytes[i] == 0) break; //Check Nullability based ON ASCII Table

                buffer.Add(bytes[i]); //Add only bytes needed
            }

           return Encoding.Default.GetString(buffer.ToArray());

        }

        private uint ReadMemory(int address)
        {
            return BitConverter.ToUInt32(PMR.ReadProcessMemory((IntPtr)address, 4u, out _num), 0);
        }
        public void WriteMemory(int address, uint intToWrite)
        {
            PMR.WriteProcessMemory((IntPtr)address, BitConverter.GetBytes(intToWrite), out _num);
        }

        public void WriteMemory(int address, byte[] bytesToWrite)
        {
            PMR.WriteProcessMemory((IntPtr)address, bytesToWrite, out _num);
        }

        public bool IsHpBelow(int percent)
        {
            return ReadCurrentHp() * 100 < percent * ReadMaxHp();
        }

        public bool IsSpBelow(int percent)
        {
            return ReadCurrentSp() * 100 < percent * ReadMaxSp();
        }

        public uint ReadCurrentHp()
        {
            return ReadMemory(this.CurrentHPBaseAddress);
        }

        public uint ReadCurrentSp()
        {
            return ReadMemory(this.CurrentHPBaseAddress + 8);
        }

        public uint ReadMaxHp()
        {
            return ReadMemory(this.CurrentHPBaseAddress + 4);
        }

        public string ReadCharacterName()
        {
            return ReadMemoryAsString(this.CurrentNameAddress);
        }

        public string ReadCurrentMap()
        {
            return ReadMemoryAsString(this.CurrentMapAddress);
        }

        public uint ReadMaxSp()
        {
            return ReadMemory(this.CurrentHPBaseAddress + 12);
        }

        public uint CurrentBuffStatusCode(int effectStatusIndex)
        {
            return ReadMemory(this.StatusBufferAddress + effectStatusIndex * 4);
        }

        public Client GetClientByProcess(string processName)
        {
       
            foreach(Client c in ClientListSingleton.GetAll())
            {
                if (c.ProcessName == processName)
                {
                    uint hpBaseValue = ReadMemory(c.CurrentHPBaseAddress);
                    if (hpBaseValue > 0) return c;
                }
            }
            return null;
        }
    
        public static Client FromDTO(ClientDTO dto)
        {
            return ClientListSingleton.GetAll()
                .Where(c => c.ProcessName == dto.Name)
                .Where(c => c.CurrentHPBaseAddress == dto.HPAddressPointer)
                .Where(c => c.CurrentNameAddress == dto.NameAddressPointer).FirstOrDefault();
        }
    }
}
