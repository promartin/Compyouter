using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registry.Classes.Components.Cooler
{

    class Cooler : Components
    {
        private bool lga1151;
        private bool lga2066;
        private bool lga2011;
        private bool lga1366;
        private bool lga775;
        private bool fm122plus3plus;
        private bool am4;
        private bool aM22plus33plus;
        private bool tr4;
        private int height;

        public bool Lga1151
        {
            get => lga1151;
            set => lga1151 = value;
        }

        public bool Lga2066
        {
            get => lga2066;
            set => lga2066 = value;
        }

        public bool Lga2011
        {
            get => lga2011;
            set => lga2011 = value;
        }

        public bool Lga1366
        {
            get => lga1366;
            set => lga1366 = value;
        }

        public bool Lga775
        {
            get => lga775;
            set => lga775 = value;
        }

        public bool Fm122plus3plus
        {
            get => fm122plus3plus;
            set => fm122plus3plus = value;
        }

        public bool Am4
        {
            get => am4;
            set => am4 = value;
        }

        public bool AM22plus33plus
        {
            get => aM22plus33plus;
            set => aM22plus33plus = value;
        }

        public bool Tr4
        {
            get => tr4;
            set => tr4 = value;
        }

        public int Height
        {
            get => height;
            set
            {
                if (value >= 20 && value <= 500)
                {
                    height = value;
                }
                else
                {
                    throw new ArgumentException("The cooler's height has to be bewtween 20mm to 500mm!");
                }
            }
        }

        public Cooler(string manufacturer, string productsName, string serialNumber, int price, DateTime dateOfPurchase, DateTime dateOfAdd, DateTime warranty, string text, bool lga1151, bool lga2066, bool lga2011, bool lga1366, bool lga775, bool fm122Plus3Plus, bool am4, bool aM22Plus33Plus, bool tr4, int height) : base(manufacturer, productsName, serialNumber, price, dateOfPurchase, dateOfAdd, warranty, text)
        {
            Lga1151 = lga1151;
            Lga2066 = lga2066;
            Lga2011 = lga2011;
            Lga1366 = lga1366;
            Lga775 = lga775;
            Fm122plus3plus = fm122Plus3Plus;
            Am4 = am4;
            AM22plus33plus = aM22Plus33Plus;
            Tr4 = tr4;
            Height = height;
        }
    }
}
