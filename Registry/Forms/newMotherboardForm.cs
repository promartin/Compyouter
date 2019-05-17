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
using Registry.Classes.Components.Motherboard;

namespace Registry.Forms
{
    public partial class newMotherboardForm : Form
    {
        internal static Components newComponent;
        public static Components NewComponent
        {
            get => newComponent;
            set => newComponent = value;
        }

        public newMotherboardForm()
        {
            InitializeComponent();
            dateOfPurchaseTimePicker.Value = DateTime.Today;
            warrantyTimePicker.Value = DateTime.Today;

            formFactorComboBox.DisplayMember = "Description";
            formFactorComboBox.ValueMember = "Value";
            formFactorComboBox.DataSource = Enum.GetValues(typeof(FormFactor))
                .Cast<Enum>()
                .Select(value => new
                {
                    (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                    value
                })
                .OrderBy(item => item.value)
                .ToList();

            socketComboBox.DisplayMember = "Description";
            socketComboBox.ValueMember = "Value";
            socketComboBox.DataSource = Enum.GetValues(typeof(Socket))
                .Cast<Enum>()
                .Select(value => new
                {
                    (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                    value
                })
                .OrderBy(item => item.value)
                .ToList();

            memoryComboBox.DisplayMember = "Description";
            memoryComboBox.ValueMember = "Value";
            memoryComboBox.DataSource = Enum.GetValues(typeof(MemoryGeneration))
                .Cast<Enum>()
                .Select(value => new
                {
                    (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                    value
                })
                .OrderBy(item => item.value)
                .ToList();
        }

        public newMotherboardForm(Components modification)
        {
            InitializeComponent();
            dateOfPurchaseTimePicker.Value = DateTime.Today;
            warrantyTimePicker.Value = DateTime.Today;

            formFactorComboBox.DisplayMember = "Description";
            formFactorComboBox.ValueMember = "Value";
            formFactorComboBox.DataSource = Enum.GetValues(typeof(FormFactor))
                .Cast<Enum>()
                .Select(value => new
                {
                    (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                    value
                })
                .OrderBy(item => item.value)
                .ToList();

            socketComboBox.DisplayMember = "Description";
            socketComboBox.ValueMember = "Value";
            socketComboBox.DataSource = Enum.GetValues(typeof(Socket))
                .Cast<Enum>()
                .Select(value => new
                {
                    (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                    value
                })
                .OrderBy(item => item.value)
                .ToList();

            memoryComboBox.DisplayMember = "Description";
            memoryComboBox.ValueMember = "Value";
            memoryComboBox.DataSource = Enum.GetValues(typeof(MemoryGeneration))
                .Cast<Enum>()
                .Select(value => new
                {
                    (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                    value
                })
                .OrderBy(item => item.value)
                .ToList();

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

            formFactorComboBox.SelectedIndex = (int)(newComponent as Motherboard).FormFactor;
            socketComboBox.SelectedIndex = (int)(newComponent as Motherboard).Socket;
            memoryComboBox.SelectedIndex = (int)(newComponent as Motherboard).MemoryGeneration;
            checkBox1.Checked = (newComponent as Motherboard).Crossfire;
            checkBox2.Checked = (newComponent as Motherboard).Sli;
            checkBox7.Checked = (newComponent as Motherboard).Bluetooth;
            checkBox8.Checked = (newComponent as Motherboard).Wifi;
            numericUpDown2.Value = (newComponent as Motherboard).M2x4Number;
            numericUpDown3.Value = (newComponent as Motherboard).MemorySlots;
            numericUpDown4.Value = (newComponent as Motherboard).MaxMemorySize;
            numericUpDown5.Value = (newComponent as Motherboard).PciE_x16_Slots;
            numericUpDown6.Value = (newComponent as Motherboard).PciE_x4_Slots;
            numericUpDown7.Value = (newComponent as Motherboard).PciE_x1_Slots;
            numericUpDown9.Value = (newComponent as Motherboard).Sata3Connectors;
            numericUpDown11.Value = (newComponent as Motherboard).Usb30;
            numericUpDown12.Value = (newComponent as Motherboard).Usb31;
            numericUpDown13.Value = (newComponent as Motherboard).Lan;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (manufacturerTextBox.Text.Trim() != "")
            {
                if (productNameTextBox.Text.Trim() != "")
                {
                    try
                    {
                        newComponent = new Motherboard(manufacturerTextBox.Text, productNameTextBox.Text, serialNumberTextBox.Text, (int)priceNumericUpDown.Value, dateOfPurchaseTimePicker.Value, DateTime.Now, warrantyTimePicker.Value, textBox.Text, (FormFactor)formFactorComboBox.SelectedIndex, (Socket)socketComboBox.SelectedIndex, (MemoryGeneration)memoryComboBox.SelectedIndex, checkBox1.Checked, checkBox2.Checked, checkBox7.Checked, checkBox8.Checked, (int)numericUpDown2.Value, (int)numericUpDown3.Value, (int)numericUpDown4.Value, (int)numericUpDown5.Value, (int)numericUpDown6.Value, (int)numericUpDown7.Value, (int)numericUpDown9.Value, (int)numericUpDown11.Value, (int)numericUpDown12.Value, (int)numericUpDown13.Value);
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
            else
            {
                MessageBox.Show("The manufacturer's text has to be filled!", "Warning!", MessageBoxButtons.OK);
                DialogResult = DialogResult.None;
            }
        }
    }
}
