using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registry.Classes.Components.Case
{
    enum CaseFormFactor
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

    class Case : Components
    {
        private bool atx;
        private bool eatx;
        private bool microATX;
        private bool miniITX;
        private bool miniSTX;
        private bool thinMiniITX;
        private int cpuHeatSinkHeight;
        private int videoCardLength;

        public bool BottomSupply { get; set; }

        public int HddSpace { get; set; }

        public int SlimHDDspace { get; set; }

        public int CpuHeatSinkHeight
        {
            get => cpuHeatSinkHeight;
            set
            {
                if (value >= 20 && value <= 500)
                {
                    cpuHeatSinkHeight = value;
                }
                else
                {
                    throw new ArgumentException("CPU heatsink height has to be between 20mm to 500mm!");
                }
            }
        }

        public int VideoCardLength
        {
            get => videoCardLength;
            set
            {
                if (value >= 69 && value <= 409)
                {
                    videoCardLength = value;
                }
                else
                {
                    throw new ArgumentException("The case's video card length must be between 69mm to 409mm!");
                }
            }
        }

        internal CaseFormFactor CaseFormFactor { get; set; }

        public bool Atx
        {
            get => atx;
            set
            {
                if (CaseFormFactor == CaseFormFactor.ATX)
                {
                    atx = true;
                }
                else 
                {
                    atx = value;
                }
            }
        }

        public bool Eatx
        {
            get => eatx;
            set
            {
                if (CaseFormFactor == CaseFormFactor.EATX)
                {
                    eatx = true;
                }
                else
                {
                    eatx = value;
                }
            }
        }

        public bool MicroATX
        {
            get => microATX;
            set
            {
                if (CaseFormFactor == CaseFormFactor.MicroATX)
                {
                    microATX = true;
                }
                else
                {
                    microATX = value;
                }
            }
        }

        public bool MiniITX
        {
            get => miniITX;
            set
            {
                if (CaseFormFactor == CaseFormFactor.MiniITX)
                {
                    miniITX = true;
                }
                else
                {
                    miniITX = value;
                }
            }
        }

        public bool MiniSTX
        {
            get => miniSTX;
            set
            {
                if (CaseFormFactor == CaseFormFactor.MiniSTX)
                {
                    miniSTX = true;
                }
                else
                {
                    miniSTX = value;
                }
            }
        }

        public bool ThinMiniITX
        {
            get => thinMiniITX;
            set
            {
                if (CaseFormFactor == CaseFormFactor.ThinMiniITX)
                {
                    thinMiniITX = true;
                }
                else
                {
                    thinMiniITX = value;
                }
            }
        }

        public Case(string manufacturer, string productsName, string serialNumber, int price, DateTime dateOfPurchase, DateTime dateOfAdd, DateTime warranty, string text, bool bottomSupply, CaseFormFactor caseFormFactor, bool atx, bool eatx, bool microAtx, bool miniItx, bool miniStx, bool thinMiniItx, int hddSpace, int slimHdDspace, int cpuHeatSinkHeight, int videoCardLength) : base(manufacturer, productsName, serialNumber, price, dateOfPurchase, dateOfAdd, warranty, text)
        {
            BottomSupply = bottomSupply;
            CaseFormFactor = caseFormFactor;
            Atx = atx;
            Eatx = eatx;
            microATX = microAtx;
            miniITX = miniItx;
            miniSTX = miniStx;
            thinMiniITX = thinMiniItx;
            HddSpace = hddSpace;
            SlimHDDspace = slimHdDspace;
            CpuHeatSinkHeight = cpuHeatSinkHeight;
            VideoCardLength = videoCardLength;
        }
    }
}
