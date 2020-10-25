using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cherax_Loader
{
    public class Identifiers
    {
        public static string DiskSerial()
        {
            try
            {
                ManagementObject dsk = new ManagementObject(@"win32_logicaldisk.deviceid=""c:""");
                dsk.Get();
                return GetHashString(dsk["VolumeSerialNumber"].ToString());
            }
            catch
            {
                MessageBox.Show("Ran into an error please run as admin");
                return null;
            }
        }
        public static string CPUID()
        {
            try
            {
                var mbs = new ManagementObjectSearcher("Select ProcessorId From Win32_processor");
                ManagementObjectCollection mbsList = mbs.Get();
                string id = "";
                foreach (ManagementObject mo in mbsList)
                {
                    id = mo["ProcessorId"].ToString();
                    break;
                }
                return GetHashString(id);
            }
            catch
            {
                MessageBox.Show("Run as admin");
                Environment.Exit(0);
                Application.Exit();
                return null;
            }
        }
        private static byte[] GetHash(string inputString)
        {
            HashAlgorithm algorithm = SHA256.Create();
            return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        public static string GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }
    }
}
