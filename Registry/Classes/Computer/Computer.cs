using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Registry.Classes.Components;
using Registry.Classes.Components.Case;
using Registry.Classes.Components.Cooler;
using Registry.Classes.Components.Motherboard;
using Registry.Classes.Components.PowerSupply;
using Registry.Classes.Components.Processors;
using Registry.Classes.Components.RAM;
using Registry.Classes.Components.Storages;
using Registry.Classes.Components.Videocard;
using FormFactor = Registry.Classes.Components.Motherboard.FormFactor;

namespace Registry.Classes.Computer
{
    class Computer
    {
        private Case house;
        private Motherboard motherboard;
        private IntelProcessor intelProcessor;
        private AMDProcessor amdProcessor;
        private List<RAM> rams;
        private List<Videocard> videocards;
        private Cooler cooler;
        private PowerSupply powerSupply;
        private List<SSD> ssds;
        private List<HDD> hdds;

        internal Case House
        {
            get => house;
            set => house = value;
        }

        internal Motherboard Motherboard
        {
            get => motherboard;
            set
            {
                switch (value.FormFactor)
                {
                    case FormFactor.ATX:
                        if (house.Atx)
                        {
                            motherboard = value;
                        }
                        else
                        {
                            throw new ComputerError("The case doesn't support ATX motherboards!");
                        }
                        break;
                    case FormFactor.EATX:
                        if (house.Eatx)
                        {
                            motherboard = value;
                        }
                        else
                        {
                            throw new ComputerError("The case doesn't support EATX motherboards!");
                        }
                        break;
                    case FormFactor.MicroATX:
                        if (house.MicroATX)
                        {
                            motherboard = value;
                        }
                        else
                        {
                            throw new ComputerError("The case doesn't support Micro ATX motherboards!");
                        }
                        break;
                    case FormFactor.MiniITX:
                        if (house.MiniITX)
                        {
                            motherboard = value;
                        }
                        else
                        {
                            throw new ComputerError("The case doesn't support Mini ITX motherboards!");
                        }
                        break;
                    case FormFactor.MiniSTX:
                        if (house.MiniSTX)
                        {
                            motherboard = value;
                        }
                        else
                        {
                            throw new ComputerError("The case doesn't support Mini STX motherboards!");
                        }
                        break;
                    case FormFactor.ThinMiniITX:
                        if (house.ThinMiniITX)
                        {
                            motherboard = value;
                        }
                        else
                        {
                            throw new ComputerError("The case doesn't support Thin Mini ITX motherboards!");
                        }
                        break;
                }
            }
        }

        internal IntelProcessor IntelProcessor
        {
            get => intelProcessor;
            set
            {
                IntelSocket socket = value.IntelSocket;

                string a = Motherboard.Socket.ToString();
                string b = value.IntelSocket.ToString();

                if (Motherboard.Socket.ToString() == value.IntelSocket.ToString())
                {
                    intelProcessor = value;
                }
                else
                {
                    throw new ComputerError("The motherboard's CPU socket doesn't support this CPU!");
                }
            }
        }

        internal AMDProcessor AmdProcessor
        {
            get => amdProcessor;
            set
            {
                if (Motherboard.Socket.ToString() == value.AmdSocket.ToString())
                {
                    amdProcessor = value;
                }
                else
                {
                    throw new ComputerError("The motherboard's CPU socket doesn't support this CPU!");
                }
            }
        }

        internal List<RAM> Rams
        {
            get => rams;
            set
            {
                int maxSize = 0;
                int memoryPieces = 0;
                bool badGeneration = false;
                int r = value.Count;
                for (int i = 0; i < r; i++)
                {
                    maxSize += value[i].Size;
                    memoryPieces += value[i].Pieces;
                    if (value[i].RamGeneration.ToString() != Motherboard.MemoryGeneration.ToString())
                    {
                        badGeneration = true;
                    }
                }

                if (Motherboard.MaxMemorySize < (maxSize * memoryPieces))
                {
                    throw new ComputerError("RAM memory exceeds the motherboard's maximum supported memory!");
                }
                else if (Motherboard.MemorySlots < memoryPieces)
                {
                    throw new ComputerError("The motherboard's memory slot is not enough for this many pieces of RAM!");
                }
                else if (badGeneration)
                {
                    throw new ComputerError("Motherboard's RAM generation is not the same as the RAM's generation!");
                }
                else
                {
                    rams = value;
                }
            }
        }

