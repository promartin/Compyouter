using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Registry.Classes.Components.PowerSupply
{
    enum FormFactor
    {
        TFX,
        SFX
    }

    enum Efficency
    {
        [Description("80+")]
        PLUS80,
        [Description("80+ BRONZE")]
        BRONZE80,
        [Description("80+ SILVER")]
        SILVER80,
        [Description("80+ GOLD")]
        GOLD80,
        [Description("80+ PLATINUM")]
        PLATINUM80,
        [Description("80+ TITANIUM")]
        TITANIUM80
    }

    class PowerSupply : Components
    {
        public int Output { get; set; }

        public int Sata { get; set; }

        public int Molex { get; set; }

        public bool Modular { get; set; }

        internal FormFactor FormFactor { get; set; }

        internal Efficency Efficency { get; set; }

        public int Pcie { get; set; }

        public PowerSupply(string manufacturer, string productsName, string serialNumber, int price, DateTime dateOfPurchase, DateTime dateOfAdd, DateTime warranty, string text, int output, Efficency efficency, int sata, int pcie, int molex, bool modular, FormFactor formFactor) : base(manufacturer, productsName, serialNumber, price, dateOfPurchase, dateOfAdd, warranty, text)
        {
            Output = output;
            Efficency = efficency;
            Sata = sata;
            Pcie = pcie;
            Molex = molex;
            Modular = modular;
            FormFactor = formFactor;
        }
    }
}
