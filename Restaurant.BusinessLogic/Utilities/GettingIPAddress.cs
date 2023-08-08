using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.BusinessLogic.Utilities
{
    public class GettingIPAddress
    {

        public static IPAddressSettings GetMyIpAddress()
        {
            string hostName = Dns.GetHostName();
            IPAddressSettings result = new IPAddressSettings(); 

            // Get the IP addresses associated with the host
            IPAddress[] addresses = Dns.GetHostAddresses(hostName);

            // Display the IP addresses
            foreach (IPAddress address in addresses)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork) // IPv4 addresses
                {
                    result.IPv4 = address.ToString();
                }
                else if (address.AddressFamily == AddressFamily.InterNetworkV6) // IPv6 addresses
                {
                    result.IPv6 = address.ToString();
                }
            }
            return result;
        }
    }

    public class IPAddressSettings
    {
        public string IPv4 { get; set; }
        public string IPv6 { get; set; }
    }
}