        internal List<Videocard> Videocards
        {
            get => videocards;
            set
            {
                int? pcieNumber = 0;
                byte v = (byte)value.Count;
                for (byte i = 0; i < v; i++)
                {
                    pcieNumber += value[i].PcieConnector;

                }

                if (PowerSupply.Pcie >= pcieNumber)
                {
                    if (v <= Motherboard.PciE_x16_Slots)
                    {
                        videocards = value;
                    }
                    else
                    {
                        throw new ComputerError("Too many videocards for the motherboard's PCIe x16 slot!!");
                    }
                }
                else
                {
                    throw new ComputerError("Not enough PCIe connector for the videocards!");
                }
            }
        }

        internal Cooler Cooler
        {
            get => cooler;
            set
            {
                if (House.CpuHeatSinkHeight >= value.Height)
                {
                    switch (Motherboard.Socket)
                    {
                        case Socket.SocketAM2:
                            if (value.AM22plus33plus)
                            {
                                cooler = value;
                            }
                            else
                            {
                                throw new ComputerError("The CPU cooler is not compatible with the motherboard's socket!");
                            }
                            break;
                        case Socket.SocketAM2Plus:
                            if (value.AM22plus33plus)
                            {
                                cooler = value;
                            }
                            else
                            {
                                throw new ComputerError("The CPU cooler is not compatible with the motherboard's socket!");
                            }
                            break;
                        case Socket.SocketAM3:
                            if (value.AM22plus33plus)
                            {
                                cooler = value;
                            }
                            else
                            {
                                throw new ComputerError("The CPU cooler is not compatible with the motherboard's socket!");
                            }
                            break;
                        case Socket.SocketAM3Plus:
                            if (value.AM22plus33plus)
                            {
                                cooler = value;
                            }
                            else
                            {
                                throw new ComputerError("The CPU cooler is not compatible with the motherboard's socket!");
                            }
                            break;
                        case Socket.SocketAM4:
                            if (value.Am4)
                            {
                                cooler = value;
                            }
                            else
                            {
                                throw new ComputerError("The CPU cooler is not compatible with the motherboard's socket!");
                            }
                            break;
                        case Socket.SocketFM1:
                            if (value.Fm122plus3plus)
                            {
                                cooler = value;
                            }
                            else
                            {
                                throw new ComputerError("The CPU cooler is not compatible with the motherboard's socket!");
                            }
                            break;
                        case Socket.SocketFM2:
                            if (value.Fm122plus3plus)
                            {
                                cooler = value;
                            }
                            else
                            {
                                throw new ComputerError("The CPU cooler is not compatible with the motherboard's socket!");
                            }
                            break;
                        case Socket.SocketFM2Plus:
                            if (value.Fm122plus3plus)
                            {
                                cooler = value;
                            }
                            else
                            {
                                throw new ComputerError("The CPU cooler is not compatible with the motherboard's socket!");
                            }
                            break;
                        case Socket.SocketFM3:
                            if (value.Fm122plus3plus)
                            {
                                cooler = value;
                            }
                            else
                            {
                                throw new ComputerError("The CPU cooler is not compatible with the motherboard's socket!");
                            }
                            break;
                        case Socket.SocketFM3plus:
                            if (value.Fm122plus3plus)
                            {
                                cooler = value;
                            }
                            else
                            {
                                throw new ComputerError("The CPU cooler is not compatible with the motherboard's socket!");
                            }
                            break;
                        case Socket.SocketTR4:
                            if (value.Tr4)
                            {
                                cooler = value;
                            }
                            else
                            {
                                throw new ComputerError("The CPU cooler is not compatible with the motherboard's socket!");
                            }
                            break;
                        case Socket.LGA775:
                            if (value.Lga775)
                            {
                                cooler = value;
                            }
                            else
                            {
                                throw new ComputerError("The CPU cooler is not compatible with the motherboard's socket!");
                            }
                            break;
                        case Socket.LGA1366:
                            if (value.Lga1366)
                            {
                                cooler = value;
                            }
                            else
                            {
                                throw new ComputerError("The CPU cooler is not compatible with the motherboard's socket!");
                            }
                            break;
                        case Socket.LGA1150:
                            if (value.Lga1151)
                            {
                                cooler = value;
                            }
                            else
                            {
                                throw new ComputerError("The CPU cooler is not compatible with the motherboard's socket!");
                            }
                            break;
                        case Socket.LGA1151:
                            if (value.Lga1151)
                            {
                                cooler = value;
                            }
                            else
                            {
                                throw new ComputerError("The CPU cooler is not compatible with the motherboard's socket!");
                            }
                            break;
                        case Socket.LGA1151v2:
                            if (value.Lga1151)
                            {
                                cooler = value;
                            }
                            else
                            {
                                throw new ComputerError("The CPU cooler is not compatible with the motherboard's socket!");
                            }
                            break;
                        case Socket.LGA1155:
                            if (value.Lga1151)
                            {
                                cooler = value;
                            }
                            else
                            {
                                throw new ComputerError("The CPU cooler is not compatible with the motherboard's socket!");
                            }
                            break;
                        case Socket.LGA1156:
                            if (value.Lga1151)
                            {
                                cooler = value;
                            }
                            else
                            {
                                throw new ComputerError("The CPU cooler is not compatible with the motherboard's socket!");
                            }
                            break;
                        case Socket.LGA2011:
                            if (value.Lga2011)
                            {
                                cooler = value;
                            }
                            else
                            {
                                throw new ComputerError("The CPU cooler is not compatible with the motherboard's socket!");
                            }
                            break;
                        case Socket.LGA2011v3:
                            if (value.Lga2011)
                            {
                                cooler = value;
                            }
                            else
                            {
                                throw new ComputerError("The CPU cooler is not compatible with the motherboard's socket!");
                            }
                            break;
                        case Socket.LGA2066:
                            if (value.Lga2066)
                            {
                                cooler = value;
                            }
                            else
                            {
                                throw new ComputerError("The CPU cooler is not compatible with the motherboard's socket!");
                            }
                            break;
                    }
                }
                else
                {
                    throw new ComputerError("The cooler exceeds the case's maximum heatsink height!");
                }
            }
        }

