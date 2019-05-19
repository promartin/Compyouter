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
        private int height;

        public bool Lga1151 { get; set; }

        public bool Lga2066 { get; set; }

        public bool Lga2011 { get; set; }

        public bool Lga1366 { get; set; }

        public bool Lga775 { get; set; }

        public bool Fm122plus3plus { get; set; }

        public bool Am4 { get; set; }

        public bool AM22plus33plus { get; set; }

        public bool Tr4 { get; set; }

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
