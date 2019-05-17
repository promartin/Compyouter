using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registry.Classes.Components.Processors
{
    enum AMDSocket
    {
        [Description("Socket AM2")]
        SocketAM2,
        [Description("Socket AM2+")]
        SocketAM2Plus,
        [Description("Socket AM3")]
        SocketAM3,
        [Description("Socket AM3+")]
        SocketAM3Plus,
        [Description("Socket AM4")]
        SocketAM4,
        [Description("Socket FM1")]
        SocketFM1,
        [Description("Socket FM2")]
        SocketFM2,
        [Description("Socket FM2+")]
        SocketFM2Plus,
        [Description("Socket FM3")]
        SocketFM3,
        [Description("Socket FM3+")]
        SocketFM3Plus,
        [Description("Socket TR4")]
        SocketTR4
    }

    class AMDProcessor : Processor
    {
        private AMDSocket amdSocket;
        private string integratedGraphics;

        internal AMDSocket AmdSocket
        {
            get => amdSocket;
            set => amdSocket = value;
        }

        public string IntegratedGraphics
        {
            get => integratedGraphics;
            set
            {
                if (AmdSocket == AMDSocket.SocketFM1 || AmdSocket == AMDSocket.SocketFM2 || AmdSocket == AMDSocket.SocketFM2Plus || AmdSocket == AMDSocket.SocketFM3)
                {
                    if (value != "")
                    {
                        integratedGraphics = value;
                    }
                    else
                    {
                        throw new ArgumentException("This socketed AMD CPU must have an integrated graphics chip!");
                    }

                }
                else if (value == "")
                {
                    integratedGraphics = value;
                }
                else if (AmdSocket == AMDSocket.SocketFM1 || AmdSocket == AMDSocket.SocketFM2 || AmdSocket == AMDSocket.SocketFM2Plus || AmdSocket == AMDSocket.SocketFM3)
                {
                    throw new ArgumentException("This socketed AMD CPU must have an integrated graphics chip!");
                }
            }
        }

        public AMDProcessor(string manufacturer, string productsName, string serialNumber, int price, DateTime dateOfPurchase, DateTime dateOfAdd, DateTime warranty, string text, double l2Cache, double l3Cache, int cores, int threads, int process, int frequency, int turboFrequency, int tdp, AMDSocket amdSocket, string integratedGraphics) : base(manufacturer, productsName, serialNumber, price, dateOfPurchase, dateOfAdd, warranty, text, l2Cache, l3Cache, cores, threads, process, frequency, turboFrequency, tdp)
        {
            AmdSocket = amdSocket;
            IntegratedGraphics = integratedGraphics;
        }

        public override string ToString()
        {
            return base.ToString() + $"{amdSocket}";
        }
    }
}
