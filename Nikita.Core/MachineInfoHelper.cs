//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd.
//-----------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;

namespace Nikita.Core
{
    /// <summary> 获取硬件信息
    ///
    /// </summary>
    public class MachineInfoHelper
    {
        public static string GetCpuSerialNo()
        {
            string cpuSerialNo = string.Empty;
            ManagementClass managementClass = new ManagementClass("Win32_Processor");
            ManagementObjectCollection managementObjectCollection = managementClass.GetInstances();
            foreach (var o in managementObjectCollection)
            {
                var managementObject = (ManagementObject)o;
                // 可能是有多个
                cpuSerialNo = managementObject.Properties["ProcessorId"].Value.ToString();
                break;
            }
            return cpuSerialNo;
        }

        public static string GetHardDiskInfo()
        {
            string hardDisk = string.Empty;
            ManagementClass managementClass = new ManagementClass("Win32_DiskDrive");
            ManagementObjectCollection managementObjectCollection = managementClass.GetInstances();
            foreach (var o in managementObjectCollection)
            {
                var managementObject = (ManagementObject)o;
                // 可能是有多个
                hardDisk = (string)managementObject.Properties["Model"].Value;
                break;
            }
            return hardDisk;
        }

        /// <summary>
        /// 获取IPv4地址列表
        /// </summary>
        /// <returns></returns>
        public static List<string> GetIpAddressList()
        {
            IPHostEntry ipHostEntrys = Dns.GetHostEntry(Dns.GetHostName());
            return (from ip in ipHostEntrys.AddressList where ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork select ip.ToString()).ToList();
        }

        /// <summary>
        /// 获取地址
        /// </summary>
        /// <returns>地址</returns>
        public static string GetMacAddress()
        {
            string macAddress = string.Empty;
            List<string> macAddressList = GetMacAddressList();

            foreach (string mac in macAddressList)
            {
                if (!string.IsNullOrEmpty(mac))
                {
                    macAddress = mac;
                    //格式化
                    macAddress = string.Format("{0}-{1}-{2}-{3}-{4}-{5}",
                        macAddress.Substring(0, 2),
                        macAddress.Substring(2, 2),
                        macAddress.Substring(4, 2),
                        macAddress.Substring(6, 2),
                        macAddress.Substring(8, 2),
                        macAddress.Substring(10, 2));
                    break;
                }
            }
            return macAddress;
        }

        /// <summary>
        /// 获取MAC地址列表，注意优先级高的放在了后面
        /// </summary>
        /// <returns></returns>
        public static List<string> GetMacAddressList()
        {
            NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
            return (from ni in networkInterfaces where !ni.Description.Contains("WiFi") && !ni.Description.Contains("Loopback") && !ni.Description.Contains("VMware") && ni.OperationalStatus == OperationalStatus.Up select ni.GetPhysicalAddress().ToString()).ToList();
        }

        /// <summary>
        /// GetWirelessIPList 获得无线网络接口的IpV4 地址列表
        /// </summary>
        /// <returns></returns>
        public static List<string> GetWirelessIpAddressList()
        {
            List<string> ipAddressList = new List<string>();
            NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface ni in networkInterfaces)
            {
                if (ni.Description.Contains("Wireless"))
                {
                    ipAddressList.AddRange(from ip in ni.GetIPProperties().UnicastAddresses where ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork select ip.Address.ToString());
                }
            }
            return ipAddressList;
        }

        /// <summary>
        /// GetWirelessMacList 获得无线网络接口的MAC地址列表
        /// </summary>
        /// <returns></returns>
        public static List<string> GetWirelessMacAddressList()
        {
            NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
            return (from ni in networkInterfaces where ni.Description.Contains("Wireless") && ni.OperationalStatus == OperationalStatus.Up select ni.GetPhysicalAddress().ToString()).ToList();
        }
    }
}