using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;
using Registry.Classes;
using Registry.Classes.Components;
using Registry.Classes.Components.Case;
using Registry.Classes.Components.Cooler;
using Registry.Classes.Components.Motherboard;
using Registry.Classes.Components.PowerSupply;
using Registry.Classes.Components.Processors;
using Registry.Classes.Components.RAM;
using Registry.Classes.Components.Storages;
using Registry.Classes.Components.Videocard;
using Registry.Classes.Computer;
using Registry.Database.Config;
using Registry.Forms;
using Registry.Properties;
using FormFactor = Registry.Classes.Components.Motherboard.FormFactor;
using User = Registry.Classes.Users.User;


namespace Registry
{
    public partial class Form1 : Form
    {
        //Enum for our comboBox on the main form
        enum ComponentsName
        {
            [Description("Case")] Case,
            [Description("Motherboard")] Motherboard,
            [Description("Processor")] Processor,
            [Description("RAM")] RAM,
            [Description("Video card")] VideoCard,
            [Description("Cooler")] Cooler,
            [Description("Power Supply")] PowerSupply,
            [Description("Storage")] Storage
        }

        enum SortBy
        {
            [Description("Price: Low to high")] PriceUp,
            [Description("Price: High to low")] PriceDown,
            [Description("Date bought: New to old")] DateDown,
            [Description("Date bought: Old to new")] DateUp,
            [Description("Date added: New to Old")] AddedDown,
            [Description("Date added: Old to new")] AddedUp
        }

        private static User user;

        //Static variables that helps us out
        private static List<Components> componentList;
        private static int componentCount = 0;
        private static List<Computer> computerList;
        private static Image[] buttonImages;
        private static Button[] menuButtons;
        private static Image[] goldenMenuButtons;
        private static Control[] searchTextBoxes;
        private static List<MyButton> savedFlowLayoutPanelControls;

        private static List<MyButton> buttons = new List<MyButton>();
        private static bool warrantyWarningRed = true;
        private static Button lastClickedButton;


        //Needed when building a new computer (Create computer region)
        private static int quantity;
        private static int? numberOfSelectedButtons;
        private static Case selectedCase;
        private static Cooler selectedCooler;
        private static Motherboard selectedMotherboard;
        private static PowerSupply selectedPowerSupply;
        private static Processor selectedProcessor;
        private static List<RAM> selectedRAM = new List<RAM>();
        private static List<HDD> selectedHDD = new List<HDD>();
        private static List<SSD> selectedSSD = new List<SSD>();
        private static List<Videocard> selectedVideocard = new List<Videocard>();
        private static Computer createdComputer;

        public Form1(User loggedInUser)
        {
            InitializeComponent();
            user = loggedInUser;
            //initializing everything we need

            //Images for the buttons on flowlayout
            buttonImages = new Image[]
            {
                Resources.caseIconWarranty, Resources.caseIconRed, Resources.caseIcon, Resources.motherboardIconWarranty, Resources.motherboardIconRed, Resources.motherboardIcon, Resources.cpuIconWarranty, Resources.cpuIconRed, Resources.cpuIcon, Resources.ramIconWarranty, Resources.ramIconRed, Resources.ramIcon, Resources.videoCardIconWarranty, Resources.videoCardIconRed, Resources.videoCardIcon, Resources.coolerIconWarranty, Resources.coolerIconRed, Resources.coolerIcon, Resources.powerSupplyIconWarranty, Resources.powerSupplyIconRed, Resources.powerSupplyIcon, Resources.hddIconWarranty, Resources.hddIconRed, Resources.hddIcon, Resources.ssdIconWarranty, Resources.ssdIconWarranty, Resources.ssdIcon, Resources.desktop_computer
            };

            //Goldenbuttons when we highlight the selected menuButton
            goldenMenuButtons = new Image[]
            {
                Resources.everything_50px_gold, Resources.case_gold_50px, Resources.cooling_fan_gold_50px, Resources.motherboard_gold_50px, Resources.power_gold_50px, Resources.cpu_gold_50px, Resources.ram_gold_50px, Resources.hard_drive_gold_50px, Resources.video_card_gold_50px, Resources.desktop_computer_gold_50px
            };

            //Putting the menu buttons into an array, to work with them more easily
            menuButtons = new Button[]
            {
                everythingButton, casesButton, coolersButton, motherboardsButton, powerSuppliesButton, processorsButton, memoriesButton, storagesButton, videocardsButton, computersButton
            };

            //Doing the same with the search text boxes
            searchTextBoxes = new Control[]
            {
                productSearchTextBox, manufacturerSearchTextBox, serialSearchTextBox, textSearchTextBox
            };

            componentList = DBManager.Read(user);
            componentCount = componentList.Count;
            computerList = new List<Computer>();
            if (loggedInUser != null)
            {
                userLabel.Text = loggedInUser.UserName + " " + loggedInUser.UserId;
            }
            checkBox1.Hide();



            for (int i = 0; i < menuButtons.Length; i++)
            {
                menuButtons[i].Click += HighLightSelectedMenuButton;
            }

            for (int i = 0; i < searchTextBoxes.Length; i++)
            {
                searchTextBoxes[i].TextChanged += SearchInAll;
                searchTextBoxes[i].GotFocus += SearchGotFocus;
                searchTextBoxes[i].LostFocus += SearchLostFocus;
            }

            //These lines of code are here to avoid flickering on the forms
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            int style = NativeWinAPI.GetWindowLong(flowLayoutPanel1.Handle, NativeWinAPI.GWL_EXSTYLE);
            style |= NativeWinAPI.WS_EX_COMPOSITED;
            NativeWinAPI.SetWindowLong(flowLayoutPanel1.Handle, NativeWinAPI.GWL_EXSTYLE, style);
            //

            //Getting the Description value of our ComponentsName and SortBy enum
            componentComboBox.DisplayMember = "Description";
            componentComboBox.ValueMember = "Value";
            componentComboBox.DataSource = Enum.GetValues(typeof(ComponentsName))
                .Cast<Enum>()
                .Select(value => new
                {
                    (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()),
                        typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                    value
                })
                .OrderBy(item => item.value)
                .ToList();
            //

            //Tests
            if (componentList.Count == 0)
            {
                Teszt(true);
                componentList = DBManager.Read(user);
                componentCount = componentList.Count;
                computerList = new List<Computer>();
                if (loggedInUser != null)
                {
                    userLabel.Text = loggedInUser.UserName + " " + loggedInUser.UserId;
                }
                checkBox1.Hide();
                ComponentButtonRefresh();
            }
            DarkMode(false);
            //Components fdad = DBManager.ReadCucc();

            //Creating the buttons and putting them on the flowLayoutPanel
            ComponentButtonRefresh();
            flowLayoutPanel1.ControlAdded += FlowLayoutPanel1_ControlChanged;
            flowLayoutPanel1.ControlRemoved += FlowLayoutPanel1_ControlChanged;
            FlowLayoutPanel1_ControlChanged(null, null);
        }

        //Needed to avoid flickering!
        internal static class NativeWinAPI
        {
            internal static readonly int GWL_EXSTYLE = -20;
            internal static readonly int WS_EX_COMPOSITED = 0x02000000;

            [DllImport("user32")]
            internal static extern int GetWindowLong(IntPtr hWnd, int nIndex);

            [DllImport("user32")]
            internal static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        }

        #region Teszt

