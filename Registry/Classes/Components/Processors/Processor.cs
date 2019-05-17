using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Registry.Classes.Components;

namespace Registry.Classes.Components
{

    abstract class Processor : Components
    {
        private double l2Cache;
        private double l3Cache;
        private int cores;
        private int threads;
        private int process;
        private int frequency;
        private int turboFrequency;
        private int tdp;

        public double L2Cache
        {
            get => l2Cache;
            set
            {
                if (value > 0 && value <= 64)
                {
                    l2Cache = value;
                }
                else
                {
                    throw new ArgumentException("L2 chache can't be less than 0MB and can't be more than 64MB!");
                }
            }
        }

        public double L3Cache
        {
            get => l3Cache;
            set
            {
                if (value > 0 && value <= 128)
                {
                    l3Cache = value;
                }
                else
                {
                    throw new ArgumentException("L3 chache can't be less than 0MB and can't be more than 128MB!");
                }
            }
        }

        public int Cores
        {
            get => cores;
            set
            {
                if (value >= 1 && value <= 32)
                {
                    cores = value;
                }
                else
                {
                    throw new ArgumentException("Core number can't be less than 1 and can't be more than 32!");
                }
            }
        }

        public int Threads
        {
            get => threads;
            set
            {
                if (value >= 1 && value <= 64)
                {
                    threads = value;
                }
                else
                {
                    throw new ArgumentException("Thread number can't be less than 1 and can't be more than 64!");
                }
            }
        }

        public int Process
        {
            get => process;
            set
            {
                if (value >= 12 && value <= 32)
                {
                    process = value;
                }
                else
                {
                    throw new ArgumentException("Lithography can't be less than 12nm and can't be more than 32nm!");
                }
            }
        }

        public int Frequency
        {
            get => frequency;
            set
            {
                if (value >= 800 && value <= 8000)
                {
                    frequency = value;
                }
                else
                {
                    throw new ArgumentException("The frequency can't be less than 800 MHz and can't be more than 8000 MHz");
                }
            }
        }

        public int TurboFrequency
        {
            get => turboFrequency;
            set
            {
                if (value >= frequency)
                {
                    turboFrequency = value;
                }
                else
                {
                    throw new ArgumentException("The turbo frequency needs to be more than 800 MHz and has to be less or equal to 9000 MHz");
                }
            }
        }

        public int Tdp
        {
            get => tdp;
            set
            {
                if (value >= 4 && value <= 140)
                {
                    tdp = value;
                }
                else
                {
                    throw new ArgumentException("The CPU TDP must be more or equal to 4W but be less than 140W!");
                }

            }
        }

        protected Processor(string manufacturer, string productsName, string serialNumber, int price, DateTime dateOfPurchase, DateTime dateOfAdd, DateTime warranty, string text, double l2Cache, double l3Cache, int cores, int threads, int process, int frequency, int turboFrequency, int tdp) : base(manufacturer, productsName, serialNumber, price, dateOfPurchase, dateOfAdd, warranty, text)
        {
            L2Cache = l2Cache;
            L3Cache = l3Cache;
            Cores = cores;
            Threads = threads;
            Process = process;
            Frequency = frequency;
            TurboFrequency = turboFrequency;
            Tdp = tdp;
        }

        public override string ToString()
        {
            return base.ToString() + $" {l2Cache} {l3Cache} {cores} {threads} {process} {frequency} {turboFrequency}";
        }
    }
}
