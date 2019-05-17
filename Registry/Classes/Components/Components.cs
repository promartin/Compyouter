using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Registry.Classes.Components.Storages;

namespace Registry.Classes.Components
{
    public abstract class Components
    {
        private string manufacturer;
        private string productName;
        private int price;
        private string serialNumber;
        private DateTime dateOfPurchase;
        private DateTime dateOfAdd;
        private DateTime warranty;
        private string text;

        public string Manufacturer
        {
            get => manufacturer;
            set
            {
                if (value != "")
                {
                    manufacturer = value;
                }
                else
                {
                    throw new ArgumentException("The component must have a manufacturer!");
                }

            }
        }

        public string ProductsName
        {
            get => productName;
            set
            {
                if (value != "")
                {
                    productName = value;
                }
                else
                {
                    throw new ArgumentException("The component must have a name!");
                }
            }
        }

        public int Price
        {
            get => price;
            set
            {
                if (value >= 0)
                {
                    price = value;
                }
                else
                {
                    throw new ArgumentException("The component must have a price!");
                }
            }
        }

        public string SerialNumber
        {
            get => serialNumber;
            set => serialNumber = value;
        }

        public DateTime DateOfPurchase
        {
            get => dateOfPurchase;
            set => dateOfPurchase = value;
        }

        public DateTime DateOfAdd
        {
            get => dateOfAdd;
            set => dateOfAdd = value;
        }

        public DateTime Warranty
        {
            get => warranty;
            set
            {
                try
                {
                    if (DateOfPurchase <= value)
                    {
                        warranty = value;
                    }
                    else
                    {
                        warranty = new DateTime(2000, 01, 01);
                    }
                }
                catch (Exception e)
                {
                    //Save warrantyException into settings
                    if (MessageBox.Show(e.Message + "Would you like me to delete the warranty of every component, which warranty's expired? You can later disable it in Settings!", "Warranty error!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Retry)
                    {
                        Properties.Settings.Default.Save();
                        warranty = new DateTime(1976, 10, 10);
                    }
                }

            }
        }

        public string Text
        {
            get => text;
            set => text = value;
        }

        protected Components(string manufacturer, string productsName, string serialNumber, int price, DateTime dateOfPurchase, DateTime dateOfAdd, DateTime warranty, string text)
        {
            Manufacturer = manufacturer;
            ProductsName = productsName;
            SerialNumber = serialNumber;
            Price = price;
            DateOfPurchase = dateOfPurchase;
            DateOfAdd = dateOfAdd;
            Warranty = warranty;
            Text = text;
        }
    }
}
