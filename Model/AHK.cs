using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using System.Windows.Input;
using System.Drawing;
using _4RTools.Utils;
using Newtonsoft.Json;
using System.Runtime.InteropServices;

namespace _4RTools.Model
{
    public class KeyConfig
    {
        public Key key { get; set; }
        public bool ClickActive { get; set; }

        public KeyConfig(Key key, bool clickAtive)
        {
            this.key = key;
            this.ClickActive = clickAtive;
        }
    }

    public class AHK : Action
    {
        // Import the mouse_event function from the Windows API
        [DllImport("user32.dll")]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, int dwExtraInfo);

        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        private const string ACTION_NAME = "AHK20";
        private _4RThread thread;
        public const string COMPATIBILITY = "ahkCompatibility";
        public const string SPEED_BOOST = "ahkSpeedBoost";
        public const string SYNCHRONOUS = "ahkSynchronous";
        public Dictionary<string, KeyConfig> AhkEntries { get; set; } = new Dictionary<string, KeyConfig>();
        public int AhkDelay { get; set; } = 100;
        public bool mouseFlick { get; set; } = false;
        public bool noShift { get; set; } = false;
        public string ahkMode { get; set; } = COMPATIBILITY;

        public AHK()
        {
        }

        public void Start()
        {
            Client roClient = ClientSingleton.GetClient();
            if (roClient != null)
            {
                if (this.thread != null)
                {
                    _4RThread.Stop(this.thread);
                }

                this.thread = new _4RThread(_ => AHKThreadExecution(roClient));
                _4RThread.Start(this.thread);
            }
        }

        private int AHKThreadExecution(Client roClient)
        {
            if (ahkMode.Equals(COMPATIBILITY))
            {
                foreach (KeyConfig config in AhkEntries.Values)
                {
                    Keys thisk = (Keys)Enum.Parse(typeof(Keys), config.key.ToString());
                    if (!Keyboard.IsKeyDown(Key.LeftAlt) && !Keyboard.IsKeyDown(Key.RightAlt))
                    {
                        if (config.ClickActive && Keyboard.IsKeyDown(config.key))
                        {
                            if (noShift) keybd_event(Constants.VK_SHIFT, 0x45, Constants.KEYEVENTF_EXTENDEDKEY, 0);
                            _AHKCompatibility(roClient, config, thisk);
                            if (noShift) keybd_event(Constants.VK_SHIFT, 0x45, Constants.KEYEVENTF_EXTENDEDKEY | Constants.KEYEVENTF_KEYUP, 0);

                        }
                        else
                        {
                            this._AHKNoClick(roClient, config, thisk);
                        }
                    }
                }
            }
            else if (ahkMode.Equals(SYNCHRONOUS))
            {
                foreach (KeyConfig config in AhkEntries.Values)
                {
                    Keys thisk = (Keys)Enum.Parse(typeof(Keys), config.key.ToString());
                    _AHKSynchronous(roClient, config, thisk);
                }
            }
            else
            {
                foreach (KeyConfig config in AhkEntries.Values)
                {
                    Keys thisk = (Keys)Enum.Parse(typeof(Keys), config.key.ToString());
                    this._AHKSpeedBoost(roClient, config, thisk);
                }
            }
            return 0;
        }

        private void _AHKCompatibility(Client roClient, KeyConfig config, Keys thisk)
        {
            Func<int, int> send_click;

            send_click = (evt) =>
            {
                Interop.PostMessage(roClient.process.MainWindowHandle, Constants.WM_LBUTTONDOWN, 0, 0);
                Thread.Sleep(1);
                Interop.PostMessage(roClient.process.MainWindowHandle, Constants.WM_LBUTTONUP, 0, 0);
                return 0;
            };

            if (this.mouseFlick)
            {
                bool ammo = false;
                while (Keyboard.IsKeyDown(config.key))
                {
                    autoSwitchAmmo(roClient, ref ammo);
                    Interop.PostMessage(roClient.process.MainWindowHandle, Constants.WM_KEYDOWN_MSG_ID, thisk, 0);
                    System.Windows.Forms.Cursor.Position = new Point(System.Windows.Forms.Cursor.Position.X - Constants.MOUSE_DIAGONAL_MOVIMENTATION_PIXELS_AHK, System.Windows.Forms.Cursor.Position.Y - Constants.MOUSE_DIAGONAL_MOVIMENTATION_PIXELS_AHK);
                    send_click(0);
                    System.Windows.Forms.Cursor.Position = new Point(System.Windows.Forms.Cursor.Position.X + Constants.MOUSE_DIAGONAL_MOVIMENTATION_PIXELS_AHK, System.Windows.Forms.Cursor.Position.Y + Constants.MOUSE_DIAGONAL_MOVIMENTATION_PIXELS_AHK);
                    Thread.Sleep(this.AhkDelay);
                }
            }
            else
            {
                bool ammo = false;
                while (Keyboard.IsKeyDown(config.key))
                {
                    autoSwitchAmmo(roClient, ref ammo);
                    Interop.PostMessage(roClient.process.MainWindowHandle, Constants.WM_KEYDOWN_MSG_ID, thisk, 0);
                    send_click(0);
                    Thread.Sleep(this.AhkDelay);
                }
            }
        }

