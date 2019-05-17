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
using Registry.Classes.Components.PowerSupply;

namespace Registry.Forms
{
    public partial class newPowerSupplyForm : Form
    {
        internal static Components newComponent;

        public static Components NewComponent
        {
            get => newComponent;
            set => newComponent = value;
        }

        public newPowerSupplyForm()
        {
            InitializeComponent();
            dateOfPurchaseTimePicker.Value = DateTime.Today;
            warrantyTimePicker.Value = DateTime.Today;

            formFactorComboBox2.DataSource = Enum.GetValues(typeof(FormFactor));

            efficencyComboBox1.DisplayMember = "Description";
            efficencyComboBox1.ValueMember = "Value";
            efficencyComboBox1.DataSource = Enum.GetValues(typeof(Efficency))
                .Cast<Enum>()
                .Select(value => new
                {
                    (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()),
                        typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                    value
                })
                .OrderBy(item => item.value)
                .ToList();
        }

        public newPowerSupplyForm(Components modification)
        {
            InitializeComponent();
            dateOfPurchaseTimePicker.Value = DateTime.Today;
            warrantyTimePicker.Value = DateTime.Today;

            formFactorComboBox2.DataSource = Enum.GetValues(typeof(FormFactor));

            efficencyComboBox1.DisplayMember = "Description";
            efficencyComboBox1.ValueMember = "Value";
            efficencyComboBox1.DataSource = Enum.GetValues(typeof(Efficency))
                .Cast<Enum>()
                .Select(value => new
                {
                    (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()),
                        typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
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
                warrantyTimePicker.Value = new DateTime(1973, 1, 1);
                label8.Text = "There is no warranty!";
            }
            else
            {
                warrantyTimePicker.Value = (DateTime)newComponent.Warranty;
            }

            formFactorComboBox2.SelectedIndex = (int)(newComponent as PowerSupply).FormFactor;
            efficencyComboBox1.SelectedIndex = (int)(newComponent as PowerSupply).Efficency;
            outputNumericUpDown1.Value = (newComponent as PowerSupply).Output;
            sataNumericUpDown1.Value = (newComponent as PowerSupply).Sata;
            molexNumericUpDown3.Value = (newComponent as PowerSupply).Molex;
            pcieNumericUpDown2.Value = (newComponent as PowerSupply).Pcie;
            checkBox1.Checked = (newComponent as PowerSupply).Modular;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (manufacturerTextBox.Text.Trim() != "")
            {
                if (productNameTextBox.Text.Trim() != "")
                {
                    try
                    {
                        newComponent = new PowerSupply(manufacturerTextBox.Text, productNameTextBox.Text, serialNumberTextBox.Text, (int)priceNumericUpDown.Value, dateOfPurchaseTimePicker.Value, DateTime.Now, warrantyTimePicker.Value, textBox.Text, (int)outputNumericUpDown1.Value, (Efficency)efficencyComboBox1.SelectedIndex, (int)sataNumericUpDown1.Value, (int)pcieNumericUpDown2.Value, (int)molexNumericUpDown3.Value, checkBox1.Checked, (FormFactor)formFactorComboBox2.SelectedIndex);
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
