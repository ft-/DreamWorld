using System.Net;

namespace UPnPPortForwardManager
{
    public static class NetworkHelper
    {
        private static string _LocalIPAddress = string.Empty;
        /// <summary>
        /// This returns a String representation of the Current Machines IP Address
        /// </summary>
        public static string LocalIPAddress
        {
            get
            {
                if (string.IsNullOrEmpty(_LocalIPAddress))
                {
                    IPHostEntry host = Dns.GetHostByName(Dns.GetHostName());
                    if (host.AddressList.Length > 0)
                    {
                        _LocalIPAddress = host.AddressList[0].ToString();
                    }
                }
                return _LocalIPAddress;
            }
        }

    }
}
