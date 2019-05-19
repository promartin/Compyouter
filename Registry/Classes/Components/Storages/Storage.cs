using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registry.Classes.Components.Storages
{
    enum ConnectorType
    {
        [Description("SATA 3")]
        SATA3,
        [Description("mSATA")]
        mSATA,
        [Description("M.2")]
        m2,
    }

    enum StorageSize
    {
        [Description("2.5\"")]
        h25,
        [Description("3.5\"")]
        h35,
        [Description("mSATA")]
        mSATA,
        [Description("M.2 22110")]
        m222110,
        [Description("M.2 2242")]
        m22242,
        [Description("M.2 2260")]
        m22260,
        [Description("M.2 2280")]
        m22280
    }

    abstract class Storage : Components
    {
        private ConnectorType connectorType;
        private StorageSize Size;

        public int Gb { get; set; }

        public int Condition { get; set; }

        internal ConnectorType ConnectorType
        {
            get => connectorType;
            set
            {
                if (value == ConnectorType.SATA3 || (value == ConnectorType.m2 && this.GetType() == typeof(SSD)))
                {
                    connectorType = value;
                }
                else if (value == ConnectorType.m2 && this.GetType() == typeof(HDD))
                {
                    throw new ArgumentException("A HDD can't have an M.2 connector!");
                }
                else
                {
                    throw new ArgumentException("You must choose the correct connector type for the internal/external storage!");
                }
            }
        }

        internal StorageSize size
        {
            get => Size;
            set
            {
                switch (ConnectorType)
                {
                    case ConnectorType.mSATA:
                        if (value == StorageSize.h25 || value == StorageSize.h35)
                        {
                            Size = value;
                        }
                        else
                        {
                            throw new ArgumentException("Choose the correct Size for the corresponding connector type!");
                        }
                        break;
                    case ConnectorType.SATA3:
                        if (value == StorageSize.h25 || value == StorageSize.h35)
                        {
                            Size = value;
                        }
                        else
                        {
                            throw new ArgumentException("Choose the correct Size for the corresponding connector type!");
                        }
                        break;
                    case ConnectorType.m2:
                        if (value == StorageSize.m222110 || value == StorageSize.m22242 || value == StorageSize.m22260 || value == StorageSize.m22280)
                        {
                            Size = value;
                        }
                        else
                        {
                            throw new ArgumentException("Choose the correct Size for the corresponding connector type!");
                        }
                        break;
                }
            }
        }

        protected Storage(string manufacturer, string productsName, string serialNumber, int price, DateTime dateOfPurchase, DateTime dateOfAdd, DateTime warranty, string text, int gb, ConnectorType connectorType, int condition, StorageSize size) : base(manufacturer, productsName, serialNumber, price, dateOfPurchase, dateOfAdd, warranty, text)
        {
            Gb = gb;
            Condition = condition;
            ConnectorType = connectorType;
            Size = size;
        }
    }
}