        private void _AHKSynchronous(Client roClient, KeyConfig config, Keys thisk)
        {
            
            Func<int, int> send_click;
            //bool ammo = false;
            send_click = (evt) =>
            {
                SendMessage(roClient.process.MainWindowHandle, Constants.WM_LBUTTONDOWN, IntPtr.Zero, IntPtr.Zero);
                Thread.Sleep(1);
                SendMessage(roClient.process.MainWindowHandle, Constants.WM_LBUTTONUP, IntPtr.Zero, IntPtr.Zero);
                return 0;
            };

        }

        private void _AHKSpeedBoost(Client roClient, KeyConfig config, Keys thisk)
        {
            bool ammo = false;
            while (Keyboard.IsKeyDown(config.key))
            {
                autoSwitchAmmo(roClient, ref ammo);

                Interop.PostMessage(roClient.process.MainWindowHandle, Constants.WM_KEYDOWN_MSG_ID, thisk, 0);
                if (config.ClickActive)
                {
                    Point cursorPos = System.Windows.Forms.Cursor.Position;
                    mouse_event(Constants.MOUSEEVENTF_LEFTDOWN, (uint)cursorPos.X, (uint)cursorPos.Y, 0, 0);
                    Thread.Sleep(1);
                    mouse_event(Constants.MOUSEEVENTF_LEFTUP, (uint)cursorPos.X, (uint)cursorPos.Y, 0, 0);
                }
                Thread.Sleep(this.AhkDelay);
            }
        }

        private void autoSwitchAmmo(Client roClient, ref bool ammo)
        {
            if (ProfileSingleton.GetCurrent().UserPreferences.switchAmmo)
            {
                if (ProfileSingleton.GetCurrent().UserPreferences.ammo1Key.ToString() != String.Empty
                    && ProfileSingleton.GetCurrent().UserPreferences.ammo2Key.ToString() != String.Empty)
                {
                    if (ammo == false)
                    {
                        Key key = ProfileSingleton.GetCurrent().UserPreferences.ammo1Key;
                        Interop.PostMessage(roClient.process.MainWindowHandle, Constants.WM_KEYDOWN_MSG_ID, toKeys(key), 0);
                        ammo = true;
                    }
                    else
                    {
                        Key key = ProfileSingleton.GetCurrent().UserPreferences.ammo2Key;
                        Interop.PostMessage(roClient.process.MainWindowHandle, Constants.WM_KEYDOWN_MSG_ID, toKeys(key), 0);
                        ammo = false;
                    }

                }
            }
        }

        private bool hasBuff(Client c, EffectStatusIDs buff)
        {
            for (int i = 1; i < Constants.MAX_BUFF_LIST_INDEX_SIZE; i++)
            {
                uint currentStatus = c.CurrentBuffStatusCode(i);
                if (currentStatus == (int)buff) { return true; }
            }
            return false;
        }

        private Keys toKeys(Key k)
        {
            // Explicit mapping for D0-D9 and other special keys
            switch (k)
            {
                case Key.D0: return Keys.D0;
                case Key.D1: return Keys.D1;
                case Key.D2: return Keys.D2;
                case Key.D3: return Keys.D3;
                case Key.D4: return Keys.D4;
                case Key.D5: return Keys.D5;
                case Key.D6: return Keys.D6;
                case Key.D7: return Keys.D7;
                case Key.D8: return Keys.D8;
                case Key.D9: return Keys.D9;
                case Key.OemPlus: return Keys.Oemplus;
                case Key.OemTilde: return Keys.Oemtilde;
                case Key.OemComma: return Keys.Oemcomma;
                default:
                    // Use Enum.Parse for other keys
                    return (Keys)Enum.Parse(typeof(Keys), k.ToString());
            }
        }

        private void _AHKNoClick(Client roClient, KeyConfig config, Keys thisk)
        {
            while (Keyboard.IsKeyDown(config.key))
            {
                Interop.PostMessage(roClient.process.MainWindowHandle, Constants.WM_KEYDOWN_MSG_ID, thisk, 0);
                Thread.Sleep(this.AhkDelay);
            }
        }

        public void AddAHKEntry(string chkboxName, KeyConfig value)
        {
            if (this.AhkEntries.ContainsKey(chkboxName))
            {
                RemoveAHKEntry(chkboxName);
            }

            this.AhkEntries.Add(chkboxName, value);

        }

        public void RemoveAHKEntry(string chkboxName)
        {
            this.AhkEntries.Remove(chkboxName);
        }

        public void Stop()
        {
            _4RThread.Stop(this.thread);
        }

        public string GetConfiguration()
        {
            return JsonConvert.SerializeObject(this);
        }

        public string GetActionName()
        {
            return ACTION_NAME;
        }
    }
}
