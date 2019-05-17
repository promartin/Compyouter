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
        private FormFactor formFactor;
        private Socket socket;
        private MemoryGeneration memoryGeneration;
        private bool crossfire;
        private bool sli;
        private bool bluetooth;
        private bool wifi;
        private int m2x4Number;
        private int memorySlots;
        private int maxMemorySize;
        private int pciE_x16_Slots;
        private int pciE_x4_Slots;
        private int pciE_x1_Slots;
        private int sata3Connectors;
        private int usb30;
        private int usb31;
        private int lan;

        public bool Crossfire
        {
            get => crossfire;
            set => crossfire = value;
        }

        public bool Sli
        {
            get => sli;
            set => sli = value;
        }

        public bool Bluetooth
        {
            get => bluetooth;
            set => bluetooth = value;
        }
        public bool Wifi
        {
            get => wifi;
            set => wifi = value;
        }
        public int M2x4Number
        {
            get => m2x4Number;
            set => m2x4Number = value;
        }
        public int MemorySlots
        {
            get => memorySlots;
            set => memorySlots = value;
        }
        public int MaxMemorySize
        {
            get => maxMemorySize;
            set => maxMemorySize = value;
        }
        public int PciE_x16_Slots
        {
            get => pciE_x16_Slots;
            set => pciE_x16_Slots = value;
        }
        public int PciE_x4_Slots
        {
            get => pciE_x4_Slots;
            set => pciE_x4_Slots = value;
        }
        public int PciE_x1_Slots
        {
            get => pciE_x1_Slots;
            set => pciE_x1_Slots = value;
        }
        public int Sata3Connectors
        {
            get => sata3Connectors;
            set => sata3Connectors = value;
        }
        public int Usb30
        {
            get => usb30;
            set => usb30 = value;
        }
        public int Usb31
        {
            get => usb31;
            set => usb31 = value;
        }
        public int Lan
        {
            get => lan;
            set => lan = value;
        }
        internal FormFactor FormFactor
        {
            get => formFactor;
            set => formFactor = value;
        }
        internal Socket Socket
        {
            get => socket;
            set => socket = value;
        }
        internal MemoryGeneration MemoryGeneration
        {
            get => memoryGeneration;
            set => memoryGeneration = value;
        }

        public Motherboard(string manufacturer, string productsName, string serialNumber, int price, DateTime dateOfPurchase, DateTime dateOfAdd, DateTime warranty, string text, FormFactor formFactor, Socket socket, MemoryGeneration memoryGeneration, bool crossfire, bool sli, bool bluetooth, bool wifi, int m2X4Number, int memorySlots, int maxMemorySize, int pciEX16Slots, int pciEX4Slots, int pciEX1Slots, int sata3Connectors, int usb30, int usb31, int lan) : base(manufacturer, productsName, serialNumber, price, dateOfPurchase, dateOfAdd, warranty, text)
        {
            FormFactor = formFactor;
            Socket = socket;
            MemoryGeneration = memoryGeneration;
            Crossfire = crossfire;
            Sli = sli;
            Bluetooth = bluetooth;
            Wifi = wifi;
            m2x4Number = m2X4Number;
            MemorySlots = memorySlots;
            MaxMemorySize = maxMemorySize;
            pciE_x16_Slots = pciEX16Slots;
            pciE_x4_Slots = pciEX4Slots;
            pciE_x1_Slots = pciEX1Slots;
            Sata3Connectors = sata3Connectors;
            Usb30 = usb30;
            Usb31 = usb31;
            Lan = lan;
        }
    }
}
