﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4RTools.Model
{
    internal class LocalServerManager
    {

        private static readonly string localServerName = "supported_servers.json";
        private static readonly string localCityName = "city_name.json";
        private static List<String> cityList;

        public static void AddServer(string hpAddress, string nameAddress, string processName)
        {
            if (!isValid(hpAddress))
            {
                throw new ArgumentException("HP Address is Invalid. Please type a valid Hex value.");
            }

            if(!isValid(nameAddress))
            {
                throw new ArgumentException("Name Address is Invalid. Please type a valid Hex value.");
            }
            ClientDTO dto = new ClientDTO(processName, null, hpAddress, nameAddress, null);
            ClientListSingleton.AddClient(new Client(dto));

            List<ClientDTO> clients = GetLocalClients();
            clients.Add(dto);
            OverwriteLocalFile(clients);

            /**
             * Cases
             * 1. Local file don't exists
             *  Solution: Create a empty file
             * 2. Local file exists with wrong syntax
             *  Solution: Remove invalid file and create new one
             * 3. Arquivo Local existe e é válido
             */
        }

        public static void RemoveClient(ClientDTO dto)
        {
            List<ClientDTO> clients = GetLocalClients();
            clients.RemoveAt(dto.index);
            OverwriteLocalFile(clients);
            ClientListSingleton.RemoveClient(Client.FromDTO(dto));
        }

        private static void OverwriteLocalFile(List<ClientDTO> clients)
        {
            string output = JsonConvert.SerializeObject(clients, Formatting.Indented);
            File.WriteAllText(localServerName, string.Empty);
            File.WriteAllText(localServerName, output);
        }


        private static string LoadLocalServerFile()
        {
             string startJson = "[\r\n  {\r\n    \"name\": \"OsRO MR\",\r\n    \"description\": \"OsRO Midrate\",\r\n    \"hpAddress\": \"00E8F434\",\r\n    \"nameAddress\": \"0x00E91C00\",\r\n    \"mapAddress\": \"0x00E8ABD4\"\r\n  }\r\n]";
               
            if (!File.Exists(localServerName))
            {
                FileStream f = File.Create(localServerName);
                f.Close();
                File.WriteAllText(localServerName, startJson);
                return startJson;
            }
            string json = File.ReadAllText(localServerName);
            if (string.IsNullOrEmpty(json) || json.Length < 10)
            {
                File.WriteAllText(localServerName, startJson);
                return startJson;
            }
            return json;
        }

        public static List<ClientDTO> GetLocalClients() {
            string localServers = LoadLocalServerFile();

            if (string.IsNullOrEmpty(localServers)) return new List<ClientDTO>();

            try
            {
                return JsonConvert.DeserializeObject<List<ClientDTO>>(localServers);
            }catch
            {
                return new List<ClientDTO>();
            }
        }

        private static string LoadLocalCityNameFile()
        {
            string[] defaultCities = {
                "prontera", "morocc", "geffen", "payon", "alberta", "izlude", "aldebaran", "xmas",
                "comodo", "yuno", "amatsu", "gonryun", "umbala", "niflheim", "louyang", "jawaii",
                "ayothaya", "einbroch", "lighthalzen", "einbech", "hugel", "rachel", "veins",
                "moscovia", "mid_camp", "munak", "splendide", "brasilis", "dicastes01", "mora",
                "dewata", "malangdo", "malaya", "eclage", "marketplace", "mainhall", "quiz_00"
            };

            if (!File.Exists(localCityName))
            {
                string startJson = "[\r\n  \"" + string.Join("\",\r\n  \"", defaultCities) + "\"\r\n]";
                FileStream f = File.Create(localCityName);
                f.Close();
                File.WriteAllText(localCityName, startJson);
                return startJson;
            }
            string json = File.ReadAllText(localCityName);
            return json;
        }

        public static List<String> GetListCities()
        {
            if (cityList == null || cityList.Count == 0) { 
                string localServers = LoadLocalCityNameFile();

                if (string.IsNullOrEmpty(localServers)) return new List<String>();

                try
                {
                    cityList = JsonConvert.DeserializeObject<List<String>>(localServers);
                }
                catch
                {
                    return new List<String>();
                }
            }
            return cityList;
        }

        private static bool isValid(IEnumerable<char> chars)
        {
            return IsHex(chars) && chars.Count() == 8;
        }

        public static bool IsHex(IEnumerable<char> chars)
        {
            bool isHex;
            foreach (var c in chars)
            {
                isHex = ((c >= '0' && c <= '9') ||
                         (c >= 'a' && c <= 'f') ||
                         (c >= 'A' && c <= 'F'));

                if (!isHex)
                    return false;
            }
            return true;
        }
    }
}
