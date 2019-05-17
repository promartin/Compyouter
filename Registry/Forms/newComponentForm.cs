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
using Registry.Classes.Components.Case;

namespace Registry.Forms
{
    public partial class newComponentForm : Form
    {
        internal static Components newComponent;
        public static Components NewComponent
        {
            get => newComponent;
            set => newComponent = value;
        }

        public newComponentForm()
        {
            InitializeComponent();
            dateOfPurchaseTimePicker.Value = DateTime.Today;
            warrantyTimePicker.Value = DateTime.Today;

            caseGroupBox.Show();
            caseFormFactorComboBox.DisplayMember = "Description";
            caseFormFactorComboBox.ValueMember = "Value";
            caseFormFactorComboBox.DataSource = Enum.GetValues(typeof(CaseFormFactor))
                .Cast<Enum>()
                .Select(value => new
                {
                    (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                    value
                })
                .OrderBy(item => item.value)
                .ToList();
        }

        public newComponentForm(Components modificate)
        {
            InitializeComponent();
            newComponent = modificate;
            maufacturerTextBox.Text = newComponent.Manufacturer;
            productNameTextBox.Text = newComponent.ProductsName;
            priceNumericUpDown.Value = newComponent.Price;
            serialNumberTextBox.Text = newComponent.SerialNumber;
            dateOfPurchaseTimePicker.Value = newComponent.DateOfPurchase;
            textBox.Text = newComponent.Text;
            if (newComponent.Warranty < DateTime.Now)
            {
                warrantyTimePicker.Value = new DateTime(1753, 01, 01);
                label8.Text = "There were no warranty!";
            }
            else
            {
                warrantyTimePicker.Value = (DateTime)newComponent.Warranty;
            }
            if (modificate is Case)
            {
                caseGroupBox.Show();

                caseFormFactorComboBox.DisplayMember = "Description";
                caseFormFactorComboBox.ValueMember = "Value";
                caseFormFactorComboBox.DataSource = Enum.GetValues(typeof(CaseFormFactor))
                    .Cast<Enum>()
                    .Select(value => new
                    {
                        (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                        value
                    })
                    .OrderBy(item => item.value)
                    .ToList();

                bottomSupplyCheckBox.Checked = (newComponent as Case).BottomSupply;
                caseFormFactorComboBox.SelectedIndex = (int)(newComponent as Case).CaseFormFactor;
                atx.Checked = (newComponent as Case).Atx;
                eatx.Checked = (newComponent as Case).Eatx;
                microATX.Checked = (newComponent as Case).MicroATX;
                miniITX.Checked = (newComponent as Case).MiniITX;
                miniSTX.Checked = (newComponent as Case).MiniSTX;
                thinMiniITX.Checked = (newComponent as Case).ThinMiniITX;
                noOf35NumericUpDown.Value = (decimal)(newComponent as Case).HddSpace;
                noOf25NumericUpDown.Value = (decimal)(newComponent as Case).SlimHDDspace;
                cpuHeatsinkHeightNumericUpDown.Value = (newComponent as Case).CpuHeatSinkHeight;
                videoCardLengthNumericUpDown.Value = (newComponent as Case).VideoCardLength;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (maufacturerTextBox.Text.Trim() != "")
            {
                if (productNameTextBox.Text.Trim() != "")
                {
                    try
                    {
                        newComponent = new Case(maufacturerTextBox.Text, productNameTextBox.Text, serialNumberTextBox.Text, (int)priceNumericUpDown.Value, dateOfPurchaseTimePicker.Value, DateTime.Now, warrantyTimePicker.Value, textBox.Text, bottomSupplyCheckBox.Checked, (CaseFormFactor)caseFormFactorComboBox.SelectedIndex, atx.Checked, eatx.Checked, microATX.Checked, miniITX.Checked, miniSTX.Checked, thinMiniITX.Checked, (int)noOf35NumericUpDown.Value, (int)noOf25NumericUpDown.Value, (int)cpuHeatsinkHeightNumericUpDown.Value, (int)videoCardLengthNumericUpDown.Value);
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