        //DarkmodeCheckBox
        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                DarkMode(true);
            }
            else
            {
                DarkMode(false);
            }
        }

        private void DarkMode(bool isItOn)
        {
            string a = menuPanel.BackColor.ToString();
            menuPanel.BackColor = Color.FromArgb(255, 254, 255, 254);
            if (isItOn)
            {
                menuPanel.BackColor = ColorTranslator.FromHtml("#2D2D30");
                int menuButtonsLength = menuButtons.Length;
                for (int i = 0; i < menuButtonsLength; i++)
                {
                    menuButtons[i].ForeColor = Color.FromArgb(255, 153, 92);
                }

                //flowLayoutPanel1.BackColor = Color.
            }
            else
            {
                menuPanel.BackColor = Color.FromArgb(255, 254, 255, 254);
                int menuButtonsLength = menuButtons.Length;
                for (int i = 0; i < menuButtonsLength; i++)
                {
                    menuButtons[i].ForeColor = Color.FromArgb(242, 153, 92);
                }

                flowLayoutPanel1.BackColor = Color.Transparent;
            }
        }

        private void Teszt(bool mehet)
        {
            if (mehet)
            {
                Case testCase = new Case("Cooler Master", "i500H", "", 45000, DateTime.Now, DateTime.Now, new DateTime(2030, 10, 10), "Jó vétel volt!", true, CaseFormFactor.ATX, true, false, false, false, false, false, 6, 2, 20, 145);
                Motherboard testMotherboard = new Motherboard("ASRock", "Z370 Pro4", "", 30000, DateTime.Now, DateTime.Now, new DateTime(2019, 04, 14), "", FormFactor.ATX, Socket.LGA1151, MemoryGeneration.DDR4, false, false, false, false, 2, 4, 128, 2, 3, 2, 6, 4, 1, 1);
                IntelProcessor testIntelProcessor = new IntelProcessor("Intel", "i7 8700k", "", 95000, DateTime.Now, DateTime.Now, new DateTime(2030, 10, 10), "LeC fórumtárstól lett véve!", 2, 12, 6, 6, 12, 3700, 3800, 95, IntelSocket.LGA1151, "UHD 620");
                RAM testRam = new RAM("Corsair", "Vengeance LPX", "", 55000, DateTime.Now, DateTime.Now, new DateTime(2030, 10, 10), "LeC fórumtárstól lett véve!", RAMGeneration.DDR4, 8, 3000, 15, 2, false, false);
                RAM testRamBad = new RAM("Kingstone", "Hyperx", "", 55000, DateTime.Now, DateTime.Now, new DateTime(2030, 10, 10), "LeC fórumtárstól lett véve!", RAMGeneration.DDR3, 8, 1666, 12, 2, false, false);
                Videocard testVideocard = new Videocard("GeForce", "RTX 2070", "", 170000, DateTime.Now, DateTime.Now, new DateTime(2030, 10, 10), "Nem tudom hol a vettem", 8, Design.Gigabyte, 120, 2, 140);
                Cooler testCooler = new Cooler("Deepcool", "Maelstorm 120", "", 14000, DateTime.Now, DateTime.Now, new DateTime(2030, 10, 10), "Nagyon régen vettem, te jó ég!!", true, false, false, false, false, false, false, true, false, 20);
                PowerSupply testPowerSupply = new PowerSupply("Chieftec", "PWS-7008A", "", 14000, DateTime.Now, DateTime.Now, new DateTime(2030, 10, 10), "Jó vétel volt!", 700, Efficency.BRONZE80, 6, 2, 6, false, Classes.Components.PowerSupply.FormFactor.SFX);
                SSD testSsd = new SSD("Samsung", "PM981", "", 50000, DateTime.Now, DateTime.Now, new DateTime(2030, 10, 10), "Jó vétel volt!", 1000, ConnectorType.m2, 100, StorageSize.m22242, 2400, 3400, Technology.MLC);
                HDD testHdd = new HDD("Western Digital", "HT100CGBA", "", 20000, DateTime.Now, DateTime.Now, new DateTime(2030, 10, 10), "Jó vétel volt!", 2000, ConnectorType.SATA3, 100, StorageSize.h35, 7200, 8);
                DBManager.Insert(testCase, user);
                DBManager.Insert(testMotherboard, user);
                DBManager.Insert(testIntelProcessor, user);
                DBManager.Insert(testRam, user);
                DBManager.Insert(testRamBad, user);
                DBManager.Insert(testVideocard, user);
                DBManager.Insert(testCooler, user);
                DBManager.Insert(testPowerSupply, user);
                DBManager.Insert(testSsd, user);
                DBManager.Insert(testHdd, user);
                DBManager.Insert(testSsd, user);
                DBManager.Insert(testHdd, user);
                List<SSD> SSDs = new List<SSD>();
                List<HDD> HDDs = new List<HDD>();
                List<Videocard> videocards = new List<Videocard>();
                List<RAM> rams = new List<RAM>();
                rams.Add(testRam);
                videocards.Add(testVideocard);
                HDDs.Add(testHdd);
                HDDs.Add(testHdd);
                SSDs.Add(testSsd);
                SSDs.Add(testSsd);

                DBManager.Insert(new Computer(testCase, testMotherboard, testIntelProcessor, rams, videocards, testCooler, testPowerSupply, SSDs, HDDs), user);
            }
        }

        private void ComputerBuildForm()
        {
            Form computerForm = new Form();
            computerForm.Show();
            computerForm.TopLevel = false;
            computerForm.ShowInTaskbar = false;
            computerForm.TopMost = true;
            computerForm.BringToFront();
            computerForm.Left = this.Left + 100;
            Controls.Add(computerForm);
        }

        #endregion

        #region Draggable surfaces
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        private void TopPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        #endregion

        #region FlowLayoutPanel refresh

        /*  Use these lines of code if you want to refresh every button BASED on what's inside the componentList
         *
         *      lastClickedButton = everythingButton;
         *      buttons = new List<MyButton>();
         */

        public void ComponentButtonRefresh()
        {

            //Check if there are new components that are not made into buttons (created)
            List<Components> newComponents = componentList.Where(component => !buttons.Any(button => button.Tag == component)).ToList();
            List<Computer> newComputers = computerList.Where(computer => !buttons.Any(button => button.Tag == computer)).ToList();

            int newComputersCount = newComputers.Count;
            int newComponentsCount = newComponents.Count;

            //Check if there are buttons that are existing but there are no components and computers found for them (deleted)
            List<MyButton> deletedButtons = buttons.Where(button => !componentList.Any(component => component == button.Tag) && !computerList.Any(computer => computer == button.Tag)).ToList();
            int deletedButtonsCount = deletedButtons.Count;

            //If there are new components, let's make them into buttons!
            if (newComponentsCount > 0)
            {
                for (int i = 0; i < newComponentsCount; i++)
                {
                    MyButton newButton = new MyButton();
                    if (newComponents[i] is Components)
                    {
                        //Checking how much days of warranty left
                        DateTime? warranty = newComponents[i].Warranty;
                        TimeSpan? daysLeft = new TimeSpan(0, 0, 0, 0);
                        if (warranty != null)
                        {
                            daysLeft = warranty - DateTime.Now;
                        }

                        //Determining which icon to use for which component
                        if (newComponents[i] is Case)
                        {
                            if (warranty != null && warranty > DateTime.Now && daysLeft <= new TimeSpan(7, 0, 0, 0))
                            {
                                newButton.Image = buttonImages[0];
                            }
                            else if (!warranty.HasValue || warrantyWarningRed && warranty < DateTime.Now)
                            {
                                newButton.Image = buttonImages[1];
                            }
                            else
                            {
                                newButton.Image = buttonImages[2];
                            }
                        }
                        else if (newComponents[i] is Motherboard)
                        {
                            if (warranty != null && warranty > DateTime.Now && daysLeft <= new TimeSpan(7, 0, 0, 0))
                            {
                                newButton.Image = buttonImages[3];
                            }
                            else if (!warranty.HasValue || warrantyWarningRed && warranty < DateTime.Now)
                            {
                                newButton.Image = buttonImages[4];
                            }
                            else
                            {
                                newButton.Image = buttonImages[5];
                            }
                        }
                        else if (newComponents[i] is Processor)
                        {
                            if (warranty != null && warranty > DateTime.Now && daysLeft <= new TimeSpan(7, 0, 0, 0))
                            {
                                newButton.Image = buttonImages[6];
                            }
                            else if (!warranty.HasValue || warrantyWarningRed && warranty < DateTime.Now)
                            {
                                newButton.Image = buttonImages[7];
                            }
                            else
                            {
                                newButton.Image = buttonImages[8];
                            }
                        }
                        else if (newComponents[i] is RAM)
                        {
                            if (warranty != null && warranty > DateTime.Now && daysLeft <= new TimeSpan(7, 0, 0, 0))
                            {
                                newButton.Image = buttonImages[9];
                            }
                            else if (!warranty.HasValue || warrantyWarningRed && warranty < DateTime.Now)
                            {
                                newButton.Image = buttonImages[10];
                            }
                            else
                            {
                                newButton.Image = buttonImages[11];
                            }
                        }
                        else if (newComponents[i] is Videocard)
                        {
                            if (warranty != null && warranty > DateTime.Now && daysLeft <= new TimeSpan(7, 0, 0, 0))
                            {
                                newButton.Image = buttonImages[12];
                            }
                            else if (!warranty.HasValue || warrantyWarningRed && warranty < DateTime.Now)
                            {
                                newButton.Image = buttonImages[13];
                            }
                            else
                            {
                                newButton.Image = buttonImages[14];
                            }
                        }
                        else if (newComponents[i] is Cooler)
                        {
                            if (warranty != null && warranty > DateTime.Now && daysLeft <= new TimeSpan(7, 0, 0, 0))
                            {
                                newButton.Image = buttonImages[15];
                            }
                            else if (!warranty.HasValue || warrantyWarningRed && warranty < DateTime.Now)
                            {
                                newButton.Image = buttonImages[16];
                            }
                            else
                            {
                                newButton.Image = buttonImages[17];
                            }
                        }
                        else if (newComponents[i] is PowerSupply)
                        {
                            if (warranty != null && warranty > DateTime.Now && daysLeft <= new TimeSpan(7, 0, 0, 0))
                            {
                                newButton.Image = buttonImages[18];
                            }
                            else if (!warranty.HasValue || warrantyWarningRed && warranty < DateTime.Now)
                            {
                                newButton.Image = buttonImages[19];
                            }
                            else
                            {
                                newButton.Image = buttonImages[20];
                            }
                        }
                        else if (newComponents[i] is Storage)
                        {
                            if (newComponents[i] is HDD)
                            {
                                if (warranty != null && warranty > DateTime.Now && daysLeft <= new TimeSpan(7, 0, 0, 0))
                                {
                                    newButton.Image = buttonImages[21];
                                }
                                else if (!warranty.HasValue || warrantyWarningRed && warranty < DateTime.Now)
                                {
                                    newButton.Image = buttonImages[22];
                                }
                                else
                                {
                                    newButton.Image = buttonImages[23];
                                }
                            }
                            else if (newComponents[i] is SSD)
                            {
                                if (warranty != null && warranty > DateTime.Now && daysLeft <= new TimeSpan(7, 0, 0, 0))
                                {
                                    newButton.Image = buttonImages[24];
                                }
                                else if (!warranty.HasValue || warrantyWarningRed && warranty < DateTime.Now)
                                {
                                    newButton.Image = buttonImages[25];
                                }
                                else
                                {
                                    newButton.Image = buttonImages[26];
                                }
                            }
                        }
                    }

                    //Setting the tag and text of the button
                    newButton.Text = CheckingTextSize(newButton, newComponents[i].ProductsName);
                    newButton.Tag = newComponents[i];
                    foreach (Button item in newButton.Controls)
                    {
                        //Adding event to each control based on their name
                        item.Tag = newComponents[i];
                        if (item.Name == "customize")
                        {
                            item.Click += CustomizeOnClick;
                        }
                        else
                        {
                            item.Click += DeleteOnClick;
                        }
                    }
                    //Adding event for the main button to show basic information about it
                    newButton.DoubleClick += ButtonDB_Click;
                    buttons.Add(newButton);
                }
            }

            //EVENT VAGY VALAMI!
            if (newComputersCount > 0)
            {
                for (int i = 0; i < newComputersCount; i++)
                {
                    MyButton newButton = new MyButton();

                    newButton.Text = "Computer";
                    newButton.Image = buttonImages[27];
                    newButton.Tag = newComputers[i];
                    buttons.Add(newButton);
                }
            }

            //Checking the size of the text in the button
            string CheckingTextSize(MyButton newButton, string componentName)
            {
                SizeF size;
                using (Graphics graphics = Graphics.FromImage(new Bitmap(1, 1)))
                {
                    size = graphics.MeasureString(componentName, new Font("Century Gothic", 11f, FontStyle.Bold));

                    //If size of the text is wider or equal to to the customize button's MINUS image's width - 14 pixel, we have to add a breakline so the text won't hang into the customize button
                    if (size.Width >= (newButton.Controls.Find("customize", false)[0].Left - newButton.Image.Width - 14))
                    {
                        float a = size.Width;
                        string split = null;
                        bool isItSplit = false;

                        //Check when it reaches the treshold, one character at a time
                        for (int i = 0; i < componentName.Length; i++)
                        {
                            split += componentName[i];
                            SizeF splitSize = graphics.MeasureString(split, new Font("Century Gothic", 11f, FontStyle.Bold));
                            if (splitSize.Width >= (newButton.Controls.Find("customize", false)[0].Left - newButton.Image.Width - 14) && !isItSplit)
                            {
                                split += "\n";
                                isItSplit = true;
                            }
                        }

                        return split;
                    }
                    else
                    {
                        return componentName;
                    }
                }
            }

            //Delete buttons, if there are any
            if (deletedButtonsCount > 0)
            {
                int x = 0;
                for (int i = 0; i < deletedButtons.Count; i++)
                {
                    for (int j = 0; j < buttons.Count; j++)
                    {
                        if (deletedButtons[i] == buttons[j])
                        {
                            x++;
                            MyButton a = buttons[j];
                            buttons.RemoveAt(j);
                        }
                    }
                }
            }

            if (lastClickedButton == null)
            {
                EverythingButton_Click(null, null);
                everythingButton.Image = Resources.everything_50px_gold;
                everythingButton.BackColor = Color.FromArgb(54, 54, 57);
                componentLabel.Text = "All";
                //lastClickedButton = everythingButton;
            }
            else
            {
                lastClickedButton.PerformClick();
            }

            componentCount = componentList.Count;
        }

        #endregion

        #region MenuButtons

        private void HighLightSelectedMenuButton(object sender, EventArgs e)
        {
            Color highlight = Color.FromArgb(54, 54, 57);

            //Changing the selected menu button's icon to golden one
            if ((sender as Button).Name == "everythingButton")
            {
                (sender as Button).Image = goldenMenuButtons[0];
                componentLabel.Text = "All";
            }
            else if ((sender as Button).Name == "casesButton")
            {
                (sender as Button).Image = goldenMenuButtons[1];
                componentLabel.Text = "Cases";
            }
            else if ((sender as Button).Name == "coolersButton")
            {
                (sender as Button).Image = goldenMenuButtons[2];
                componentLabel.Text = "Coolers";
            }
            else if ((sender as Button).Name == "motherboardsButton")
            {
                (sender as Button).Image = goldenMenuButtons[3];
                componentLabel.Text = "Motherboards";
            }
            else if ((sender as Button).Name == "powerSuppliesButton")
            {
                (sender as Button).Image = goldenMenuButtons[4];
                componentLabel.Text = "Power supplies";
            }
            else if ((sender as Button).Name == "processorsButton")
            {
                (sender as Button).Image = goldenMenuButtons[5];
                componentLabel.Text = "Processors";
            }
            else if ((sender as Button).Name == "memoriesButton")
            {
                (sender as Button).Image = goldenMenuButtons[6];
                componentLabel.Text = "Memories";
            }
            else if ((sender as Button).Name == "storagesButton")
            {
                (sender as Button).Image = goldenMenuButtons[7];
                componentLabel.Text = "Storages";
            }
            else if ((sender as Button).Name == "videocardsButton")
            {
                (sender as Button).Image = goldenMenuButtons[8];
                componentLabel.Text = "Video cards";
            }
            else if ((sender as Button).Name == "computersButton")
            {
                (sender as Button).Image = goldenMenuButtons[9];
                componentLabel.Text = "Computers";
            }

            lastClickedButton = sender as Button;
            sortByComboBox.DataSource = null;
            (sender as Button).BackColor = highlight;

            //Checking for button's that are not selected, but their backcolor is highlighted
            for (int i = 0; i < menuButtons.Length; i++)
            {
                //If it's not selected AND their backcolor is highighted, change their icon and backcolor back
                if (menuButtons[i] != (sender as Button) && menuButtons[i].BackColor == highlight)
                {
                    if (menuButtons[i].Name == "everythingButton")
                    {
                        menuButtons[i].Image = Resources.everything_50px;
                    }
                    else if (menuButtons[i].Name == "casesButton")
                    {
                        menuButtons[i].Image = Resources.case_50px;
                    }
                    else if (menuButtons[i].Name == "coolersButton")
                    {
                        menuButtons[i].Image = Resources.cooling_fan_50px;
                    }
                    else if (menuButtons[i].Name == "motherboardsButton")
                    {
                        menuButtons[i].Image = Resources.motherboard_50px;
                    }
                    else if (menuButtons[i].Name == "powerSuppliesButton")
                    {
                        menuButtons[i].Image = Resources.power_50px;
                    }
                    else if (menuButtons[i].Name == "processorsButton")
                    {
                        menuButtons[i].Image = Resources.cpu_50px;
                    }
                    else if (menuButtons[i].Name == "memoriesButton")
                    {
                        menuButtons[i].Image = Resources.ram_50px;
                    }
                    else if (menuButtons[i].Name == "storagesButton")
                    {
                        menuButtons[i].Image = Resources.hard_drive_50px;
                    }
                    else if (menuButtons[i].Name == "videocardsButton")
                    {
                        menuButtons[i].Image = Resources.video_card_50px;
                    }
                    else if (menuButtons[i].Name == "computersButton")
                    {
                        menuButtons[i].Image = Resources.desktop_computer_50px;
                    }

                    menuButtons[i].BackColor = Color.FromArgb(45, 45, 48);
                }
            }
        }

        //Showing every item
        private void EverythingButton_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            int buttonsCount = buttons.Count;
            for (int i = 0; i < buttonsCount; i++)
            {
                flowLayoutPanel1.Controls.Add(buttons[i]);
            }
        }

        //Showing only computers
        private void ComputerButton_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            List<MyButton> computerButtons = buttons.Where(x => x.Text == "Computer").ToList();
            int computerButtonsCount = computerButtons.Count;
            for (int i = 0; i < computerButtonsCount; i++)
            {
                flowLayoutPanel1.Controls.Add(computerButtons[i]);
            }
        }

        //Showing only Cases
        private void CasesButton_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            List<MyButton> caseButtons = buttons.Where(x => x.Tag is Case).ToList();
            int caseButtonsCount = caseButtons.Count;
            for (int i = 0; i < caseButtonsCount; i++)
            {
                flowLayoutPanel1.Controls.Add(caseButtons[i]);
            }
        }

        //Showing only Motherboards
        private void MotherboardsButton_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            List<MyButton> motherboardButtons = buttons.Where(x => x.Tag is Motherboard).ToList();
            int motherboardButtonsCount = motherboardButtons.Count;
            for (int i = 0; i < motherboardButtonsCount; i++)
            {
                flowLayoutPanel1.Controls.Add(motherboardButtons[i]);
            }
        }

        //Showing only Processors
        private void ProcessorsButton_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            List<MyButton> processorButtons = buttons.Where(x => x.Tag is Processor).ToList();
            int processorButtonsCount = processorButtons.Count;
            for (int i = 0; i < processorButtonsCount; i++)
            {
                flowLayoutPanel1.Controls.Add(processorButtons[i]);
            }
        }

        //Showing only RAMs
        private void MemoriesButton_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            List<MyButton> memoryButtons = buttons.Where(x => x.Tag is RAM).ToList();
            int memoryButtonsCount = memoryButtons.Count;
            for (int i = 0; i < memoryButtonsCount; i++)
            {
                flowLayoutPanel1.Controls.Add(memoryButtons[i]);
            }
        }

        //Showing only Videocards
        private void VideocardsButton_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            List<MyButton> videocardButtons = buttons.Where(x => x.Tag is Videocard).ToList();
            int videocardButtonsCount = videocardButtons.Count;
            for (int i = 0; i < videocardButtonsCount; i++)
            {
                flowLayoutPanel1.Controls.Add(videocardButtons[i]);
            }
        }

        //Showing only Coolers
        private void CoolersButton_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            List<MyButton> coolerButtons = buttons.Where(x => x.Tag is Cooler).ToList();
            int coolerButtonsCount = coolerButtons.Count;
            for (int i = 0; i < coolerButtonsCount; i++)
            {
                flowLayoutPanel1.Controls.Add(coolerButtons[i]);
            }
        }

        //Showing only Power Supplies
        private void PowerSuppliesButton_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            List<MyButton> powerSupplyButtons = buttons.Where(x => x.Tag is PowerSupply).ToList();
            int powerSupplyButtonsCount = powerSupplyButtons.Count;
            for (int i = 0; i < powerSupplyButtonsCount; i++)
            {
                flowLayoutPanel1.Controls.Add(powerSupplyButtons[i]);
            }
        }

        //Showing only Storages
        private void StoragesButton_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            List<MyButton> storageButtons = buttons.Where(x => x.Tag is Storage).ToList();
            int storageButtonsCount = storageButtons.Count;
            for (int i = 0; i < storageButtonsCount; i++)
            {
                flowLayoutPanel1.Controls.Add(storageButtons[i]);
            }
        }

        #endregion

        #region Add, edit, delete and double click components

        //Clicking add new button
        private void button2_Click(object sender, EventArgs e)
        {
            switch ((ComponentsName)componentComboBox.SelectedIndex)
            {
                case ComponentsName.Case:

                    newComponentForm newComponentForm = new newComponentForm();
                    if (newComponentForm.ShowDialog() == DialogResult.OK)
                    {
                        componentList.Add(newComponentForm.newComponent);
                        DBManager.Insert(newComponentForm.newComponent, user);
                    }

                    break;
                case ComponentsName.Motherboard:

                    newMotherboardForm newMotherboardForm = new newMotherboardForm();
                    if (newMotherboardForm.ShowDialog() == DialogResult.OK)
                    {
                        componentList.Add(newMotherboardForm.newComponent);
                        DBManager.Insert(newMotherboardForm.newComponent, user);
                    }

                    break;
                case ComponentsName.Processor:

                    newProcessorForm newProcessorForm = new newProcessorForm();
                    if (newProcessorForm.ShowDialog() == DialogResult.OK)
                    {
                        componentList.Add(newProcessorForm.newComponent);
                        DBManager.Insert(newProcessorForm.newComponent, user);
                    }

                    break;
                case ComponentsName.RAM:

                    newRAMForm newRamForm = new newRAMForm();
                    if (newRamForm.ShowDialog() == DialogResult.OK)
                    {
                        componentList.Add(newRAMForm.newComponent);
                        DBManager.Insert(newRAMForm.newComponent, user);
                    }

                    break;
                case ComponentsName.VideoCard:

                    newVideoCardForm newVideoCardForm = new newVideoCardForm();
                    if (newVideoCardForm.ShowDialog() == DialogResult.OK)
                    {
                        componentList.Add(newVideoCardForm.newComponent);
                        DBManager.Insert(newVideoCardForm.newComponent, user);
                    }

                    break;
                case ComponentsName.Cooler:

                    newCoolerForm newCoolerForm = new newCoolerForm();
                    if (newCoolerForm.ShowDialog() == DialogResult.OK)
                    {
                        componentList.Add(newCoolerForm.newComponent);
                        DBManager.Insert(newCoolerForm.newComponent, user);
                    }

                    break;
                case ComponentsName.PowerSupply:

                    newPowerSupplyForm newPowerSupplyForm = new newPowerSupplyForm();
                    if (newPowerSupplyForm.ShowDialog() == DialogResult.OK)
                    {
                        componentList.Add(newPowerSupplyForm.newComponent);
                        DBManager.Insert(newPowerSupplyForm.newComponent, user);
                    }

                    break;
                case ComponentsName.Storage:

                    newStorageForm newStorageForm = new newStorageForm();
                    if (newStorageForm.ShowDialog() == DialogResult.OK)
                    {
                        componentList.Add(newStorageForm.newComponent);
                        DBManager.Insert(newStorageForm.newComponent, user);
                    }

                    break;
            }

            //Refresh the buttons and the flowLayoutPanel
            ComponentButtonRefresh();
        }

        //Clicking on the modification button
        private void CustomizeOnClick(object sender, EventArgs e)
        {
            int index = ComponentIndex(sender);
            if (index < 0)
            {
                MessageBox.Show("Something went terribly wrong! There is no element like this!",
                    "Existential crisis", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if ((sender as Button).Tag is Case)
            {
                newComponentForm editComponentForm = new newComponentForm(componentList[index]);
                if (editComponentForm.ShowDialog() == DialogResult.OK)
                {
                    DBManager.Modification(componentList[index], newComponentForm.newComponent, user);
                    componentList.RemoveAt(index);
                    componentList.Add(newComponentForm.newComponent);
                }
            }
            else if (componentList[index] is Cooler)
            {
                newCoolerForm editComponentForm = new newCoolerForm(componentList[index]);
                if (editComponentForm.ShowDialog() == DialogResult.OK)
                {
                    DBManager.Modification(componentList[index], newCoolerForm.newComponent, user);
                    componentList.RemoveAt(index);
                    componentList.Add(newCoolerForm.newComponent);
                }
            }
            else if (componentList[index] is Motherboard)
            {
                newMotherboardForm editComponentForm = new newMotherboardForm(componentList[index]);
                if (editComponentForm.ShowDialog() == DialogResult.OK)
                {
                    DBManager.Modification(componentList[index], newMotherboardForm.newComponent, user);
                    componentList.RemoveAt(index);
                    componentList.Add(newMotherboardForm.newComponent);
                }
            }
            else if (componentList[index] is PowerSupply)
            {
                newPowerSupplyForm editComponentForm = new newPowerSupplyForm(componentList[index]);
                if (editComponentForm.ShowDialog() == DialogResult.OK)
                {
                    DBManager.Modification(componentList[index], componentList[index], user);
                    componentList.RemoveAt(index);
                    componentList.Add(newPowerSupplyForm.newComponent);
                }
            }
            //Itt valami nem okés
            else if (componentList[index] is Processor)
            {
                newProcessorForm editComponentForm = new newProcessorForm(componentList[index]);
                if (editComponentForm.ShowDialog() == DialogResult.OK)
                {
                    DBManager.ProcessorModification(componentList[index] as Processor, newProcessorForm.newComponent as Processor, user);
                    componentList.RemoveAt(index);
                    componentList.Add(newProcessorForm.newComponent);
                }
            }
            else if (componentList[index] is RAM)
            {
                newRAMForm editComponentForm = new newRAMForm(componentList[index]);
                if (editComponentForm.ShowDialog() == DialogResult.OK)
                {
                    DBManager.Modification(componentList[index], newRAMForm.newComponent, user);
                    componentList.RemoveAt(index);
                    componentList.Add(newRAMForm.newComponent);
                }
            }
            else if (componentList[index] is Storage)
            {
                newStorageForm editComponentForm = new newStorageForm(componentList[index]);
                if (editComponentForm.ShowDialog() == DialogResult.OK)
                {
                    DBManager.Modification(componentList[index], newStorageForm.newComponent, user);
                    componentList.RemoveAt(index);
                    componentList.Add(newStorageForm.newComponent);
                }
            }
            else if (componentList[index] is Videocard)
            {
                newVideoCardForm editComponentForm = new newVideoCardForm(componentList[index]);
                if (editComponentForm.ShowDialog() == DialogResult.OK)
                {
                    DBManager.Modification(componentList[index], newVideoCardForm.newComponent, user);
                    componentList.RemoveAt(index);
                    componentList.Add(newVideoCardForm.newComponent);
                }
            }

            ComponentButtonRefresh();
        }

        //Clicking on the delete button
        private void DeleteOnClick(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this item?", "Are you sure?",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int index = ComponentIndex(sender);
                if (index > -1)
                {
                    DBManager.Delete(componentList[index], user);
                    componentList.RemoveAt(index);
                }
                else
                {
                    MessageBox.Show("Something went terribly wrong! There is no element like this!",
                        "Existential crisis", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            ComponentButtonRefresh();
        }

        static int ComponentIndex(object sender)
        {
            Components searchForComponent = (Components)(sender as Button).Tag;
            int index = 0;
            for (int i = 0; i < componentCount; i++)
            {
                if (searchForComponent == componentList[i])
                {
                    return index = i;
                }
            }

            return -1;
        }

        //Eventhandler for MyButton in the FlowLayoutPanel to show detalis of item at doubleClick
        static void ButtonDB_Click(object sender, EventArgs e)
        {
            Components component = (Components)(sender as Button).Tag;
            MessageBox.Show(
                $"Type: {component.GetType().Name} \nManufacturer: {component.Manufacturer} \nProduct's name: {component.ProductsName} \nDate of purchase: {component.DateOfPurchase.ToShortDateString()} \nWarranty: {(component.Warranty < DateTime.Now ? "Expired!" : component.Warranty.ToShortDateString())}\nPrice: {component.Price}",
                "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region Create computer

        private void CreateComputerButton_Click(object sender, EventArgs e)
        {
            if (createComputerButton.Text != "Cancel" && DoWeHaveEveryComponentNeeded())
            {
                addNewButton.Hide();
                componentComboBox.Hide();
                for (int i = 0; i < menuButtons.Length; i++)
                {
                    RemoveClickEvent(menuButtons[i]);
                }
                CreateComputer();
                createComputerButton.Text = "Cancel";
            }
            else if (createComputerButton.Text == "Cancel")
            {
                Nullify();
                addNewButton.Show();
                componentComboBox.Show();
                createComputerButton.Text = "Create computer";


                everythingButton.Click += EverythingButton_Click;
                motherboardsButton.Click += MotherboardsButton_Click;
                processorsButton.Click += ProcessorsButton_Click;
                casesButton.Click += CasesButton_Click;
                videocardsButton.Click += VideocardsButton_Click;
                memoriesButton.Click += MemoriesButton_Click;
                storagesButton.Click += StoragesButton_Click;
                powerSuppliesButton.Click += PowerSuppliesButton_Click;
                coolersButton.Click += CoolersButton_Click;
                computersButton.Click += ComputerButton_Click;

                for (int i = 0; i < 10; i++)
                {
                    menuButtons[i].Click += HighLightSelectedMenuButton;
                }

                lastClickedButton = everythingButton;
                buttons = new List<MyButton>();
                ComponentButtonRefresh();
            }
        }

        //Check if we have every component that is needed to make a new computer
        private bool DoWeHaveEveryComponentNeeded()
        {
            if (componentList.OfType<Case>().Any())
            {
                if (componentList.OfType<Motherboard>().Any())
                {
                    if (componentList.OfType<Processor>().Any())
                    {
                        if (componentList.OfType<RAM>().Any())
                        {
                            if (componentList.OfType<Cooler>().Any())
                            {
                                if (componentList.OfType<PowerSupply>().Any())
                                {
                                    if (componentList.OfType<Storage>().Any())
                                    {
                                        return true;
                                    }
                                    else
                                    {
                                        MessageBox.Show("You don't have any storage to make a new computer!", "Attention!", MessageBoxButtons.OK,
                                            MessageBoxIcon.Hand);
                                        return false;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("You don't have any power supply to make a new computer!", "Attention!", MessageBoxButtons.OK,
                                        MessageBoxIcon.Hand);
                                    return false;
                                }
                            }
                            else
                            {
                                MessageBox.Show("You don't have any cooler to make a new computer!", "Attention!", MessageBoxButtons.OK,
                                    MessageBoxIcon.Hand);
                                return false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("You don't have any RAM to make a new computer!", "Attention!", MessageBoxButtons.OK,
                                MessageBoxIcon.Hand);
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("You don't have any processor to make a new computer!", "Attention!", MessageBoxButtons.OK,
                            MessageBoxIcon.Hand);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("You don't have any motherboard to make a new computer!", "Attention!", MessageBoxButtons.OK,
                        MessageBoxIcon.Hand);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("You don't have any case to make a new computer!", "Attention!", MessageBoxButtons.OK,
                    MessageBoxIcon.Hand);
                return false;
            }
        }

        private void CreateComputer()
        {
            if (selectedMotherboard == null)
            {
                motherboardsButton.Click += MotherboardsButton_Click;
                motherboardsButton.PerformClick();
                HighLightSelectedMenuButton(motherboardsButton, null);
                RemoveClickEvent(motherboardsButton);
                componentLabel.Text = "Please choose a motherboard!";
            }
            else if (selectedProcessor == null)
            {
                processorsButton.Click += ProcessorsButton_Click;
                processorsButton.PerformClick();
                HighLightSelectedMenuButton(processorsButton, null);
                RemoveClickEvent(processorsButton);
                componentLabel.Text = "Please choose a processor!";
            }
            else if (selectedCase == null)
            {
                casesButton.Click += CasesButton_Click;
                casesButton.PerformClick();
                HighLightSelectedMenuButton(casesButton, null);
                RemoveClickEvent(casesButton);
                componentLabel.Text = "Please choose a case!";
            }
            else if (selectedVideocard.Count == 0)
            {
                videocardsButton.Click += VideocardsButton_Click;
                videocardsButton.PerformClick();
                HighLightSelectedMenuButton(videocardsButton, null);
                RemoveClickEvent(videocardsButton);
                componentLabel.Text = "Please choose from videocards!";
            }
            else if (selectedRAM.Count == 0)
            {
                memoriesButton.Click += MemoriesButton_Click;
                memoriesButton.PerformClick();
                HighLightSelectedMenuButton(memoriesButton, null);
                RemoveClickEvent(memoriesButton);
                componentLabel.Text = "Please choose from RAMs!";
            }
            else if (selectedHDD.Count == 0 && selectedSSD.Count == 0)
            {
                storagesButton.Click += StoragesButton_Click;
                storagesButton.PerformClick();
                HighLightSelectedMenuButton(storagesButton, null);
                RemoveClickEvent(storagesButton);
                componentLabel.Text = "Please choose from storages!";
            }
            else if (selectedPowerSupply == null)
            {
                powerSuppliesButton.Click += PowerSuppliesButton_Click;
                powerSuppliesButton.PerformClick();
                HighLightSelectedMenuButton(powerSuppliesButton, null);
                RemoveClickEvent(powerSuppliesButton);
                componentLabel.Text = "Please choose a power supply!";
            }
            else if (selectedCooler == null)
            {
                coolersButton.Click += CoolersButton_Click;
                coolersButton.PerformClick();
                HighLightSelectedMenuButton(coolersButton, null);
                RemoveClickEvent(coolersButton);
                componentLabel.Text = "Please choose a cooler!";
            }

            if (selectedCase != null && selectedMotherboard != null && selectedProcessor != null && selectedRAM.Count > 0 && selectedVideocard.Count > 0 && selectedCooler != null && selectedPowerSupply != null && (selectedSSD.Count > 0 || selectedHDD.Count > 0))
            {
                try
                {
                    if (selectedProcessor is IntelProcessor)
                    {
                        createdComputer = new Computer(selectedCase, selectedMotherboard, selectedProcessor as IntelProcessor, selectedRAM, selectedVideocard, selectedCooler, selectedPowerSupply, selectedSSD, selectedHDD);
                    }
                    else
                    {
                        createdComputer = new Computer(selectedCase, selectedMotherboard, selectedProcessor as AMDProcessor, selectedRAM, selectedVideocard, selectedCooler, selectedPowerSupply, selectedSSD, selectedHDD);
                    }
                }
                catch (ComputerError exception)
                {
                    MessageBox.Show(exception.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (createdComputer != null)
            {
                MessageBox.Show("Computer is ready!", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                componentList.Remove(selectedProcessor);
                componentList.Remove(selectedCase);
                componentList.Remove(selectedMotherboard);
                componentList.Remove(selectedCooler);
                componentList.Remove(selectedPowerSupply);

                for (int i = 0; i < selectedRAM.Count; i++)
                {
                    componentList.Remove(selectedRAM[i]);
                }

                for (int i = 0; i < selectedVideocard.Count; i++)
                {
                    componentList.Remove(selectedVideocard[i]);
                }

                for (int i = 0; i < selectedSSD.Count; i++)
                {
                    componentList.Remove(selectedSSD[i]);
                }

                for (int i = 0; i < selectedHDD.Count; i++)
                {
                    componentList.Remove(selectedHDD[i]);
                }


                computerList.Add(createdComputer);
                Nullify();
                addNewButton.Show();
                componentComboBox.Show();
                createComputerButton.Text = "Create computer";
                lastClickedButton = everythingButton;
                buttons = new List<MyButton>();

                everythingButton.Click += EverythingButton_Click;
                motherboardsButton.Click += MotherboardsButton_Click;
                processorsButton.Click += ProcessorsButton_Click;
                casesButton.Click += CasesButton_Click;
                videocardsButton.Click += VideocardsButton_Click;
                memoriesButton.Click += MemoriesButton_Click;
                storagesButton.Click += StoragesButton_Click;
                powerSuppliesButton.Click += PowerSuppliesButton_Click;
                coolersButton.Click += CoolersButton_Click;
                computersButton.Click += ComputerButton_Click;

                for (int i = 0; i < 10; i++)
                {
                    menuButtons[i].Click += HighLightSelectedMenuButton;
                }

                ComponentButtonRefresh();
            }
            else
            {
                CheckCompatibility();
            }
        }

        static void Nullify()
        {
            selectedCase = null;
            selectedCooler = null;
            selectedMotherboard = null;
            selectedPowerSupply = null;
            selectedProcessor = null;
            selectedRAM = new List<RAM>();
            selectedHDD = new List<HDD>();
            selectedSSD = new List<SSD>();
            selectedVideocard = new List<Videocard>();
            createdComputer = null;
        }

        private void CheckCompatibility()
        {
            //Check if component is compatible with the selected components
            int sata = 0;
            int m2 = 0;
            int badButton = 0;

            for (int i = 0; i < flowLayoutPanel1.Controls.Count; i++)
            {
                bool isItBad = false;
                RemoveClickEvent(flowLayoutPanel1.Controls[i] as Button);

                if (flowLayoutPanel1.Controls[i] is MyButton)
                {
                    if (flowLayoutPanel1.Controls[i].Tag is Processor && selectedMotherboard != null)
                    {
                        if (flowLayoutPanel1.Controls[i].Tag is IntelProcessor && selectedMotherboard.Socket.ToString() != (flowLayoutPanel1.Controls[i].Tag as IntelProcessor).IntelSocket.ToString())
                        {
                            flowLayoutPanel1.Controls[i].Click += (sender, args) => MessageBox.Show($"The motherboard's socket, which is {selectedMotherboard.Socket.ToString()}, doesn't support this processor!", "Warning!",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            isItBad = true;
                            goto badButton;
                        }
                        else if (flowLayoutPanel1.Controls[i].Tag is AMDProcessor && selectedMotherboard.Socket.ToString() != (flowLayoutPanel1.Controls[i].Tag as AMDProcessor).AmdSocket.ToString())
                        {
                            flowLayoutPanel1.Controls[i].Click += (sender, args) => MessageBox.Show($"The motherboard's socket, which is {selectedMotherboard.Socket.ToString()}, doesn't support this processor!", "Warning!",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            isItBad = true;
                        }
                    }

                    if (flowLayoutPanel1.Controls[i].Tag is Case && selectedMotherboard != null)
                    {
                        foreach (PropertyInfo caseInfo in typeof(Case).GetProperties())
                        {
                            if (caseInfo.ToString().Contains("Boolean"))
                            {
                                if (caseInfo.ToString().ToLower().Split(' ')[1] == selectedMotherboard.FormFactor.ToString().ToLower() && !(bool)caseInfo.GetValue(flowLayoutPanel1.Controls[i].Tag as Case, null))
                                {
                                    flowLayoutPanel1.Controls[i].Click += (sender, args) => MessageBox.Show($"This case doesn't support the selected motherboard, which has {selectedMotherboard.FormFactor.ToString()} form factor!", "Warning!",
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    isItBad = true;
                                    goto badButton;
                                }
                            }
                        }
                    }

                    if (flowLayoutPanel1.Controls[i].Tag is Videocard && selectedCase != null)
                    {
                        if ((flowLayoutPanel1.Controls[i].Tag as Videocard).VideoCardLength > selectedCase.VideoCardLength)
                        {
                            flowLayoutPanel1.Controls[i].Click += (sender, args) => MessageBox.Show($"This video card is too long for your selected case!\nThe case's supported maximum videocard length is {selectedCase.VideoCardLength}!", "Warning!",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            isItBad = true;
                        }
                    }

                    if (flowLayoutPanel1.Controls[i].Tag is RAM && selectedMotherboard != null)
                    {
                        //Checking if the selected motherboard has enough memory slots AND it's max memory doesn't exceed the RAMs memory AND if the generation is the same
                        if (selectedMotherboard.MemorySlots < (flowLayoutPanel1.Controls[i].Tag as RAM).Pieces)
                        {
                            flowLayoutPanel1.Controls[i].Click += (sender, args) => MessageBox.Show($"The number of memories exceed the number of memory slots on the motherboard, which is {selectedMotherboard.MemorySlots}!", "Warning!",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            isItBad = true;
                            goto badButton;
                        }
                        else if (selectedMotherboard.MaxMemorySize < ((flowLayoutPanel1.Controls[i].Tag as RAM).Pieces * (flowLayoutPanel1.Controls[i].Tag as RAM).Size))
                        {
                            flowLayoutPanel1.Controls[i].Click += (sender, args) => MessageBox.Show($"The overall memory size of the RAMs exceeds the motherboard's maximum suopprted memory size, which is {selectedMotherboard.MaxMemorySize}GB!", "Warning!",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            isItBad = true;
                            goto badButton;
                        }
                        else if (selectedMotherboard.MemoryGeneration.ToString() != (flowLayoutPanel1.Controls[i].Tag as RAM).RamGeneration.ToString())
                        {
                            flowLayoutPanel1.Controls[i].Click += (sender, args) => MessageBox.Show($"This memory generation is not supported by the motherboard! It only supports {selectedMotherboard.MemoryGeneration.ToString()}!", "Warning!",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            isItBad = true;
                        }
                    }

                    if (flowLayoutPanel1.Controls[i].Tag is Storage && selectedCase != null && selectedMotherboard != null)
                    {
                        if (flowLayoutPanel1.Controls[i].Tag is SSD && selectedCase != null && selectedMotherboard != null)
                        {
                            if ((flowLayoutPanel1.Controls[i].Tag as Storage).ConnectorType == ConnectorType.SATA3 || (flowLayoutPanel1.Controls[i].Tag as Storage).ConnectorType == ConnectorType.SATA3)
                            {
                                sata += 1;
                            }
                            else if ((flowLayoutPanel1.Controls[i].Tag as SSD).ConnectorType == ConnectorType.m2)
                            {
                                m2 += 1;
                            }
                        }

                        if (sata > (selectedMotherboard.Sata3Connectors + selectedMotherboard.Sata3Connectors))
                        {
                            flowLayoutPanel1.Controls[i].Click += (sender, args) => MessageBox.Show($"There is not enough SATA connector on the motherboard!\nThe motherboard has {selectedMotherboard.Sata3Connectors + selectedMotherboard.Sata3Connectors} SATA connector!", "Warning!",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            isItBad = true;
                            goto badButton;
                        }
                        else if (sata > selectedCase.HddSpace + selectedCase.SlimHDDspace)
                        {
                            flowLayoutPanel1.Controls[i].Click += (sender, args) => MessageBox.Show($"There is not enough SATA place in the case!\nThe case has {selectedCase.HddSpace + selectedCase.SlimHDDspace} storage bay!", "Warning!",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            isItBad = true;
                            goto badButton;
                        }
                        else if (m2 > (selectedMotherboard.M2x4Number))
                        {
                            flowLayoutPanel1.Controls[i].Click += (sender, args) => MessageBox.Show($"This memory generation is not supported by the motherboard! It only supports {selectedMotherboard.MemoryGeneration.ToString()}!", "Warning!",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            isItBad = true;
                        }
                    }

                    if (flowLayoutPanel1.Controls[i].Tag is Cooler && selectedMotherboard != null && selectedCase != null)
                    {
                        if ((flowLayoutPanel1.Controls[i].Tag as Cooler).Height > selectedCase.CpuHeatSinkHeight)
                        {
                            flowLayoutPanel1.Controls[i].Click += (sender, args) =>
                                MessageBox.Show(
                                    $"This cooler's heatsink height exceeds the previously selected case's supported heatsink height's, which is {selectedCase.CpuHeatSinkHeight}cm!\nThis CPU's hetsink height is {selectedCooler.Height}cm.",
                                    "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            isItBad = true;
                            goto badButton;
                        }
                        else
                        {
                            string supportedSockets = "";
                            foreach (PropertyInfo coolerInfo in typeof(Cooler).GetProperties())
                            {
                                if (coolerInfo.ToString().Contains("Boolean"))
                                {
                                    if ((bool)coolerInfo.GetValue(flowLayoutPanel1.Controls[i].Tag as Cooler, null))
                                    {
                                        supportedSockets += " " + coolerInfo.ToString().Split('.')[coolerInfo.ToString().Split('.').Length - 1] + "\n";
                                    }
                                    if (coolerInfo.ToString().ToLower().Contains(selectedMotherboard.Socket.ToString().ToLower()) && !(bool)coolerInfo.GetValue(flowLayoutPanel1.Controls[i].Tag as Cooler, null))
                                    {
                                        flowLayoutPanel1.Controls[i].Click += (sender, args) =>
                                            MessageBox.Show(
                                                $"This cooler doesn't support the socket of the selected motherboard, which is {selectedMotherboard.Socket.ToString()}!\nThis cooler supports {supportedSockets}cm.",
                                                "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        isItBad = true;
                                    }
                                }
                            }
                        }
                    }

                badButton:
                    if (isItBad)
                    {
                        flowLayoutPanel1.Controls[i].Name = "badButton";
                        flowLayoutPanel1.Controls[i].MouseHover += componentIsBad;
                        flowLayoutPanel1.Controls[i].MouseLeave += componentIsBadLeave;
                        badButton++;
                    }
                    else
                    {
                        flowLayoutPanel1.Controls[i].Click += SelectedButton;
                    }

                    flowLayoutPanel1.Controls[i].Controls.Clear();
                }
            }

            if (flowLayoutPanel1.Controls[0].Tag is Videocard || flowLayoutPanel1.Controls[0].Tag is RAM || flowLayoutPanel1.Controls[0].Tag is SSD || flowLayoutPanel1.Controls[0].Tag is HDD)
            {
                if (numberOfSelectedButtons == null)
                {
                    if (flowLayoutPanel1.Controls.Count == 1 || flowLayoutPanel1.Controls.Count - badButton == 1)
                    {
                        quantity = 1;
                        numberOfSelectedButtons = 0;
                    }
                    else
                    {
                        bool isItNumber = true;
                        do
                        {
                            string a = flowLayoutPanel1.Controls[0].Tag.GetType().ToString();
                            string component = "";
                            if (flowLayoutPanel1.Controls[0].Tag is Videocard)
                            {
                                component = "videocards";
                            }
                            else if (flowLayoutPanel1.Controls[0].Tag is RAM)
                            {
                                component = "RAMs";
                            }
                            else if (flowLayoutPanel1.Controls[0].Tag is Storage)
                            {
                                component = "storages";
                            }

                            quantityForm form = new quantityForm("Quantity", $"How many {component} do you want to choose?");
                            if (form.ShowDialog() == DialogResult.OK)
                            {
                                if (flowLayoutPanel1.Controls.Count < form.Quantity)
                                {
                                    MessageBox.Show(
                                        $"There is only {flowLayoutPanel1.Controls.Count} components to choose from!",
                                        "Please give number less or equal to the number of components!");
                                    isItNumber = false;
                                }
                                else if (flowLayoutPanel1.Controls.Count - badButton < form.Quantity)
                                {
                                    MessageBox.Show(
                                        $"That is because there are {badButton} bad components!",
                                        $"You can only choose from {flowLayoutPanel1.Controls.Count - badButton} components!");
                                    isItNumber = false;
                                }
                                else
                                {
                                    quantity = form.Quantity;
                                    badButton = 0;
                                    isItNumber = true;
                                }
                            }
                            else
                            {
                                createComputerButton.PerformClick();
                                return;
                            }
                        } while (!isItNumber);

                        numberOfSelectedButtons = 0;
                    }
                }
            }
        }
        private void RemoveClickEvent(Button button)
        {
            FieldInfo f1 = typeof(Control).GetField("EventClick",
                BindingFlags.Static | BindingFlags.NonPublic);
            object obj = f1.GetValue(button);
            PropertyInfo pi = button.GetType().GetProperty("Events",
                BindingFlags.NonPublic | BindingFlags.Instance);
            EventHandlerList list = (EventHandlerList)pi.GetValue(button, null);
            list.RemoveHandler(obj, list[obj]);
        }

        private void componentIsBad(object sender, EventArgs e)
        {
            toolTip.Show("This component is not compatible!", sender as MyButton, (sender as Button).Bottom, (sender as Button).Bottom - 10, 1500);
            (sender as MyButton).FlatAppearance.BorderColor = ColorTranslator.FromHtml("#FFAE42 ");
        }

        private void componentIsBadLeave(object sender, EventArgs e)
        {
            (sender as MyButton).FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
        }

        private void SelectedButton(object sender, EventArgs e)
        {
            int added = 0;
            //(sender as Button).Controls.Clear();
            if ((sender as Button).BackColor == ColorTranslator.FromHtml("#64389eed"))
            {
                (sender as Button).BackColor = Color.FromArgb(0, 255, 255, 255);
                numberOfSelectedButtons--;
            }
            else
            {
                (sender as Button).BackColor = ColorTranslator.FromHtml("#64389eed");
                numberOfSelectedButtons++;
            }

            for (int i = 0; i < flowLayoutPanel1.Controls.Count; i++)
            {
                if (flowLayoutPanel1.Controls[i].Tag is Videocard || flowLayoutPanel1.Controls[i].Tag is RAM || flowLayoutPanel1.Controls[i].Tag is SSD || flowLayoutPanel1.Controls[i].Tag is HDD)
                {
                    if (numberOfSelectedButtons == quantity)
                    {
                        if (flowLayoutPanel1.Controls[i].BackColor == ColorTranslator.FromHtml("#64389eed"))
                        {
                            switch (flowLayoutPanel1.Controls[i].Tag.GetType().Name)
                            {
                                case "RAM":
                                    if (flowLayoutPanel1.Controls[i].Name != "badButton")
                                    {
                                        selectedRAM.Add((RAM)flowLayoutPanel1.Controls[i].Tag);
                                        added++;
                                    }

                                    break;

                                case "HDD":
                                    if (flowLayoutPanel1.Controls[i].Name != "badButton")
                                    {
                                        selectedHDD.Add((HDD)flowLayoutPanel1.Controls[i].Tag);
                                        int a = selectedHDD.Count;
                                        added++;
                                    }

                                    break;

                                case "SSD":
                                    if (flowLayoutPanel1.Controls[i].Name != "badButton")
                                    {
                                        selectedSSD.Add((SSD)flowLayoutPanel1.Controls[i].Tag);
                                        added++;
                                    }

                                    break;

                                case "Videocard":
                                    if (flowLayoutPanel1.Controls[i].Name != "badButton")
                                    {
                                        selectedVideocard.Add((Videocard)flowLayoutPanel1.Controls[i].Tag);
                                        added++;
                                    }

                                    break;
                            }
                        }

                        if (added == quantity)
                        {
                            numberOfSelectedButtons = null;
                        }
                    }
                }
                else
                {
                    switch (flowLayoutPanel1.Controls[i].Tag.GetType().Name)
                    {
                        case "Case":
                            if (flowLayoutPanel1.Controls[i].Name != "badButton")
                            {
                                selectedCase = (Case)flowLayoutPanel1.Controls[i].Tag;
                                numberOfSelectedButtons = null;
                            }

                            break;

                        case "Cooler":
                            if (flowLayoutPanel1.Controls[i].Name != "badButton")
                            {
                                selectedCooler = (Cooler)flowLayoutPanel1.Controls[i].Tag;
                                numberOfSelectedButtons = null;
                            }

                            break;

                        case "Motherboard":
                            if (flowLayoutPanel1.Controls[i].Name != "badButton")
                            {
                                selectedMotherboard = (Motherboard)flowLayoutPanel1.Controls[i].Tag;
                                numberOfSelectedButtons = null;
                            }

                            break;

                        case "PowerSupply":
                            if (flowLayoutPanel1.Controls[i].Name != "badButton")
                            {
                                selectedPowerSupply = (PowerSupply)flowLayoutPanel1.Controls[i].Tag;
                                numberOfSelectedButtons = null;
                            }

                            break;

                        case "AMDProcessor":
                            if (flowLayoutPanel1.Controls[i].Name != "badButton")
                            {
                                selectedProcessor = (AMDProcessor)flowLayoutPanel1.Controls[i].Tag;
                                numberOfSelectedButtons = null;
                            }

                            break;

                        case "IntelProcessor":
                            if (flowLayoutPanel1.Controls[i].Name != "badButton")
                            {
                                selectedProcessor = (IntelProcessor)flowLayoutPanel1.Controls[i].Tag;
                                numberOfSelectedButtons = null;
                            }

                            break;
                    }
                }
            }

            CreateComputer();
        }

        #endregion

        #region Search&Sort
        private void SortByComboBox_Click(object sender, EventArgs e)
        {
            sortByComboBox.DisplayMember = "Description";
            sortByComboBox.ValueMember = "Value";
            sortByComboBox.DataSource = Enum.GetValues(typeof(SortBy))
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
        private void SortByComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //If lastClickedButton is computer [I need to implement computer class fully]
            if (lastClickedButton != menuButtons[9] && sortByComboBox.SelectedIndex != -1)
            {
                List<MyButton> ListToOrder = new List<MyButton>();
                List<MyButton> OrderedList;
                int flowLayoutControlsCount = flowLayoutPanel1.Controls.Count;
                for (int i = 0; i < flowLayoutControlsCount; i++)
                {
                    //Kivéve computer
                    if (flowLayoutPanel1.Controls[i].Text != "Computer")
                    {
                        ListToOrder.Add(flowLayoutPanel1.Controls[i] as MyButton);
                    }

                }
                flowLayoutPanel1.Controls.Clear();

                switch ((SortBy)sortByComboBox.SelectedIndex)
                {
                    case SortBy.PriceUp:

                        OrderedList = ListToOrder.OrderBy(x => (x.Tag as Components).Price).ToList();

                        break;

                    case SortBy.PriceDown:

                        OrderedList = ListToOrder.OrderByDescending(x => (x.Tag as Components).Price).ToList();

                        break;

                    case SortBy.DateDown:

                        OrderedList = ListToOrder.OrderByDescending(x => (x.Tag as Components).DateOfPurchase).ToList();

                        break;

                    case SortBy.DateUp:

                        OrderedList = ListToOrder.OrderBy(x => (x.Tag as Components).DateOfPurchase).ToList();

                        break;

                    case SortBy.AddedDown:

                        OrderedList = ListToOrder.OrderBy(x => (x.Tag as Components).DateOfAdd).ToList();

                        break;

                    case SortBy.AddedUp:

                        OrderedList = ListToOrder.OrderByDescending(x => (x.Tag as Components).DateOfAdd).ToList();

                        break;

                    default:
                        throw new ArgumentOutOfRangeException("No sort like that one!");
                }

                //FlowLayoutCount
                for (int i = 0; i < OrderedList.Count; i++)
                {
                    flowLayoutPanel1.Controls.Add(OrderedList[i]);
                }
            }
        }

        private void ProductSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            if (sortByComboBox.SelectedIndex != -1)
            {
                sortByComboBox.DataSource = null;
            }

            if (productSearchTextBox.Text.Trim() == "")
            {
                foreach (var savedFlowLayoutPanelControl in savedFlowLayoutPanelControls) flowLayoutPanel1.Controls.Add(savedFlowLayoutPanelControl);
            }
            else
            {
                if (productSearchTextBox.Text == "Bitch, be humble")
                {
                    MessageBox.Show("Ez Serdült Martin programja, az engedélye nélkül nem használhatod!");
                }
                List<MyButton> searchHere = new List<MyButton>();
                for (int i = 0; i < 4; i++)
                {
                    if (searchTextBoxes[i] != productSearchTextBox && searchTextBoxes[i].Text != "")
                    {
                        searchHere = GetButtonsInFlowlayout();
                        break;
                    }
                    else if (i == 3)
                    {
                        searchHere = savedFlowLayoutPanelControls;
                    }
                }
                int buttonsCount = searchHere.Count;
                flowLayoutPanel1.Controls.Clear();
                for (int i = 0; i < buttonsCount; i++)
                {
                    if ((searchHere[i].Tag as Components).ProductsName.Trim().ToLower().Contains(productSearchTextBox.Text.Trim().ToLower()))
                    {
                        flowLayoutPanel1.Controls.Add(searchHere[i]);
                    }
                }
            }
        }
        private void ProductSearchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == (Keys.Back) && productSearchTextBox.Text != "")
            {
                if (lastClickedButton != null)
                {
                    lastClickedButton.PerformClick();
                }
                else
                {
                    everythingButton.PerformClick();
                }
            }
        }

        private void ManufacturerSearchTextBox_TextChanged(object sender, EventArgs e)
        {

            if (sortByComboBox.SelectedIndex != -1)
            {
                sortByComboBox.DataSource = null;
            }

            if (manufacturerSearchTextBox.Text.Trim() == "")
            {
                if (lastClickedButton != null)
                {
                    lastClickedButton.PerformClick();
                }
                else
                {
                    everythingButton.PerformClick();
                }
            }
            else
            {
                List<MyButton> searchHere = new List<MyButton>();
                for (int i = 0; i < 4; i++)
                {
                    if (searchTextBoxes[i] != manufacturerSearchTextBox && searchTextBoxes[i].Text != "")
                    {
                        searchHere = GetButtonsInFlowlayout();
                        break;
                    }
                    else if (i == 3)
                    {
                        searchHere = savedFlowLayoutPanelControls;
                    }
                }
                int buttonsCount = searchHere.Count;
                flowLayoutPanel1.Controls.Clear();
                for (int i = 0; i < buttonsCount; i++)
                {
                    if ((searchHere[i].Tag as Components).Manufacturer.Trim().ToLower()
                        .Contains(manufacturerSearchTextBox.Text.Trim().ToLower()))
                    {
                        flowLayoutPanel1.Controls.Add(searchHere[i]);
                    }
                }
            }
        }

        private void ManufacturerSearchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == (Keys.Back) && manufacturerSearchTextBox.Text != "")
            {
                if (lastClickedButton != null)
                {
                    lastClickedButton.PerformClick();
                }
                else
                {
                    everythingButton.PerformClick();
                }
            }
        }

        private void SerialSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            if (sortByComboBox.SelectedIndex != -1)
            {
                sortByComboBox.DataSource = null;
            }

            if (serialSearchTextBox.Text.Trim() == "")
            {
                if (lastClickedButton != null)
                {
                    lastClickedButton.PerformClick();
                }
                else
                {
                    everythingButton.PerformClick();
                }
            }
            else
            {
                List<MyButton> searchHere = new List<MyButton>();
                for (int i = 0; i < 4; i++)
                {
                    if (searchTextBoxes[i] != serialSearchTextBox && searchTextBoxes[i].Text != "")
                    {
                        searchHere = GetButtonsInFlowlayout();
                        break;
                    }
                    else if (i == 3)
                    {
                        searchHere = savedFlowLayoutPanelControls;
                    }
                }

                int buttonsCount = searchHere.Count;
                flowLayoutPanel1.Controls.Clear();
                for (int i = 0; i < buttonsCount; i++)
                {
                    if ((searchHere[i].Tag as Components).SerialNumber.Trim().ToLower()
                        .Contains(serialSearchTextBox.Text.Trim().ToLower()))
                    {
                        flowLayoutPanel1.Controls.Add(searchHere[i]);
                    }
                }
            }
        }

        private void SerialSearchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == (Keys.Back) && serialSearchTextBox.Text != "")
            {
                if (lastClickedButton != null)
                {
                    lastClickedButton.PerformClick();
                }
                else
                {
                    everythingButton.PerformClick();
                }
            }
        }
        private void TextSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            if (sortByComboBox.SelectedIndex != -1)
            {
                sortByComboBox.DataSource = null;
            }

            if (textSearchTextBox.Text.Trim() == "")
            {
                if (lastClickedButton != null)
                {
                    lastClickedButton.PerformClick();
                }
                else
                {
                    everythingButton.PerformClick();
                }
            }
            else
            {
                List<MyButton> searchHere = new List<MyButton>();
                for (int i = 0; i < 4; i++)
                {
                    if (searchTextBoxes[i] != textSearchTextBox && searchTextBoxes[i].Text != "")
                    {
                        searchHere = GetButtonsInFlowlayout();
                        break;
                    }
                    else if (i == 3)
                    {
                        searchHere = savedFlowLayoutPanelControls;
                    }
                }

                int buttonsCount = searchHere.Count;
                flowLayoutPanel1.Controls.Clear();
                for (int i = 0; i < buttonsCount; i++)
                {
                    if ((searchHere[i].Tag as Components).Text.Trim().ToLower()
                        .Contains(textSearchTextBox.Text.Trim().ToLower()))
                    {
                        flowLayoutPanel1.Controls.Add(searchHere[i]);
                    }
                }
            }
        }
        private void TextSearchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == (Keys.Back) && textSearchTextBox.Text != "")
            {
                if (lastClickedButton != null)
                {
                    lastClickedButton.PerformClick();
                }
                else
                {
                    everythingButton.PerformClick();
                }
            }
        }

        private void SearchInAll(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                if (searchTextBoxes[i] != (sender as TextBox) && searchTextBoxes[i].Text != "")
                {
                    if ((searchTextBoxes[i] as TextBox) == productSearchTextBox)
                    {
                        ProductSearchTextBox_TextChanged(null, null);
                    }
                    else if ((searchTextBoxes[i] as TextBox) == manufacturerSearchTextBox)
                    {
                        ManufacturerSearchTextBox_TextChanged(null, null);
                    }
                    else if ((searchTextBoxes[i] as TextBox) == serialSearchTextBox)
                    {
                        SerialSearchTextBox_TextChanged(null, null);
                    }
                    else if ((searchTextBoxes[i] as TextBox) == textSearchTextBox)
                    {
                        TextSearchTextBox_TextChanged(null, null);
                    }
                }
            }
        }

        //SEARCH DOESN'T WORK AS INTENDED, FIX IT!
        private bool searchFocus;
        private void SearchGotFocus(object sender, EventArgs e)
        {
            searchFocus = true;
        }
        private void SearchLostFocus(object sender, EventArgs e)
        {
            searchFocus = false;
        }
        private void FlowLayoutPanel1_ControlChanged(object sender, ControlEventArgs e)
        {
            if (searchFocus || sender == null)
            {
                savedFlowLayoutPanelControls = new List<MyButton>();
                int a = flowLayoutPanel1.Controls.Count;
                int b = savedFlowLayoutPanelControls.Count;
                if (a == b)
                {
                    for (int i = 0; i < b; i++)
                    {
                        if (!flowLayoutPanel1.Controls.Contains(savedFlowLayoutPanelControls[i]))
                        {
                            for (int j = 0; j < a; j++)
                            {
                                //IMPLEMENT COMPUTERS!
                                if ((flowLayoutPanel1.Controls[j] as MyButton).Tag != null)
                                {
                                    savedFlowLayoutPanelControls.Add(flowLayoutPanel1.Controls[j] as MyButton);
                                }
                            }
                        }
                    }
                }
                else
                {
                    for (int j = 0; j < a; j++)
                    {
                        //IMPLEMENT COMPUTERS!
                        if ((flowLayoutPanel1.Controls[j] as MyButton).Tag != null)
                        {
                            savedFlowLayoutPanelControls.Add(flowLayoutPanel1.Controls[j] as MyButton);
                        }
                    }
                }
            }
        }

        //IMPLEMENT COMPUTERS!
        private List<MyButton> GetButtonsInFlowlayout()
        {
            List<MyButton> flowLayoutButtons = new List<MyButton>();
            int flowLayoutControlsCount = flowLayoutPanel1.Controls.Count;
            for (int i = 0; i < flowLayoutControlsCount; i++)
            {
                if (flowLayoutPanel1.Controls[i].Text != "Computer")
                {
                    flowLayoutButtons.Add(flowLayoutPanel1.Controls[i] as MyButton);
                }
            }

            return flowLayoutButtons;
        }

        #endregion

        #region Exit, minimize and social buttons

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void FacebookButton_MouseEnter(object sender, EventArgs e)
        {
            facebookButton.Image = Resources.facebook_colored;
        }

        private void FacebookButton_MouseLeave(object sender, EventArgs e)
        {
            facebookButton.Image = Resources.facebook;
        }

        private void InstagramButton_MouseEnter(object sender, EventArgs e)
        {
            instagramButton.Image = Resources.instagram_colored;
        }

        private void InstagramButton_MouseLeave(object sender, EventArgs e)
        {
            instagramButton.Image = Resources.instagram;
        }

        private void TwitterButton_MouseEnter(object sender, EventArgs e)
        {
            twitterButton.Image = Resources.twitter_colored;
        }

        private void TwitterButton_MouseLeave(object sender, EventArgs e)
        {
            twitterButton.Image = Resources.twitter;
        }

        #endregion
    }
}


/* 
 * STYLECOP!
 */
