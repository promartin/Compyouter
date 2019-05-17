using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registry.Classes.Components.Videocard
{
    enum Design
    {
        Reference,
        ASUS,
        MSI,
        Gigabyte,
        //GeForce
        EVGA,
        Zotac,
        Gainward,
        KFA2,
        Palit,
        PNY,
        inno3D,
        //AMD
        Sapphire,
        XFX,
        PowerColor,
        ATI
    }

    class Videocard : Components
    {
        private double gb;
        private Design design;
        private int tdp;
        private int pcieConnector;
        private int videoCardLength;

        public double Gb
        {
            get => gb;
            set
            {
                if (value >= 0.128 && value <= 32)
                {
                    gb = value;
                }
                else
                {
                    throw new ArgumentException("The size of the videocard must be between 0.128GB and 32GB!");
                }
            }
        }

        internal Design Design
        {
            get => design;
            set
            {

                switch (value)
                {
                    case Design.Reference:
                        design = value;
                        break;
                    case Design.ASUS:
                        design = value;
                        break;
                    case Design.MSI:
                        design = value;
                        break;
                    case Design.Gigabyte:
                        design = value;
                        break;
                    case Design.EVGA:
                        if (Manufacturer == "GeForce")
                        {
                            design = value;
                        }
                        else
                        {
                            throw new ArgumentException("EVGA doesn't make AMD videocards!");
                        }
                        break;
                    case Design.Zotac:
                        if (Manufacturer == "GeForce")
                        {
                            design = value;
                        }
                        else
                        {
                            throw new ArgumentException("Zotac doesn't make AMD videocards!");
                        }
                        break;
                    case Design.Gainward:
                        if (Manufacturer == "GeForce")
                        {
                            design = value;
                        }
                        else
                        {
                            throw new ArgumentException("Gainward doesn't make AMD videocards!");
                        }
                        break;
                    case Design.KFA2:
                        if (Manufacturer == "GeForce")
                        {
                            design = value;
                        }
                        else
                        {
                            throw new ArgumentException("KFA2 doesn't make AMD videocards!");
                        }
                        break;
                    case Design.Palit:
                        if (Manufacturer == "GeForce")
                        {
                            design = value;
                        }
                        else
                        {
                            throw new ArgumentException("Palit doesn't make AMD videocards!");
                        }
                        break;
                    case Design.PNY:
                        if (Manufacturer == "GeForce")
                        {
                            design = value;
                        }
                        else
                        {
                            throw new ArgumentException("PNY doesn't make AMD videocards!");
                        }
                        break;
                    case Design.inno3D:
                        if (Manufacturer == "GeForce")
                        {
                            design = value;
                        }
                        else
                        {
                            throw new ArgumentException("EVinno3D doesn't make AMD videocards!");
                        }
                        break;
                    case Design.Sapphire:
                        if (Manufacturer == "AMD")
                        {
                            design = value;
                        }
                        else
                        {
                            throw new ArgumentException("Sapphire doesn't make GeForce videocards!");
                        }
                        break;
                    case Design.XFX:
                        if (Manufacturer == "AMD")
                        {
                            design = value;
                        }
                        else
                        {
                            throw new ArgumentException("XFX doesn't make GeForce videocards!");
                        }
                        break;
                    case Design.PowerColor:
                        if (Manufacturer == "AMD")
                        {
                            design = value;
                        }
                        else
                        {
                            throw new ArgumentException("PowerColor doesn't make GeForce videocards!");
                        }
                        break;
                    case Design.ATI:
                        if (Manufacturer == "AMD")
                        {
                            design = value;
                        }
                        else
                        {
                            throw new ArgumentException("ATI doesn't make GeForce videocards!");
                        }
                        break;
                }
            }
        }

        public int Tdp
        {
            get => tdp;
            set
            {
                if (value >= 16 && value <= 500)
                {
                    tdp = value;
                }
                else
                {
                    throw new ArgumentException("The videocard's TDP must be between 16W and 500W!");
                }
            }
        }

        public int VideoCardLength
        {
            get => videoCardLength;
            set
            {
                if (value >= 69  && value <= 403)
                {
                    videoCardLength = value;
                }
                else
                {
                    throw new ArgumentException("The videocard lentgh has to be between 69mm and 403mm!");
                }
            }
        }

        public int PcieConnector
        {
            get => pcieConnector;
            set => pcieConnector = value;
        }

        public Videocard(string manufacturer, string productsName, string serialNumber, int price, DateTime dateOfPurchase, DateTime dateOfAdd, DateTime warranty, string text, double gb, Design design, int tdp, int pcieConnector, int videoCardLength) : base(manufacturer, productsName, serialNumber, price, dateOfPurchase, dateOfAdd, warranty, text)
        {
            Gb = gb;
            Design = design;
            Tdp = tdp;
            PcieConnector = pcieConnector;
            VideoCardLength = videoCardLength;
        }
    }
}
