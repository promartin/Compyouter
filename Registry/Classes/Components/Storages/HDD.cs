using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registry.Classes.Components.Storages
{
    class HDD : Storage
    {
        private int rpm;
        private int bufferSize;

        public int Rpm
        {
            get => rpm;
            set => rpm = value;
        }

        public int BufferSize
        {
            get => bufferSize;
            set => bufferSize = value;
        }

        public HDD(string manufacturer, string productsName, string serialNumber, int price, DateTime dateOfPurchase, DateTime dateOfAdd, DateTime warranty, string text, int gb, ConnectorType connectorType, int condition, StorageSize size, int rpm, int bufferSize) : base(manufacturer, productsName, serialNumber, price, dateOfPurchase, dateOfAdd, warranty, text, gb, connectorType, condition, size)
        {
            Rpm = rpm;
            BufferSize = bufferSize;
        }

    }
}
