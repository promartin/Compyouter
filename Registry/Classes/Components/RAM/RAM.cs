using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registry.Classes.Components.RAM
{
    enum RAMGeneration
    {
        DDR,
        DDR2,
        DDR3,
        DDR4
    }

    class RAM : Components
    {
        private RAMGeneration ramGeneration;
        private int frequency;
        private int latency;

        public int Size { get; set; }

        public int Frequency
        {
            get => frequency;
            set
            {
                if (value >= 266 && value <= 4600)
                {
                    frequency = value;
                }
                else
                {
                    throw new ArgumentException("The RAM's frequency must be equal or more than 266, but less or equal to 4600!");
                }
            }
        }

        public int Latency
        {
            get => latency;
            set
            {
                if (value >= 3 && value <= 19)
                {
                    latency = value;
                }
                else
                {
                    throw new ArgumentException("The RAM's latency must be equal or more than 3, but less or equal to 20!");
                }
            }
        }

        public int Pieces { get; set; }

        public bool Ecc { get; set; }

        public bool Rgb { get; set; }

        internal RAMGeneration RamGeneration
        {
            get => ramGeneration;
            set
            {
                if (value == RAMGeneration.DDR)
                {
                    if (latency <= 3)
                    {
                        ramGeneration = value;
                    }
                    else
                    {
                        throw new ArgumentException("DDR RAM can't have more than 3 latency!");
                    }
                }
                else if (value == RAMGeneration.DDR2)
                {
                    if (latency >= 3 && latency <= 6)
                    {
                        ramGeneration = value;
                    }
                    else
                    {
                        throw new ArgumentException("DDR2 RAM can't have less than 3 and more than 6 latency!");
                    }
                }
                else if (value == RAMGeneration.DDR3)
                {
                    if (latency >= 5 && latency <= 16)
                    {
                        ramGeneration = value;
                    }
                    else
                    {
                        throw new ArgumentException("DDR3 RAM can't have less than 5 and more than 16 latency!");
                    }
                }
                else
                {
                    if (latency >= 10 && latency <= 19)
                    {
                        ramGeneration = value;
                    }
                    else
                    {
                        throw new ArgumentException("DDR4 RAM can't have less than 10 and more than 19 latency!");
                    }
                }
            }
        }

        public RAM(string manufacturer, string productsName, string serialNumber, int price, DateTime dateOfPurchase, DateTime dateOfAdd, DateTime warranty, string text, RAMGeneration ramGeneration, int size, int frequency, int latency, int pieces, bool ecc, bool rgb) : base(manufacturer, productsName, serialNumber, price, dateOfPurchase, dateOfAdd, warranty, text)
        {
            Latency = latency;
            RamGeneration = ramGeneration;
            Size = size;
            Frequency = frequency;
            Pieces = pieces;
            Ecc = ecc;
            Rgb = rgb;
        }

        public override string ToString()
        {
            return base.ToString() + $"{ramGeneration} {Size} {frequency}";
        }
    }
}
