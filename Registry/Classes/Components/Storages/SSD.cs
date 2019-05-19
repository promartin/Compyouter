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
        public int WriteSpeed { get; set; }

        public int ReadSpeed { get; set; }

        internal Technology Technology { get; set; }

        public SSD(string manufacturer, string productsName, string serialNumber, int price, DateTime dateOfPurchase, DateTime dateOfAdd, DateTime warranty, string text, int gb, ConnectorType connectorType, int condition, StorageSize size, int writeSpeed, int readSpeed, Technology technology) : base(manufacturer, productsName, serialNumber, price, dateOfPurchase, dateOfAdd, warranty, text, gb, connectorType, condition, size)
        {
            WriteSpeed = writeSpeed;
            ReadSpeed = readSpeed;
            Technology = technology;
        }
    }
}
