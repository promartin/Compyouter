using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Registry.Classes.Components;
using Registry.Classes.Components.Storages;

namespace Registry.Forms
{
    public partial class newStorageForm : Form
    {
        enum Type
        {
            HDD,
            SSD
        }

        internal static Components newComponent;
        public static Components NewComponent
        {
            get => newComponent;
            set => newComponent = value;
        }

        public newStorageForm(Components modification)
        {
            InitializeComponent();
            dateOfPurchaseTimePicker.Value = DateTime.Today;
            warrantyTimePicker.Value = DateTime.Today;
            newComponent = modification;
            manufacturerTextBox.Text = newComponent.Manufacturer;
            productNameTextBox.Text = newComponent.ProductsName;
            serialNumberTextBox.Text = newComponent.SerialNumber;
            priceNumericUpDown.Value = newComponent.Price;
            serialNumberTextBox.Text = newComponent.SerialNumber;
            dateOfPurchaseTimePicker.Value = newComponent.DateOfPurchase;
            textBox.Text = newComponent.Text;
            if (newComponent.Warranty < DateTime.Now)
            {
                warrantyTimePicker.Value = new DateTime(1753, 01, 01);
                label8.Text = "There is no warranty!";
            }
            else
            {
                warrantyTimePicker.Value = (DateTime)newComponent.Warranty;
            }

            connectorComboBox2.DisplayMember = "Description";
            connectorComboBox2.ValueMember = "Value";
            connectorComboBox2.DataSource = Enum.GetValues(typeof(ConnectorType))
                .Cast<Enum>()
                .Select(value => new
                {
                    (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                    value
                })
                .OrderBy(item => item.value)
                .ToList();
            connectorComboBox2.SelectedIndex = (int)(modification as Storage).ConnectorType;

            sizeComboBox3.DisplayMember = "Description";
            sizeComboBox3.ValueMember = "Value";
            sizeComboBox3.DataSource = Enum.GetValues(typeof(StorageSize))
                .Cast<Enum>()
                .Select(value => new
                {
                    (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                    value
                })
                .OrderBy(item => item.value)
                .ToList();
            sizeComboBox3.SelectedIndex = (int) (modification as Storage).size;
            typeComboBox1.DataSource = Enum.GetValues(typeof(Type));
            conditionNumericUpDown2.Value = (modification as Storage).Condition;

            if (modification is HDD)
            {
                typeComboBox1.SelectedItem = Type.HDD;
                typeComboBox1.Enabled = false;
                rpmNumericUpDown2.Value = (modification as HDD).Rpm;
                cacheNumericUpDown1.Value = (modification as HDD).BufferSize;
            }
            else
            {
                typeComboBox1.SelectedItem = Type.SSD;
                typeComboBox1.Enabled = false;
                writeSpeedNumericUpDown1.Value = (modification as SSD).WriteSpeed;
                readSpeedNumericUpDown2.Value = (modification as SSD).ReadSpeed;
                technologyComboBox.DataSource = Enum.GetValues(typeof(Technology));
                technologyComboBox.SelectedIndex = (int)(modification as SSD).Technology;
            }
        }

        public newStorageForm()
        {
            InitializeComponent();
            connectorComboBox2.DisplayMember = "Description";
            connectorComboBox2.ValueMember = "Value";
            connectorComboBox2.DataSource = Enum.GetValues(typeof(ConnectorType))
                .Cast<Enum>()
                .Select(value => new
                {
                    (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                    value
                })
                .OrderBy(item => item.value)
                .ToList();

            sizeComboBox3.DisplayMember = "Description";
            sizeComboBox3.ValueMember = "Value";
            sizeComboBox3.DataSource = Enum.GetValues(typeof(StorageSize))
                .Cast<Enum>()
                .Select(value => new
                {
                    (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                    value
                })
                .OrderBy(item => item.value)
                .ToList();

            technologyComboBox.DataSource = Enum.GetValues(typeof(Technology));
            typeComboBox1.DataSource = Enum.GetValues(typeof(Type));
        }

        private void typeComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((Type)typeComboBox1.SelectedItem)
            {
                case Type.HDD:
                    hddGroupBox1.Show();
                    ssdGroupBox.Hide();
                    break;
                case Type.SSD:
                    hddGroupBox1.Hide();
                    ssdGroupBox.Show();
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (productNameTextBox.Text.Trim() != "")
            {
                try
                {
                    if ((Type)typeComboBox1.SelectedItem == Type.HDD)
                    {
                        newComponent = new HDD(manufacturerTextBox.Text, productNameTextBox.Text, serialNumberTextBox.Text, (int)priceNumericUpDown.Value, dateOfPurchaseTimePicker.Value, DateTime.Now, warrantyTimePicker.Value, textBox.Text, (int)storageSizenumericUpDown1.Value, (ConnectorType)connectorComboBox2.SelectedIndex, (int)conditionNumericUpDown2.Value, (StorageSize)sizeComboBox3.SelectedIndex, (int)rpmNumericUpDown2.Value, (int)cacheNumericUpDown1.Value);
                    }
                    else
                    {
                        newComponent = new SSD(manufacturerTextBox.Text, productNameTextBox.Text, serialNumberTextBox.Text, (int)priceNumericUpDown.Value, dateOfPurchaseTimePicker.Value, DateTime.Now, warrantyTimePicker.Value, textBox.Text, (int)storageSizenumericUpDown1.Value, (ConnectorType)connectorComboBox2.SelectedIndex, (int)conditionNumericUpDown2.Value, (StorageSize)sizeComboBox3.SelectedIndex, (int)writeSpeedNumericUpDown1.Value, (int)readSpeedNumericUpDown2.Value, (Technology)technologyComboBox.SelectedIndex);
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DialogResult = DialogResult.None;
                }

            }
            else
            {
                MessageBox.Show("The product's name must be filled!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.None;

            }
        }
    }
}
