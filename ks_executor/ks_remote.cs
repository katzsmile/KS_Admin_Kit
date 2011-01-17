using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.IO;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;


namespace ks_executor
{
    public class ks_remote : MarshalByRefObject
    {

        //// Admin Kit Helper variables

        public bool REG_DisableRegistry;
        public bool USB_ReadOnly;
        public bool USB_FullAccess;
        public bool USB_Disabled;

        //// Admin Kit Helper Checks Code
        public void REG_getStatus()
        {
            RegistryKey key;
            try
            {

                key = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
                if (System.Convert.ToInt16(key.GetValue("DisableRegistryTools", null)) == 1)
                    REG_DisableRegistry = true;
                else
                    REG_DisableRegistry = false;

                key.Close();
            }
            catch (NullReferenceException)
            {
                WriteLog("ERROR: NullReferenceException \n");
                key = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies", true);
                key.CreateSubKey("System");
            };
        }

        public void USB_getStatus()
        {

            RegistryKey key;
            try
            {
                key = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\StorageDevicePolicies");

                if (System.Convert.ToInt16(key.GetValue("WriteProtect", null)) == 1)
                    USB_ReadOnly = true;
                else
                    USB_FullAccess = true;
            }
            catch (NullReferenceException)
            {
                key = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Control", true);
                key.CreateSubKey("StorageDevicePolicies");
                key.Close();
            }
            catch (Exception) { }
            try
            {
                key = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Services\\UsbStor");

                if (System.Convert.ToInt16(key.GetValue("Start", null)) == 4)
                {
                    USB_Disabled = true;
                    return;
                }
            }
            catch (NullReferenceException)
            {
                key = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Services", true);
                key.CreateSubKey("USBSTOR");

                key = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Services\\UsbStor", true);

                key.SetValue("Type", 1, RegistryValueKind.DWord);
                key.SetValue("Start", 3, RegistryValueKind.DWord);
                key.SetValue("ImagePath", "system32\\drivers\\usbstor.sys", RegistryValueKind.ExpandString);
                key.SetValue("ErrorControl", 1, RegistryValueKind.DWord);
                key.SetValue("DisplayName", "USB Mass Storage Driver", RegistryValueKind.String);

                key.Close();
            }

            catch (Exception) { }

        }

        //// Admin Kit Helper Actions Code
        public void WriteLog(string Text)
        {
            FileStream fs = new FileStream(@"c:\KSExecutorService.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter m_streamWriter = new StreamWriter(fs);
            m_streamWriter.BaseStream.Seek(0, SeekOrigin.End);
            m_streamWriter.WriteLine(Text);
            m_streamWriter.Flush();
            m_streamWriter.Close();
        }


        public void REG_EnableRegedit()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey
                ("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", true);
            key.SetValue("DisableRegistryTools", 0, RegistryValueKind.DWord);
            key.Close();
        }
        public void REG_DisableRegedit()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey
                ("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", true);
            key.SetValue("DisableRegistryTools", 1, RegistryValueKind.DWord);
            key.Close();
        }
        public void USB_disableAllStorageDevices()
        {
            RegistryKey key = Registry.LocalMachine.OpenSubKey
                ("SYSTEM\\CurrentControlSet\\Services\\UsbStor", true);
            if (key != null)
            {
                key.SetValue("Start", 4, RegistryValueKind.DWord);
            }
            key.Close();
        }
        public void USB_enableAllStorageDevices()
        {
            RegistryKey key = Registry.LocalMachine.OpenSubKey
                ("SYSTEM\\CurrentControlSet\\Services\\UsbStor", true);
            if (key != null)
            {
                key.SetValue("Start", 3, RegistryValueKind.DWord);
            }
            key.Close();
        }
        public void USB_enableWriteProtect()
        {
            RegistryKey key = Registry.LocalMachine.OpenSubKey
              ("SYSTEM\\CurrentControlSet\\Control\\StorageDevicePolicies", true);
            if (key == null)
            {
                Registry.LocalMachine.CreateSubKey
                    ("SYSTEM\\CurrentControlSet\\Control\\StorageDevicePolicies", RegistryKeyPermissionCheck.ReadWriteSubTree);
                key = Registry.LocalMachine.OpenSubKey
                ("SYSTEM\\CurrentControlSet\\Control\\StorageDevicePolicies", true);
                key.SetValue("WriteProtect", 1, RegistryValueKind.DWord);
            }
            else if (key.GetValue("WriteProtect") != (object)(1))
            {
                key.SetValue("WriteProtect", 1, RegistryValueKind.DWord);
            }
        }
        public void USB_disableWriteProtect()
        {
            RegistryKey key = Registry.LocalMachine.OpenSubKey
               ("SYSTEM\\CurrentControlSet\\Control\\StorageDevicePolicies", true);
            if (key != null)
            {
                key.SetValue("WriteProtect", 0, RegistryValueKind.DWord);
            }
            key.Close();
        }
    }
}
