using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registry.Classes.Components.Storages
{
    enum Technology
    {
        SLC,
        TLC,
        MLC,
        QLC
    }

    class SSD : Storage
    {
        private int writeSpeed;
        private int readSpeed;
        private Technology technology;

        public int WriteSpeed
        {
            get => writeSpeed;
            set => writeSpeed = value;
        }

        public int ReadSpeed
        {
            get => readSpeed;
            set => readSpeed = value;
        }

        internal Technology Technology
        {
            get => technology;
            set => technology = value;
        }
        public SSD(string manufacturer, string productsName, string serialNumber, int price, DateTime dateOfPurchase, DateTime dateOfAdd, DateTime warranty, string text, int gb, ConnectorType connectorType, int condition, StorageSize size, int writeSpeed, int readSpeed, Technology technology) : base(manufacturer, productsName, serialNumber, price, dateOfPurchase, dateOfAdd, warranty, text, gb, connectorType, condition, size)
        {
            WriteSpeed = writeSpeed;
            ReadSpeed = readSpeed;
            Technology = technology;
        }
    }
}
