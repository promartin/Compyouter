using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registry.Classes.Components.Motherboard
{
    enum FormFactor
    {
        [Description("ATX")]
        ATX,
        [Description("EATX")]
        EATX,
        [Description("Micro ATX")]
        MicroATX,
        [Description("Mini ITX")]
        MiniITX,
        [Description("Mini STX")]
        MiniSTX,
        [Description("Thin Mini ITX")]
        ThinMiniITX
    }

    enum Socket
    {
        //AMD
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
        SocketFM3plus,
        [Description("Socket TR4")]
        SocketTR4,

        //Intel
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

    enum MemoryGeneration
    {
        [Description("DDR")]
        DDR,
        [Description("DDR2")]
        DDR2,
        [Description("DDR3")]
        DDR3,
        [Description("DDR4")]
        DDR4
    }

    class Motherboard : Components
    {
        public bool Crossfire { get; set; }

        public bool Sli { get; set; }

        public bool Bluetooth { get; set; }

        public bool Wifi { get; set; }

        public int M2x4Number { get; set; }

        public int MemorySlots { get; set; }

        public int MaxMemorySize { get; set; }

        public int PciE_x16_Slots { get; set; }

        public int PciE_x4_Slots { get; set; }

        public int PciE_x1_Slots { get; set; }

        public int Sata3Connectors { get; set; }

        public int Usb30 { get; set; }

        public int Usb31 { get; set; }

        public int Lan { get; set; }

        internal FormFactor FormFactor { get; set; }

        internal Socket Socket { get; set; }

        internal MemoryGeneration MemoryGeneration { get; set; }

        public Motherboard(string manufacturer, string productsName, string serialNumber, int price, DateTime dateOfPurchase, DateTime dateOfAdd, DateTime warranty, string text, FormFactor formFactor, Socket socket, MemoryGeneration memoryGeneration, bool crossfire, bool sli, bool bluetooth, bool wifi, int m2X4Number, int memorySlots, int maxMemorySize, int pciEX16Slots, int pciEX4Slots, int pciEX1Slots, int sata3Connectors, int usb30, int usb31, int lan) : base(manufacturer, productsName, serialNumber, price, dateOfPurchase, dateOfAdd, warranty, text)
        {
            FormFactor = formFactor;
            Socket = socket;
            MemoryGeneration = memoryGeneration;
            Crossfire = crossfire;
            Sli = sli;
            Bluetooth = bluetooth;
            Wifi = wifi;
            M2x4Number = m2X4Number;
            MemorySlots = memorySlots;
            MaxMemorySize = maxMemorySize;
            PciE_x16_Slots = pciEX16Slots;
            PciE_x4_Slots = pciEX4Slots;
            PciE_x1_Slots = pciEX1Slots;
            Sata3Connectors = sata3Connectors;
            Usb30 = usb30;
            Usb31 = usb31;
            Lan = lan;
        }
    }
}
