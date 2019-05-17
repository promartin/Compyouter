using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registry.Classes.Components.Processors
{
    enum IntelSocket
    {
        [Description("LGA 775")]
        LGA775,
        [Description("LGA 1366")]
        LGA1366,
        [Description("LGA 1150")]
        LGA1150,
        [Description("LGA 1151")]
        LGA1151,
        [Description("LGA 1151v2")]
        LGA1151v2,
        [Description("LGA 1155")]
        LGA1155,
        [Description("LGA 1156")]
        LGA1156,
        [Description("LGA 2011")]
        LGA2011,
        [Description("LGA 2011v3")]
        LGA2011v3,
        [Description("LGA 2066")]
        LGA2066,
    }

    class IntelProcessor : Processor
    {
        private IntelSocket intelSocket;
        private string integratedGraphics;

        public string IntegratedGraphics
        {
            get => integratedGraphics;
            set => integratedGraphics = value;
        }

        internal IntelSocket IntelSocket
        {
            get => intelSocket;
            set => intelSocket = value;
        }

        public IntelProcessor(string manufacturer, string productsName, string serialNumber, int price, DateTime dateOfPurchase, DateTime dateOfAdd, DateTime warranty, string text, double l2Cache, double l3Cache, int cores, int threads, int process, int frequency, int turboFrequency, int tdp, IntelSocket intelSocket, string integratedGraphics) : base(manufacturer, productsName, serialNumber, price, dateOfPurchase, dateOfAdd, warranty, text, l2Cache, l3Cache, cores, threads, process, frequency, turboFrequency, tdp)
        {
            IntelSocket = intelSocket;
            IntegratedGraphics = integratedGraphics;
        }

        public override string ToString()
        {
            return base.ToString() + $"{intelSocket}";
        }
    }
}