        internal PowerSupply PowerSupply
        {
            get => powerSupply;
            set => powerSupply = value;
        }

        internal List<SSD> Ssds
        {
            get => ssds;
            set
            {
                int s = value.Count;
                int? sata3 = 0;
                int? m2 = 0;

                for (int i = 0; i < s; i++)
                {
                    switch (value[i].ConnectorType)
                    {
                        case ConnectorType.SATA3:
                            sata3 += 1;
                            break;
                        case ConnectorType.m2:
                            m2 += 1;
                            break;
                    }
                }

                if (Motherboard.M2x4Number >= 1 && m2 >= 1)
                {
                    ssds = value;
                }
                else if (motherboard.Sata3Connectors <= sata3)
                {
                    ssds = value;
                }
                else if (s == 0)
                {
                    ssds = value;
                }
                else
                {
                    throw new ComputerError("Out of connectors on the motherboard!");
                }

            }
        }

        internal List<HDD> Hdds
        {
            get => hdds;
            set
            {
                if (motherboard.Sata3Connectors >= value.Count)
                {
                    hdds = value;
                }
                else
                {
                    throw new ComputerError("No corresponding-, or out of connectors on the motherboard!");
                }
            }
        }

        public Computer(Case house, Motherboard motherboard, IntelProcessor intelProcessor, List<RAM> rams, List<Videocard> videocards, Cooler cooler, PowerSupply powerSupply, List<SSD> ssds, List<HDD> hdds)
        {
            House = house;
            Motherboard = motherboard;
            IntelProcessor = intelProcessor;
            Rams = rams;
            PowerSupply = powerSupply;
            Videocards = videocards;
            Cooler = cooler;
            Ssds = ssds;
            Hdds = hdds;
        }

        public Computer(Case house, Motherboard motherboard, AMDProcessor amdProcessor, List<RAM> rams, List<Videocard> videocards, Cooler cooler, PowerSupply powerSupply, List<SSD> ssds, List<HDD> hdds)
        {
            House = house;
            Motherboard = motherboard;
            AmdProcessor = amdProcessor;
            Rams = rams;
            PowerSupply = powerSupply;
            Videocards = videocards;
            Cooler = cooler;
            Ssds = ssds;
            Hdds = hdds;
        }

    }
}
