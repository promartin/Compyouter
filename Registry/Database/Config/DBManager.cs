using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
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
using Registry.Classes.Users;
using FormFactor = Registry.Classes.Components.Motherboard.FormFactor;

namespace Registry.Database.Config
{
    class DBManager
    {
        private static SqlConnection connection;
        private static SqlCommand command;

        static void Connect(bool componentsOrUsers)
        {
            try
            {
                if (componentsOrUsers)
                {
                    connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Components"].ConnectionString);
                    connection.Open();
                    command = new SqlCommand();
                    command.Connection = connection;
                }
                else
                {
                    connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Users"].ConnectionString);
                    connection.Open();
                    command = new SqlCommand();
                    command.Connection = connection;
                }
            }
            catch (Exception e)
            {
                throw new DBError("Database connection failed!", e);
            }
        }

        internal static void Insert(Components component)
        {
            Connect(true);
            SqlTransaction transaction = null;

            try
            {
                command.Parameters.Clear();
                transaction = connection.BeginTransaction("Insert");
                command.Transaction = transaction;
                command.CommandText =
                    "INSERT INTO [Component] VALUES (@manufacturer, @productName, @serialNumber, @price, @dateOfPurchase, @dateOfAdd, @warranty, @text)";
                command.Parameters.AddWithValue("@manufacturer", component.Manufacturer);
                command.Parameters.AddWithValue("@productName", component.ProductsName);
                command.Parameters.AddWithValue("@serialNumber", component.SerialNumber != " " ? component.SerialNumber : " ");
                command.Parameters.AddWithValue("@price", component.Price);
                command.Parameters.AddWithValue("@dateOfPurchase", component.DateOfPurchase);
                command.Parameters.AddWithValue("@dateOfAdd", component.DateOfAdd);
                command.Parameters.AddWithValue("@warranty", component.Warranty);
                command.Parameters.AddWithValue("@text", component.Text == " " ? " " : component.Text);

                command.ExecuteNonQuery();
                command.Parameters.Clear();

                //Selecting and saving current Id........///////////////////
                command.CommandText = "SELECT IDENT_CURRENT('Component')";//
                var i = command.ExecuteScalar();                          //
                command.Parameters.Clear();                               //
                ////////////////////////////////////////////////////////////

                if (component is Processor)
                {
                    command.CommandText =
                        "INSERT INTO [Processor] VALUES (@Id, @l2Cache, @l3Cache, @cores, @threads, @process, @frequency, @turboFrequency, @tdp)";
                    command.Parameters.AddWithValue("@Id", i);
                    command.Parameters.AddWithValue("@l2Cache", (int)(component as Processor).L2Cache);
                    command.Parameters.AddWithValue("@l3Cache", (int)(component as Processor).L3Cache);
                    command.Parameters.AddWithValue("@cores", (int)(component as Processor).Cores);
                    command.Parameters.AddWithValue("@threads", (component as Processor).Threads);
                    command.Parameters.AddWithValue("@process", (int)(component as Processor).Process);
                    command.Parameters.AddWithValue("@frequency", (component as Processor).Frequency);
                    command.Parameters.AddWithValue("@turboFrequency", (component as Processor).TurboFrequency);
                    command.Parameters.AddWithValue("@tdp", (int)(component as Processor).Tdp);

                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                    if (component is AMDProcessor)
                    {
                        command.CommandText =
                            "INSERT INTO [AMDProcessor] VALUES (@Id, @amdSocket, @integratedGraphics)";
                        command.Parameters.AddWithValue("@Id", i);
                        command.Parameters.AddWithValue("@amdSocket", (component as AMDProcessor).AmdSocket);
                        command.Parameters.AddWithValue("@integratedGraphics", (component as AMDProcessor).IntegratedGraphics != "" ? (component as AMDProcessor).IntegratedGraphics : "");
                    }
                    else if (component is IntelProcessor)
                    {
                        command.CommandText =
                            "INSERT INTO [IntelProcessor] VALUES (@Id, @intelSocket, @integratedGraphics)";
                        command.Parameters.AddWithValue("@Id", i);
                        command.Parameters.AddWithValue("@intelSocket", (component as IntelProcessor).IntelSocket);
                        command.Parameters.AddWithValue("@integratedGraphics", (component as IntelProcessor).IntegratedGraphics != "" ? (component as IntelProcessor).IntegratedGraphics : "");
                    }
                }
                else if (component is RAM)
                {
                    command.CommandText =
                        "INSERT INTO [RAM] VALUES (@Id, @ramGeneration, @size, @frequency, @latency, @pieces, @ecc, @rgb)";
                    command.Parameters.AddWithValue("@Id", i);
                    command.Parameters.AddWithValue("@ramGeneration", (component as RAM).RamGeneration);
                    command.Parameters.AddWithValue("@size", (component as RAM).Size);
                    command.Parameters.AddWithValue("@frequency", (component as RAM).Frequency);
                    command.Parameters.AddWithValue("@latency", (component as RAM).Latency);
                    command.Parameters.AddWithValue("@pieces", (component as RAM).Pieces);
                    command.Parameters.AddWithValue("@ecc", (component as RAM).Ecc ? 1 : 0);
                    command.Parameters.AddWithValue("@rgb", (component as RAM).Rgb ? 1 : 0);
                }
                else if (component is Motherboard)
                {
                    command.CommandText =
                        "INSERT INTO [Motherboard] VALUES (@Id, @formFactor, @socket, @memoryGeneration, @crossfire, @sli, @bluetooth, @wifi, @m2x4Number, @memorySlots, @maxMemorySize, @pciEX16Slots, @pciEX4Slots, @pciEX1Slots, @sata3Connectors, @usb30, @usb31, @lan)";
                    command.Parameters.AddWithValue("@Id", i);
                    command.Parameters.AddWithValue("@formFactor", (component as Motherboard).FormFactor);
                    command.Parameters.AddWithValue("@socket", (component as Motherboard).Socket);
                    command.Parameters.AddWithValue("@memoryGeneration", (component as Motherboard).MemoryGeneration);
                    command.Parameters.AddWithValue("@crossfire", (component as Motherboard).Crossfire ? 1 : 0);
                    command.Parameters.AddWithValue("@sli", (component as Motherboard).Sli ? 1 : 0);
                    command.Parameters.AddWithValue("@bluetooth", (component as Motherboard).Bluetooth ? 1 : 0);
                    command.Parameters.AddWithValue("@wifi", (component as Motherboard).Wifi ? 1 : 0);
                    command.Parameters.AddWithValue("@m2x4Number", (component as Motherboard).M2x4Number);
                    command.Parameters.AddWithValue("@memorySlots", (component as Motherboard).MemorySlots);
                    command.Parameters.AddWithValue("@maxMemorySize", (component as Motherboard).MaxMemorySize);
                    command.Parameters.AddWithValue("@pciEX16Slots", (component as Motherboard).PciE_x16_Slots);
                    command.Parameters.AddWithValue("@pciEX4Slots", (component as Motherboard).PciE_x4_Slots);
                    command.Parameters.AddWithValue("@pciEX1Slots", (component as Motherboard).PciE_x1_Slots);
                    command.Parameters.AddWithValue("@sata3Connectors", (component as Motherboard).Sata3Connectors);
                    command.Parameters.AddWithValue("@usb30", (component as Motherboard).Usb30);
                    command.Parameters.AddWithValue("@usb31", (component as Motherboard).Usb31);
                    command.Parameters.AddWithValue("@lan", (component as Motherboard).Lan);
                }
                else if (component is Videocard)
                {
                    command.CommandText = "INSERT INTO [Videocard] VALUES (@Id, @gb, @design, @tdp, @pcieConnector, @videoCardLength)";
                    command.Parameters.AddWithValue("@Id", i);
                    command.Parameters.AddWithValue("@gb", (component as Videocard).Gb);
                    command.Parameters.AddWithValue("@design", (component as Videocard).Design);
                    command.Parameters.AddWithValue("@tdp", (component as Videocard).Tdp);
                    command.Parameters.AddWithValue("@pcieConnector", (component as Videocard).PcieConnector);
                    command.Parameters.AddWithValue("@videoCardLength", (component as Videocard).VideoCardLength);
                }
                else if (component is Storage)
                {
                    command.CommandText =
                        "INSERT INTO [Storages] VALUES (@Id, @gb, @connectorType, @condition, @size)";
                    command.Parameters.AddWithValue("@Id", i);
                    command.Parameters.AddWithValue("@gb", (component as Storage).Gb);
                    command.Parameters.AddWithValue("@connectorType", (component as Storage).ConnectorType);
                    command.Parameters.AddWithValue("@condition", (component as Storage).Condition);
                    command.Parameters.AddWithValue("@size", (component as Storage).size);

                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                    if (component is HDD)
                    {
                        command.CommandText =
                            "INSERT INTO [HDD] VALUES (@Id, @rpm, @bufferSize)";
                        command.Parameters.AddWithValue("@Id", i);
                        command.Parameters.AddWithValue("@rpm", (component as HDD).Rpm);
                        command.Parameters.AddWithValue("@bufferSize", (component as HDD).BufferSize);
                    }
                    else
                    {
                        command.CommandText = "INSERT INTO [SSD] VALUES (@Id, @writeSpeed, @readSpeed, @technology)";
                        command.Parameters.AddWithValue("@Id", i);
                        command.Parameters.AddWithValue("@writeSpeed", (component as SSD).WriteSpeed);
                        command.Parameters.AddWithValue("@readSpeed", (component as SSD).ReadSpeed);
                        command.Parameters.AddWithValue("@technology", (component as SSD).Technology);
                    }
                }
                else if (component is PowerSupply)
                {
                    command.CommandText = "INSERT INTO [PowerSupply] VALUES (@Id, @output, @efficency, @sata, @pcie, @molex, @modular, @formFactor)";
                    command.Parameters.AddWithValue("@Id", i);
                    command.Parameters.AddWithValue("@output", (component as PowerSupply).Output);
                    command.Parameters.AddWithValue("@efficency", (component as PowerSupply).Efficency);
                    command.Parameters.AddWithValue("@sata", (component as PowerSupply).Sata);
                    command.Parameters.AddWithValue("@pcie", (component as PowerSupply).Pcie);
                    command.Parameters.AddWithValue("@molex", (component as PowerSupply).Molex);
                    command.Parameters.AddWithValue("@modular", (component as PowerSupply).Modular ? 1 : 0);
                    command.Parameters.AddWithValue("@formFactor", (component as PowerSupply).FormFactor);

                }
                else if (component is Case)
                {
                    command.CommandText =
                        "INSERT INTO [Case] VALUES (@Id, @atx, @eatx, @microATX, @miniITX, @miniSTX, @thinMiniITX, @caseFormFactor, @hddSpace, @slimHdDspace, @cpuHeatSinkHeight, @videoCardLength, @bottomSupply)";
                    command.Parameters.AddWithValue("@Id", i);
                    command.Parameters.AddWithValue("@atx", (component as Case).Atx ? 1 : 0);
                    command.Parameters.AddWithValue("@eatx", (component as Case).Eatx ? 1 : 0);
                    command.Parameters.AddWithValue("@microATX", (component as Case).MicroATX ? 1 : 0);
                    command.Parameters.AddWithValue("@miniITX", (component as Case).MiniITX ? 1 : 0);
                    command.Parameters.AddWithValue("@miniSTX", (component as Case).MiniSTX ? 1 : 0);
                    command.Parameters.AddWithValue("@thinMiniITX", (component as Case).ThinMiniITX ? 1 : 0);
                    command.Parameters.AddWithValue("@caseFormFactor", (component as Case).CaseFormFactor);
                    command.Parameters.AddWithValue("@hddSpace", (component as Case).HddSpace);
                    command.Parameters.AddWithValue("@slimHdDspace", (component as Case).SlimHDDspace);
                    command.Parameters.AddWithValue("@cpuHeatSinkHeight", (component as Case).CpuHeatSinkHeight);
                    command.Parameters.AddWithValue("@videoCardLength", (component as Case).VideoCardLength);
                    command.Parameters.AddWithValue("@bottomSupply", (component as Case).BottomSupply ? 1 : 0);
                }
                else if (component is Cooler)
                {
                    command.CommandText = "INSERT INTO [Cooler] VALUES (@Id, @lga1151, @lga2066, @lga2011, @lga1366, @lga775, @fm122Plus3Plus, @am4, @am22Plus33Plus, @tr4, @height)";
                    command.Parameters.AddWithValue("@Id", i);
                    command.Parameters.AddWithValue("@lga1151", (component as Cooler).Lga1151 ? 1 : 0);
                    command.Parameters.AddWithValue("@lga2066", (component as Cooler).Lga2066 ? 1 : 0);
                    command.Parameters.AddWithValue("@lga2011", (component as Cooler).Lga2011 ? 1 : 0);
                    command.Parameters.AddWithValue("@lga1366", (component as Cooler).Lga1366 ? 1 : 0);
                    command.Parameters.AddWithValue("@lga775", (component as Cooler).Lga775 ? 1 : 0);
                    command.Parameters.AddWithValue("@fm122Plus3Plus", (component as Cooler).Fm122plus3plus ? 1 : 0);
                    command.Parameters.AddWithValue("@am4", (component as Cooler).Am4 ? 1 : 0);
                    command.Parameters.AddWithValue("@am22Plus33Plus", (component as Cooler).AM22plus33plus ? 1 : 0);
                    command.Parameters.AddWithValue("@tr4", (component as Cooler).Tr4 ? 1 : 0);
                    command.Parameters.AddWithValue("@height", (component as Cooler).Height);
                }


                command.ExecuteNonQuery();
                command.Parameters.Clear();
                transaction.Commit();
            }

            catch (Exception e)
            {
                transaction.Rollback();
                throw new DBError("Component insertion failed!", e);
            }

            Disconnect();
        }

        internal static void Insert(Computer computer)
        {
            Connect(true);
            SqlTransaction transaction = null;

            try
            {
                //Making string out of ids
                int house = SelectID((Case)computer.House);
                int cooler = SelectID((Cooler)computer.Cooler);
                int motherboard = SelectID((Motherboard)computer.Motherboard);
                int powerSupply = SelectID((PowerSupply)computer.PowerSupply);
                int intelProcessor = 0;
                int amdProcessor = 0;
                if (computer.IntelProcessor != null)
                {
                    intelProcessor = SelectID((Processor)computer.IntelProcessor);
                }
                else
                {
                    amdProcessor = SelectID((Processor)computer.AmdProcessor);
                }
                string[] componentIdStrings = new string[4];
                componentIdStrings[0] = GetIdsOfList(new List<Components>(computer.Rams));
                componentIdStrings[1] = GetIdsOfList(new List<Components>(computer.Hdds));
                componentIdStrings[2] = GetIdsOfList(new List<Components>(computer.Ssds));
                componentIdStrings[3] = GetIdsOfList(new List<Components>(computer.Videocards));

                command.Parameters.Clear();
                transaction = connection.BeginTransaction("Computer insert");
                command.Transaction = transaction;

                command.CommandText = "INSERT INTO [Computer] VALUES (@case, @cooler, @motherboard, @powerSupply, @processor, @ram, @hdd, @ssd, @videocard)";
                command.Parameters.AddWithValue("@case", house);
                command.Parameters.AddWithValue("@cooler", cooler);
                command.Parameters.AddWithValue("@motherboard", motherboard);
                command.Parameters.AddWithValue("@powerSupply", powerSupply);
                if (computer.IntelProcessor != null)
                {
                    command.Parameters.AddWithValue("@processor", intelProcessor);
                }
                else
                {
                    command.Parameters.AddWithValue("@processor", amdProcessor);
                }
                command.Parameters.AddWithValue("@ram", componentIdStrings[0]);
                command.Parameters.AddWithValue("@hdd", componentIdStrings[1]);
                command.Parameters.AddWithValue("@ssd", componentIdStrings[2]);
                command.Parameters.AddWithValue("@videocard", componentIdStrings[3]);

                command.ExecuteNonQuery();
                command.Parameters.Clear();
                transaction.Commit();

                string GetIdsOfList(List<Components> computerParts)
                {
                    string ids = "";
                    for (int a = 0; a < computerParts.Count; a++)
                    {
                        ids += SelectID(computerParts[a]) + ", ";
                        if (a == computerParts.Count)
                        {
                            ids += SelectID(computerParts[a]);
                        }
                    }
                    return ids;
                }
            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw new DBError("Computer insertion failed!", e);
            }

            Disconnect();
        }

        internal static void Register(User registerUser)
        {
            Connect(false);
            SqlTransaction transaction = null;

            try
            {
                command.Parameters.Clear();
                transaction = connection.BeginTransaction("Register");
                command.Transaction = transaction;

                command.CommandText = "SELECT COUNT([userId]) FROM [Users] WHERE [userName] = @userName";
                command.Parameters.AddWithValue("@userName", registerUser.UserName);
                int usersWithThisName = (int) command.ExecuteScalar();

                if (usersWithThisName == 0)
                {
                    command.Parameters.Clear();

                    command.CommandText = "SELECT COUNT([userId]) FROM [Users] WHERE email = @email";
                    command.Parameters.AddWithValue("@email", registerUser.Email);
                    int usersWithThisEmail = (int)command.ExecuteScalar();

                    if (usersWithThisEmail == 0)
                    {
                        command.Parameters.Clear();

                        command.CommandText =
                            "INSERT INTO [Users] VALUES (@userName, @email, @password)";
                        command.Parameters.AddWithValue("@userName", registerUser.UserName);
                        command.Parameters.AddWithValue("@email", registerUser.Email);
                        command.Parameters.AddWithValue("@password", PasswordHash.HashPassword(registerUser.Password));

                        command.ExecuteNonQuery();
                        command.Parameters.Clear();
                        transaction.Commit();
                    }
                    else
                    {
                        throw new ArgumentException("This E-mail is already in use!");
                    }
                }
                else
                {
                    throw new ArgumentException("This username is in use!");
                }
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }

            Disconnect();
        }

        internal static User Login(User loginUser)
        {
            Connect(false);
            SqlTransaction transaction = null;

            try
            {
                command.Parameters.Clear();
                transaction = connection.BeginTransaction("Login");
                command.Transaction = transaction;

                command.CommandText =
                    "SELECT [password] FROM [Users] WHERE [userName] = @userName";
                command.Parameters.AddWithValue("@userName", loginUser.UserName);
                string hashedPassword = command.ExecuteScalar() as string;
                if (hashedPassword != null)
                {
                    if (PasswordHash.ValidatePassword(loginUser.Password, hashedPassword))
                    {
                        command.Parameters.Clear();

                        command.CommandText =
                            "SELECT [userName], [email], [userId] FROM [Users] WHERE [userName] = @userName";
                        command.Parameters.AddWithValue("@userName", loginUser.UserName);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                return new User((string) reader[0], (string) reader[1], Convert.ToInt32(reader[2]));
                            }
                        }
                    }
                    else
                    {
                        throw new ArgumentException("Wrong password!");
                    }
                }
                else
                {
                    throw new ArgumentException("There is no user named like that!");
                }
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }

            return null;
        }
        internal static List<Components> Read()
        {
            Connect(true);
            SqlTransaction transaction = null;
            List<Components> components = new List<Components>();

            try
            {
                command.Parameters.Clear();
                transaction = connection.BeginTransaction("Read");
                command.Transaction = transaction;

                #region AMDProcessor
                //Everything from AMDProcessor
                command.CommandText = "SELECT * FROM([AMDProcessor] INNER JOIN [Component] ON AMDProcessor.Id = Component.Id) INNER JOIN [Processor] ON Component.Id = Processor.Id";

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        components.Add(new AMDProcessor(reader["manufacturer"].ToString(), reader["productsName"].ToString(), reader["serialNumber"].ToString(), (int)reader["price"], (DateTime)reader["dateOfPurchase"], (DateTime)reader["dateOfAdd"], (DateTime)reader["warranty"], reader["text"].ToString(), Convert.ToDouble(reader["l2Cache"]), Convert.ToDouble(reader["l3Cache"]), (int)reader["cores"], (int)reader["threads"], (int)reader["process"], (int)reader["frequency"], (int)reader["turboFrequency"], (int)reader["tdp"], (AMDSocket)reader["amdSocket"], reader["integratedGraphics"].ToString()));
                    }
                }
                #endregion

                #region IntelProcessor
                //Everything from IntelProcessor
                command.CommandText = "SELECT * FROM([IntelProcessor] INNER JOIN [Component] ON IntelProcessor.Id = Component.Id) INNER JOIN [Processor] ON Component.Id = Processor.Id";

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        components.Add(new IntelProcessor(reader["manufacturer"].ToString(), reader["productsName"].ToString(), reader["serialNumber"].ToString(), (int)reader["price"], (DateTime)reader["dateOfPurchase"], (DateTime)reader["dateOfAdd"], (DateTime)reader["warranty"], reader["text"].ToString(), Convert.ToDouble(reader["l2Cache"]), Convert.ToDouble(reader["l3Cache"]), (int)reader["cores"], (int)reader["threads"], (int)reader["process"], (int)reader["frequency"], (int)reader["turboFrequency"], (int)reader["tdp"], (IntelSocket)reader["intelSocket"], reader["integratedGraphics"].ToString()));
                    }
                }
                #endregion

                #region RAM
                //Everything from RAM
                command.CommandText = "SELECT * FROM [Component] INNER JOIN [RAM] ON Component.Id = RAM.Id";

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        components.Add(new RAM(reader["manufacturer"].ToString(), reader["productsName"].ToString(), reader["serialNumber"].ToString(), (int)reader["price"], (DateTime)reader["dateOfPurchase"], (DateTime)reader["dateOfAdd"], (DateTime)reader["warranty"], reader["text"].ToString(), (RAMGeneration)reader["ramGeneration"], (int)reader["size"], (int)reader["frequency"], (int)reader["latency"], (int)reader["pieces"], (int)reader["ecc"] == 1 ? true : false, (int)reader["rgb"] == 1 ? true : false));
                    }
                }
                #endregion

                #region Motherboard
                //Everything from Motherboard
                command.CommandText = "SELECT * FROM [Component] INNER JOIN [Motherboard] ON Component.Id = Motherboard.Id";

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        components.Add(new Motherboard(reader["manufacturer"].ToString(), reader["productsName"].ToString(), reader["serialNumber"].ToString(), (int)reader["price"], (DateTime)reader["dateOfPurchase"], (DateTime)reader["dateOfAdd"], (DateTime)reader["warranty"], reader["text"].ToString(), (FormFactor)reader["formFactor"], (Socket)reader["socket"], (MemoryGeneration)reader["memoryGeneration"], (int)reader["crossfire"] == 1 ? true : false, (int)reader["sli"] == 1 ? true : false, (int)reader["bluetooth"] == 1 ? true : false, (int)reader["wifi"] == 1 ? true : false, (int)reader["m2x4Number"], (int)reader["memorySlots"], (int)reader["maxMemorySize"], (int)reader["pciE_x16_Slots"], (int)reader["pciE_x4_Slots"], (int)reader["pciE_x1_Slots"], (int)reader["sata3Connectors"], (int)reader["usb30"], (int)reader["usb31"], (int)reader["lan"]));
                    }
                }
                #endregion

                #region Videocard
                //Everything from Videocard
                command.CommandText = "SELECT * FROM [Videocard] INNER JOIN [Component] ON Videocard.Id = Component.Id";

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        components.Add(new Videocard(reader["manufacturer"].ToString(), reader["productsName"].ToString(), reader["serialNumber"].ToString(), (int)reader["price"], (DateTime)reader["dateOfPurchase"], (DateTime)reader["dateOfAdd"], (DateTime)reader["warranty"], reader["text"].ToString(), Convert.ToDouble(reader["gb"]), (Design)reader["design"], (int)reader["tdp"], (int)reader["pcieConnector"], (int)reader["videoCardLength"]));
                    }
                }
                #endregion

                #region HDD
                //Everything from HDD
                command.CommandText = "SELECT * FROM([HDD] INNER JOIN [Component] ON HDD.Id = Component.Id) INNER JOIN [Storages] ON Component.Id = Storages.Id";

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        components.Add(new HDD(reader["manufacturer"].ToString(), reader["productsName"].ToString(), reader["serialNumber"].ToString(), (int)reader["price"], (DateTime)reader["dateOfPurchase"], (DateTime)reader["dateOfAdd"], (DateTime)reader["warranty"], reader["text"].ToString(), (int)reader["gb"], (ConnectorType)reader["connectorType"], (int)reader["condition"], (StorageSize)reader["size"], (int)reader["rpm"], (int)reader["bufferSize"]));
                    }
                }
                #endregion

                #region SSD
                //Everything from SSD
                command.CommandText = "SELECT * FROM([SSD] INNER JOIN [Component] ON SSD.Id = Component.Id) INNER JOIN [Storages] ON Component.Id = Storages.Id";
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        components.Add(new SSD(reader["manufacturer"].ToString(), reader["productsName"].ToString(), reader["serialNumber"].ToString(), (int)reader["price"], (DateTime)reader["dateOfPurchase"], (DateTime)reader["dateOfAdd"], (DateTime)reader["warranty"], reader["text"].ToString(), (int)reader["gb"], (ConnectorType)reader["connectorType"], (int)reader["condition"], (StorageSize)reader["size"], (int)reader["writeSpeed"], (int)reader["readSpeed"], (Technology)reader["technology"]));
                    }
                }
                #endregion

                #region PowerSupply
                //Everything from PowerSupply
                command.CommandText = "SELECT * FROM [Component] INNER JOIN [PowerSupply] ON Component.Id = PowerSupply.Id";
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        components.Add(new PowerSupply(reader["manufacturer"].ToString(), reader["productsName"].ToString(), reader["serialNumber"].ToString(), (int)reader["price"], (DateTime)reader["dateOfPurchase"], (DateTime)reader["dateOfAdd"], (DateTime)reader["warranty"], reader["text"].ToString(), (int)reader["output"], (Efficency)reader["efficency"], (int)reader["sata"], (int)reader["pcie"], (int)reader["molex"], (int)reader["modular"] == 1 ? true : false, (Classes.Components.PowerSupply.FormFactor)reader["formFactor"]));
                    }
                }
                #endregion

                #region Case
                //Everything from Case
                command.CommandText = "SELECT * FROM [Component] INNER JOIN [Case] ON [Component].[Id] = [Case].[Id]";
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        components.Add(new Case(reader["manufacturer"].ToString(), reader["productsName"].ToString(), reader["serialNumber"].ToString(), (int)reader["price"], (DateTime)reader["dateOfPurchase"], (DateTime)reader["dateOfAdd"], (DateTime)reader["warranty"], reader["text"].ToString(), (int)reader["bottomSupply"] == 1 ? true : false, (CaseFormFactor)reader["caseFormFactor"], (int)reader["atx"] == 1 ? true : false, (int)reader["eatx"] == 1 ? true : false, (int)reader["microATX"] == 1 ? true : false, (int)reader["miniITX"] == 1 ? true : false, (int)reader["miniSTX"] == 1 ? true : false, (int)reader["thinMiniITX"] == 1 ? true : false, (int)reader["hddSpace"], (int)reader["slimHddSpace"], (int)reader["cpuHeatSinkHeight"], (int)reader["videoCardLength"]));
                    }
                }
                #endregion

                #region Cooler
                //Everything from Cooler
                command.CommandText = "SELECT * FROM [Component] INNER JOIN [Cooler] ON Component.Id = Cooler.Id";
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        components.Add(new Cooler(reader["manufacturer"].ToString(), reader["productsName"].ToString(), reader["serialNumber"].ToString(), (int)reader["price"], (DateTime)reader["dateOfPurchase"], (DateTime)reader["dateOfAdd"], (DateTime)reader["warranty"], reader["text"].ToString(), (int)reader["lga1151"] == 1 ? true : false, (int)reader["lga2066"] == 1 ? true : false, (int)reader["lga2011"] == 1 ? true : false, (int)reader["lga1366"] == 1 ? true : false, (int)reader["lga775"] == 1 ? true : false, (int)reader["fm122plus3plus"] == 1 ? true : false, (int)reader["am4"] == 1 ? true : false, (int)reader["aM22plus33plus"] == 1 ? true : false, (int)reader["tr4"] == 1 ? true : false, (int)reader["height"]));
                    }
                }
                #endregion

            }
            catch (Exception e)
            {
                throw new DBError("Components read failure!", e);
            }

            Disconnect();
            return components;
        }

        internal static Components ReadCucc()
        {
            Connect(true);
            Components components = null;

            try
            {
                command.Parameters.Clear();

                List<Computer> computers = new List<Computer>();

                command.CommandText = "SELECT * FROM [Computer] INNER JOIN [Case] ON Computer.case = Case.Id";
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        components = new Case(reader["manufacturer"].ToString(), reader["productsName"].ToString(), reader["serialNumber"].ToString(), (int)reader["price"], (DateTime)reader["dateOfPurchase"], (DateTime)reader["dateOfAdd"], (DateTime)reader["warranty"], reader["text"].ToString(), (int)reader["bottomSupply"] == 1 ? true : false, (CaseFormFactor)reader["caseFormFactor"], (int)reader["atx"] == 1 ? true : false, (int)reader["eatx"] == 1 ? true : false, (int)reader["microATX"] == 1 ? true : false, (int)reader["miniITX"] == 1 ? true : false, (int)reader["miniSTX"] == 1 ? true : false, (int)reader["thinMiniITX"] == 1 ? true : false, (int)reader["hddSpace"], (int)reader["slimHddSpace"], (int)reader["cpuHeatSinkHeight"], (int)reader["videoCardLength"]);
                    }
                }
            }
            catch (Exception e)
            {
                throw new DBError("Computer read failure!", e); ;
            }

            Disconnect();
            return components;
        }

        internal static void Modification(Components editComponent, Components toThisComponent)
        {
            Connect(true);
            SqlTransaction transaction = null;

            try
            {
                int i = SelectID(editComponent);

                command.Parameters.Clear();
                transaction = connection.BeginTransaction("Modification");
                command.Transaction = transaction;

                command.CommandText = "UPDATE [Component] SET [manufacturer] = @manufacturer, [productsName] = @productsName, [serialNumber] = @serialNumber, [price] = @price, [dateOfPurchase] = @dateOfPurchase, [dateOfAdd] = @dateOfAdd, [warranty] = @warranty, [text] = @text WHERE [Id] = @Id";
                command.Parameters.AddWithValue("@Id", i);
                command.Parameters.AddWithValue("@manufacturer", toThisComponent.Manufacturer);
                command.Parameters.AddWithValue("@productsName", toThisComponent.ProductsName);
                command.Parameters.AddWithValue("@serialNumber", toThisComponent.SerialNumber != "" ? toThisComponent.SerialNumber : "");
                command.Parameters.AddWithValue("@price", toThisComponent.Price);
                command.Parameters.AddWithValue("@dateOfPurchase", toThisComponent.DateOfPurchase);
                command.Parameters.AddWithValue("@dateOfAdd", toThisComponent.DateOfAdd);
                command.Parameters.AddWithValue("@warranty", toThisComponent.Warranty);
                command.Parameters.AddWithValue("@text", toThisComponent.Text == "" ? "" : toThisComponent.Text);

                command.ExecuteNonQuery();
                command.Parameters.Clear();

                if (toThisComponent is Case)
                {
                    command.CommandText =
                        "UPDATE [Case] SET [atx] = @atx, [eatx] = @eatx, [microATX] = @microATX, [miniITX] = @miniITX, [miniSTX] = @miniSTX, [thinMiniITX] = @thinMiniITX, [caseFormFactor] = @caseFormFactor, [hddSpace] = @hddSpace, [slimHdDspace] = @slimHdDspace, [cpuHeatSinkHeight] = @cpuHeatSinkHeight, [videoCardLength] = @videoCardLength, [bottomSupply] = @bottomSupply WHERE [Id] = @Id";
                    command.Parameters.AddWithValue("@Id", i);
                    command.Parameters.AddWithValue("@atx", (toThisComponent as Case).Atx ? 1 : 0);
                    command.Parameters.AddWithValue("@eatx", (toThisComponent as Case).Eatx ? 1 : 0);
                    command.Parameters.AddWithValue("@microATX", (toThisComponent as Case).MicroATX ? 1 : 0);
                    command.Parameters.AddWithValue("@miniITX", (toThisComponent as Case).MiniITX ? 1 : 0);
                    command.Parameters.AddWithValue("@miniSTX", (toThisComponent as Case).MiniSTX ? 1 : 0);
                    command.Parameters.AddWithValue("@thinMiniITX", (toThisComponent as Case).ThinMiniITX ? 1 : 0);
                    command.Parameters.AddWithValue("@caseFormFactor", (toThisComponent as Case).CaseFormFactor);
                    command.Parameters.AddWithValue("@hddSpace", (toThisComponent as Case).HddSpace);
                    command.Parameters.AddWithValue("@slimHdDspace", (toThisComponent as Case).SlimHDDspace);
                    command.Parameters.AddWithValue("@cpuHeatSinkHeight", (toThisComponent as Case).CpuHeatSinkHeight);
                    command.Parameters.AddWithValue("@videoCardLength", (toThisComponent as Case).VideoCardLength);
                    command.Parameters.AddWithValue("@bottomSupply", (toThisComponent as Case).BottomSupply ? 1 : 0);
                }
                else if (toThisComponent is RAM)
                {
                    command.CommandText =
                        "UPDATE [RAM] SET [Id] = @Id, [ramGeneration] = @ramGeneration, [size] = @size, [frequency] = @frequency, [latency] = @latency, [pieces] = @pieces, [ecc] = @ecc, [rgb] = @rgb WHERE [Id] = @Id";
                    command.Parameters.AddWithValue("@Id", i);
                    command.Parameters.AddWithValue("@ramGeneration", (toThisComponent as RAM).RamGeneration);
                    command.Parameters.AddWithValue("@size", (toThisComponent as RAM).Size);
                    command.Parameters.AddWithValue("@frequency", (toThisComponent as RAM).Frequency);
                    command.Parameters.AddWithValue("@latency", (toThisComponent as RAM).Latency);
                    command.Parameters.AddWithValue("@pieces", (toThisComponent as RAM).Pieces);
                    command.Parameters.AddWithValue("@ecc", (toThisComponent as RAM).Ecc ? 1 : 0);
                    command.Parameters.AddWithValue("@rgb", (toThisComponent as RAM).Rgb ? 1 : 0);
                }
                else if (toThisComponent is Motherboard)
                {
                    command.CommandText =
                        "UPDATE [Motherboard] SET [Id] = @Id, [formFactor] = @formFactor, [socket] = @socket, [memoryGeneration] = @memoryGeneration, [crossfire] = @crossfire, [sli] = @sli, [bluetooth] = @bluetooth, [wifi] = @wifi, [m2x4Number] = @m2x4Number, [memorySlots] = @memorySlots, [maxMemorySize] = @maxMemorySize, [pciE_x16_Slots] = @pciE_x16_Slots, [pciE_x4_Slots] = @pciE_x4_Slots, [pciE_x1_Slots] = @pciE_x1_Slots, [sata3Connectors] = @sata3Connectors, [usb30] = @usb30, [usb31] = @usb30, [lan] = @lan WHERE [Id] = @Id";
                    command.Parameters.AddWithValue("@Id", i);
                    command.Parameters.AddWithValue("@formFactor", (toThisComponent as Motherboard).FormFactor);
                    command.Parameters.AddWithValue("@socket", (toThisComponent as Motherboard).Socket);
                    command.Parameters.AddWithValue("@memoryGeneration", (toThisComponent as Motherboard).MemoryGeneration);
                    command.Parameters.AddWithValue("@crossfire", (toThisComponent as Motherboard).Crossfire);
                    command.Parameters.AddWithValue("@sli", (toThisComponent as Motherboard).Sli);
                    command.Parameters.AddWithValue("@bluetooth", (toThisComponent as Motherboard).Bluetooth);
                    command.Parameters.AddWithValue("@wifi", (toThisComponent as Motherboard).Wifi);
                    command.Parameters.AddWithValue("@m2x4Number", (toThisComponent as Motherboard).M2x4Number);
                    command.Parameters.AddWithValue("@memorySlots", (toThisComponent as Motherboard).MemorySlots);
                    command.Parameters.AddWithValue("@maxMemorySize", (toThisComponent as Motherboard).MaxMemorySize);
                    command.Parameters.AddWithValue("@pciE_x16_Slots", (toThisComponent as Motherboard).PciE_x16_Slots);
                    command.Parameters.AddWithValue("@pciE_x4_Slots", (toThisComponent as Motherboard).PciE_x4_Slots);
                    command.Parameters.AddWithValue("@pciE_x1_Slots", (toThisComponent as Motherboard).PciE_x1_Slots);
                    command.Parameters.AddWithValue("@sata3Connectors", (toThisComponent as Motherboard).Sata3Connectors);
                    command.Parameters.AddWithValue("@usb30", (toThisComponent as Motherboard).Usb30);
                    command.Parameters.AddWithValue("@usb31", (toThisComponent as Motherboard).Usb31);
                    command.Parameters.AddWithValue("@lan", (toThisComponent as Motherboard).Lan);
                }
                else if (toThisComponent is Videocard)
                {
                    command.CommandText = "UPDATE [Videocard] SET [Id] = @Id, [gb] = @gb, [design] = @design, [tdp] = @tdp, [pcieConnector] = @pcieConnector, [videoCardLength] = @videoCardLength WHERE [Id] = @Id";
                    command.Parameters.AddWithValue("@Id", i);
                    command.Parameters.AddWithValue("@gb", (toThisComponent as Videocard).Gb);
                    command.Parameters.AddWithValue("@design", (toThisComponent as Videocard).Design);
                    command.Parameters.AddWithValue("@tdp", (toThisComponent as Videocard).Tdp);
                    command.Parameters.AddWithValue("@pcieConnector", (toThisComponent as Videocard).PcieConnector);
                    command.Parameters.AddWithValue("@videoCardLength", (toThisComponent as Videocard).VideoCardLength);
                }
                else if (toThisComponent is Storage)
                {
                    command.CommandText =
                        "UPDATE [Storages] SET [Id] = @Id, [gb] = @gb, [connectorType] = @connectorType, [condition] = @condition, [size] = @size WHERE [Id] = @Id";
                    command.Parameters.AddWithValue("@Id", i);
                    command.Parameters.AddWithValue("@gb", (toThisComponent as Storage).Gb);
                    command.Parameters.AddWithValue("@connectorType", (toThisComponent as Storage).ConnectorType);
                    command.Parameters.AddWithValue("@condition", (toThisComponent as Storage).Condition);
                    command.Parameters.AddWithValue("@size", (toThisComponent as Storage).size);

                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                    if (toThisComponent is HDD)
                    {
                        command.CommandText =
                            "UPDATE [HDD] SET [Id] = @Id, [rpm] = @rpm, [bufferSize] = @bufferSize WHERE [Id] = @Id";
                        command.Parameters.AddWithValue("@Id", i);
                        command.Parameters.AddWithValue("@rpm", (toThisComponent as HDD).Rpm);
                        command.Parameters.AddWithValue("@bufferSize", (toThisComponent as HDD).BufferSize);
                    }
                    else
                    {
                        command.CommandText = "UPDATE [SSD] SET [Id] = @Id, [writeSpeed] = @writeSpeed, [readSpeed] = @readSpeed, [technology] = @technology WHERE [Id] = @Id";
                        command.Parameters.AddWithValue("@Id", i);
                        command.Parameters.AddWithValue("@writeSpeed", (toThisComponent as SSD).WriteSpeed);
                        command.Parameters.AddWithValue("@readSpeed", (toThisComponent as SSD).ReadSpeed);
                        command.Parameters.AddWithValue("@technology", (toThisComponent as SSD).Technology);
                    }
                }
                else if (toThisComponent is PowerSupply)
                {
                    command.CommandText = "UPDATE [PowerSupply] SET [Id] = @Id, [output] = @output, [efficency] = @efficency, [sata] = @sata, [pcie] = @pcie, [molex] = @molex, [modular] = @modular, [formFactor] = @formFactor WHERE [Id] = @Id";
                    command.Parameters.AddWithValue("@Id", i);
                    command.Parameters.AddWithValue("@output", (toThisComponent as PowerSupply).Output);
                    command.Parameters.AddWithValue("@efficency", (toThisComponent as PowerSupply).Efficency);
                    command.Parameters.AddWithValue("@sata", (toThisComponent as PowerSupply).Sata);
                    command.Parameters.AddWithValue("@pcie", (toThisComponent as PowerSupply).Pcie);
                    command.Parameters.AddWithValue("@molex", (toThisComponent as PowerSupply).Molex);
                    command.Parameters.AddWithValue("@modular", (toThisComponent as PowerSupply).Modular ? 1 : 0);
                    command.Parameters.AddWithValue("@formFactor", (toThisComponent as PowerSupply).FormFactor);
                }
                else if (toThisComponent is Cooler)
                {
                    command.CommandText = "UPDATE [Cooler] SET [Id] = @Id, [lga1151] = @lga1151, [lga2066] = @lga2066, [lga2011] = @lga2011, [lga1366] = @lga1366, [lga775] = @lga775, [fm122Plus3Plus] = @fm122Plus3Plus, [am4] = @am4, [am22Plus33Plus] = @am22Plus33Plus, [tr4] = @tr4, [height] = @height WHERE [Id] = @Id";
                    command.Parameters.AddWithValue("@Id", i);
                    command.Parameters.AddWithValue("@lga1151", (toThisComponent as Cooler).Lga1151 ? 1 : 0);
                    command.Parameters.AddWithValue("@lga2066", (toThisComponent as Cooler).Lga2066 ? 1 : 0);
                    command.Parameters.AddWithValue("@lga2011", (toThisComponent as Cooler).Lga2011 ? 1 : 0);
                    command.Parameters.AddWithValue("@lga1366", (toThisComponent as Cooler).Lga1366 ? 1 : 0);
                    command.Parameters.AddWithValue("@lga775", (toThisComponent as Cooler).Lga775 ? 1 : 0);
                    command.Parameters.AddWithValue("@fm122Plus3Plus", (toThisComponent as Cooler).Fm122plus3plus ? 1 : 0);
                    command.Parameters.AddWithValue("@am4", (toThisComponent as Cooler).Am4 ? 1 : 0);
                    command.Parameters.AddWithValue("@am22Plus33Plus", (toThisComponent as Cooler).AM22plus33plus ? 1 : 0);
                    command.Parameters.AddWithValue("@tr4", (toThisComponent as Cooler).Tr4 ? 1 : 0);
                    command.Parameters.AddWithValue("@height", (toThisComponent as Cooler).Height);
                }

                command.ExecuteNonQuery();
                command.Parameters.Clear();
                transaction.Commit();
            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw new DBError("Modification failure!", e);
            }

            Disconnect();
        }

        internal static void Delete(Components component)
        {
            Connect(true);
            SqlTransaction transaction = null;

            try
            {
                transaction = connection.BeginTransaction("Delete");
                command.Transaction = transaction;
                command.Parameters.Clear();
                int id = SelectID(component);

                if (component is Case)
                {
                    //Delete case with saved ID
                    command.CommandText = "DELETE FROM [Case] WHERE [Id] = @Id";
                    command.Parameters.AddWithValue("@Id", id);

                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }
                else if (component is Motherboard)
                {
                    //Delete motherboard with saved ID
                    command.CommandText = "DELETE FROM [Motherboard] WHERE [Id] = @Id";
                    command.Parameters.AddWithValue("@Id", id);

                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }
                else if (component is Cooler)
                {
                    //Delete Cooler with saved ID
                    command.CommandText = "DELETE FROM [Cooler] WHERE [Id] = @Id";
                    command.Parameters.AddWithValue("@Id", id);

                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }
                else if (component is PowerSupply)
                {
                    //Delete PowerSupply with saved ID
                    command.CommandText = "DELETE FROM [PowerSupply] WHERE [Id] = @Id";
                    command.Parameters.AddWithValue("@Id", id);

                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }
                else if (component is Processor)
                {
                    if (component is AMDProcessor)
                    {
                        //Delete AMDProcessor with saved ID
                        command.CommandText = "DELETE FROM [AMDProcessor] WHERE [Id] = @Id";
                        command.Parameters.AddWithValue("@Id", id);

                        command.ExecuteNonQuery();
                        command.Parameters.Clear();
                    }
                    else
                    {
                        //Delete IntelProcessor with saved ID
                        command.CommandText = "DELETE FROM [IntelProcessor] WHERE [Id] = @Id";
                        command.Parameters.AddWithValue("@Id", id);

                        command.ExecuteNonQuery();
                        command.Parameters.Clear();
                    }

                    //Delete Processor with saved ID
                    command.CommandText = "DELETE FROM [Processor] WHERE [Id] = @Id";
                    command.Parameters.AddWithValue("@Id", id);

                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }
                else if (component is RAM)
                {
                    //Delete RAM with saved ID
                    command.CommandText = "DELETE FROM [RAM] WHERE [Id] = @Id";
                    command.Parameters.AddWithValue("@Id", id);

                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }
                else if (component is Storage)
                {
                    if (component is HDD)
                    {
                        //Delete HDD with saved ID
                        command.CommandText = "DELETE FROM [HDD] WHERE [Id] = @Id";
                        command.Parameters.AddWithValue("@Id", id);

                        command.ExecuteNonQuery();
                        command.Parameters.Clear();
                    }
                    else
                    {
                        //Delete SSD with saved ID
                        command.CommandText = "DELETE FROM [SSD] WHERE [Id] = @Id";
                        command.Parameters.AddWithValue("@Id", id);

                        command.ExecuteNonQuery();
                        command.Parameters.Clear();
                    }

                    //Delete Storage with saved ID
                    command.CommandText = "DELETE FROM [Storages] WHERE [Id] = @Id";
                    command.Parameters.AddWithValue("@Id", id);

                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }
                else if (component is Videocard)
                {
                    //Delete Videocard with saved ID
                    command.CommandText = "DELETE FROM [Videocard] WHERE [Id] = @Id";
                    command.Parameters.AddWithValue("@Id", id);

                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }

                //Deleting componentList with saved ID
                command.CommandText = "DELETE FROM [Component] WHERE [Id] = @Id";
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
                command.Parameters.Clear();

                transaction.Commit();

            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw new DBError("Delete failure!", e);
            }

            Disconnect();
        }

        static void Disconnect()
        {
            try
            {
                connection.Close();
            }
            catch (Exception e)
            {
                throw new DBError("Disconnection failed!", e);
            }
        }

        internal static List<string> TextRead()
        {
            Connect(true);
            List<string> texts;

            try
            {
                DataTable data = new DataTable();
                using (SqlDataAdapter da = new SqlDataAdapter("SELECT [text] FROM [Component]", connection))
                {
                    da.Fill(data);
                }

                texts = new List<string>();
                foreach (DataRow row in data.Rows)
                {
                    texts.Add(row.Field<string>("text"));
                }
            }
            catch (Exception e)
            {
                throw new DBError("Search suggestions read failure!", e);
            }

            Disconnect();
            return texts;
        }

        static int SelectID(Components component)
        {
            command.Parameters.Clear();

            if (component is Motherboard)
            {
                //Selecting ID 
                command.CommandText = "SELECT [Id] FROM [Motherboard] WHERE [formFactor] = @formFactor AND [socket] = @socket AND [memoryGeneration] = @memoryGeneration AND [crossfire] = @crossfire AND [sli] = @sli AND [bluetooth] = @bluetooth AND [wifi] = @wifi AND [m2x4Number] = @m2x4Number AND [memorySlots] = @memorySlots AND [maxMemorySize] = @maxMemorySize AND [pciE_x16_Slots] = @pciE_x16_Slots AND [pciE_x4_Slots] = @pciE_x4_Slots AND [pciE_x1_Slots] = @pciE_x1_Slots AND [sata3Connectors] = @sata3Connectors AND [usb30] = @usb30 AND [usb31] = @usb31 AND [lan] = @lan";
                command.Parameters.AddWithValue("@formFactor", (component as Motherboard).FormFactor);
                command.Parameters.AddWithValue("@socket", (component as Motherboard).Socket);
                command.Parameters.AddWithValue("@memoryGeneration", (component as Motherboard).MemoryGeneration);
                command.Parameters.AddWithValue("@crossfire", (component as Motherboard).Crossfire);
                command.Parameters.AddWithValue("@sli", (component as Motherboard).Sli);
                command.Parameters.AddWithValue("@bluetooth", (component as Motherboard).Bluetooth);
                command.Parameters.AddWithValue("@wifi", (component as Motherboard).Wifi);
                command.Parameters.AddWithValue("@m2x4Number", (component as Motherboard).M2x4Number);
                command.Parameters.AddWithValue("@memorySlots", (component as Motherboard).MemorySlots);
                command.Parameters.AddWithValue("@maxMemorySize", (component as Motherboard).MaxMemorySize);
                command.Parameters.AddWithValue("@pciE_x16_Slots", (component as Motherboard).PciE_x16_Slots);
                command.Parameters.AddWithValue("@pciE_x4_Slots", (component as Motherboard).PciE_x4_Slots);
                command.Parameters.AddWithValue("@pciE_x1_Slots", (component as Motherboard).PciE_x1_Slots);
                command.Parameters.AddWithValue("@sata3Connectors", (component as Motherboard).Sata3Connectors);
                command.Parameters.AddWithValue("@usb30", (component as Motherboard).Usb30);
                command.Parameters.AddWithValue("@usb31", (component as Motherboard).Usb31);
                command.Parameters.AddWithValue("@lan", (component as Motherboard).Lan);

                //Save ID
                int ID = 0;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ID = (int)reader["Id"];
                    }
                }

                if (ID == 0)
                {
                    ID = 1;
                }

                return ID;
            }
            else if (component is Case)
            {
                command.CommandText = "SELECT [Id] FROM [Case] WHERE [atx] = @atx AND [eatx] = @eatx AND [microATX] = @microATX AND [miniITX] = @miniITX AND [miniSTX] = @miniSTX AND [thinMiniITX] = @thinMiniITX AND [caseFormFactor] = @caseFormFactor AND [hddSpace] = @hddSpace AND [slimHdDspace] = @slimHdDspace AND [cpuHeatSinkHeight] = @cpuHeatSinkHeight AND [videoCardLength] = @videoCardLength AND [bottomSupply] = @bottomSupply";
                command.Parameters.AddWithValue("@atx", (component as Case).Atx ? 1 : 0);
                command.Parameters.AddWithValue("@eatx", (component as Case).Eatx ? 1 : 0);
                command.Parameters.AddWithValue("@microATX", (component as Case).MicroATX ? 1 : 0);
                command.Parameters.AddWithValue("@miniITX", (component as Case).MiniITX ? 1 : 0);
                command.Parameters.AddWithValue("@miniSTX", (component as Case).MiniSTX ? 1 : 0);
                command.Parameters.AddWithValue("@thinMiniITX", (component as Case).ThinMiniITX ? 1 : 0);
                command.Parameters.AddWithValue("@caseFormFactor", (component as Case).CaseFormFactor);
                command.Parameters.AddWithValue("@hddSpace", (component as Case).HddSpace);
                command.Parameters.AddWithValue("@slimHdDspace", (component as Case).SlimHDDspace);
                command.Parameters.AddWithValue("@cpuHeatSinkHeight", (component as Case).CpuHeatSinkHeight);
                command.Parameters.AddWithValue("@videoCardLength", (component as Case).VideoCardLength);
                command.Parameters.AddWithValue("@bottomSupply", (component as Case).BottomSupply ? 1 : 0);

                //Save ID
                int ID = 0;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ID = (int)reader["Id"];
                    }
                }

                return ID;
            }
            else if (component is Cooler)
            {
                command.CommandText = "SELECT [Id] FROM [Cooler] WHERE [lga1151] = @lga1151 AND [lga2066] = @lga2066 AND [lga2011] = @lga2011 AND [lga1366] = @lga1366 AND [lga775] = @lga775 AND [fm122Plus3Plus] = @fm122Plus3Plus AND [am4] = @am4 AND [am22Plus33Plus] = @am22Plus33Plus AND [tr4] = @tr4 AND [height] = @height";
                command.Parameters.AddWithValue("@lga1151", (component as Cooler).Lga1151 ? 1 : 0);
                command.Parameters.AddWithValue("@lga2066", (component as Cooler).Lga2066 ? 1 : 0);
                command.Parameters.AddWithValue("@lga2011", (component as Cooler).Lga2011 ? 1 : 0);
                command.Parameters.AddWithValue("@lga1366", (component as Cooler).Lga1366 ? 1 : 0);
                command.Parameters.AddWithValue("@lga775", (component as Cooler).Lga775 ? 1 : 0);
                command.Parameters.AddWithValue("@fm122Plus3Plus", (component as Cooler).Fm122plus3plus ? 1 : 0);
                command.Parameters.AddWithValue("@am4", (component as Cooler).Am4 ? 1 : 0);
                command.Parameters.AddWithValue("@am22Plus33Plus", (component as Cooler).AM22plus33plus ? 1 : 0);
                command.Parameters.AddWithValue("@tr4", (component as Cooler).Tr4 ? 1 : 0);
                command.Parameters.AddWithValue("@height", (component as Cooler).Height);

                //Save ID
                int ID = 0;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ID = (int)reader["Id"];
                    }
                }

                return ID;
            }
            else if (component is PowerSupply)
            {
                command.CommandText = "SELECT [Id] FROM [PowerSupply] WHERE [output] = @output AND [efficency] = @efficency AND [sata] = @sata AND [pcie] = @pcie AND [molex] = @molex AND [modular] = @modular AND [formFactor] = @formFactor";
                command.Parameters.AddWithValue("@output", (component as PowerSupply).Output);
                command.Parameters.AddWithValue("@efficency", (component as PowerSupply).Efficency);
                command.Parameters.AddWithValue("@sata", (component as PowerSupply).Sata);
                command.Parameters.AddWithValue("@pcie", (component as PowerSupply).Pcie);
                command.Parameters.AddWithValue("@molex", (component as PowerSupply).Molex);
                command.Parameters.AddWithValue("@modular", (component as PowerSupply).Modular ? 1 : 0);
                command.Parameters.AddWithValue("@formFactor", (component as PowerSupply).FormFactor);

                //Save ID
                int ID = 0;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ID = (int)reader["Id"];
                    }
                }

                return ID;
            }
            else if (component is Processor)
            {
                if (component is AMDProcessor)
                {
                    command.CommandText =
                        "SELECT [Id] FROM [AMDProcessor] WHERE [amdSocket] = @amdSocket AND [integratedGraphics] = @integratedGraphics";
                    command.Parameters.AddWithValue("@amdSocket", (component as AMDProcessor).AmdSocket);
                    command.Parameters.AddWithValue("@integratedGraphics", (component as AMDProcessor).IntegratedGraphics != "" ? (component as AMDProcessor).IntegratedGraphics : "");

                    //Save ID
                    int ID = 0;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ID = (int)reader["Id"];
                        }
                    }

                    return ID;
                }
                else
                {
                    command.CommandText =
                        "SELECT [Id] FROM [IntelProcessor] WHERE [intelSocket] = @intelSocket AND [integratedGraphics] = @integratedGraphics";
                    command.Parameters.AddWithValue("@intelSocket", (component as IntelProcessor).IntelSocket);
                    command.Parameters.AddWithValue("@integratedGraphics", (component as IntelProcessor).IntegratedGraphics != "" ? (component as IntelProcessor).IntegratedGraphics : "");

                    //Save ID
                    int ID = 0;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ID = (int)reader["Id"];
                        }
                    }

                    return ID;
                }
            }
            else if (component is RAM)
            {
                command.CommandText =
                    "SELECT [Id] FROM [RAM] WHERE [ramGeneration] = @ramGeneration AND [size] = @size AND [frequency] = @frequency AND [latency] = @latency AND [pieces] = @pieces AND [ecc] = @ecc AND [rgb] = @rgb";
                command.Parameters.AddWithValue("@ramGeneration", (component as RAM).RamGeneration);
                command.Parameters.AddWithValue("@size", (component as RAM).Size);
                command.Parameters.AddWithValue("@frequency", (component as RAM).Frequency);
                command.Parameters.AddWithValue("@latency", (component as RAM).Latency);
                command.Parameters.AddWithValue("@pieces", (component as RAM).Pieces);
                command.Parameters.AddWithValue("@ecc", (component as RAM).Ecc ? 1 : 0);
                command.Parameters.AddWithValue("@rgb", (component as RAM).Rgb ? 1 : 0);

                //Save ID
                int ID = 0;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ID = (int)reader["Id"];
                    }
                }

                return ID;
            }
            else if (component is Storage)
            {
                if (component is HDD)
                {
                    command.CommandText =
                        "SELECT [Id] FROM [HDD] WHERE [rpm] = @rpm AND [bufferSize] = @bufferSize";
                    command.Parameters.AddWithValue("@rpm", (component as HDD).Rpm);
                    command.Parameters.AddWithValue("@bufferSize", (component as HDD).BufferSize);

                    //Save ID
                    int ID = 0;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ID = (int)reader["Id"];
                        }
                    }

                    return ID;

                }
                else
                {
                    command.CommandText =
                        "SELECT [Id] FROM [SSD] WHERE [writeSpeed] = @writeSpeed AND [readSpeed] = @readSpeed AND [technology] = @technology";
                    command.Parameters.AddWithValue("@writeSpeed", (component as SSD).WriteSpeed);
                    command.Parameters.AddWithValue("@readSpeed", (component as SSD).ReadSpeed);
                    command.Parameters.AddWithValue("@technology", (component as SSD).Technology);

                    //Save ID
                    int ID = 0;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ID = (int)reader["Id"];
                        }
                    }

                    return ID;
                }
            }
            else
            {
                command.CommandText = "SELECT [Id] FROM [Videocard] WHERE [gb] = @gb AND [design] = @design AND [tdp] = @tdp AND [pcieConnector] = @pcieConnector AND [videoCardLength] = @videoCardLength";
                command.Parameters.AddWithValue("@gb", (component as Videocard).Gb);
                command.Parameters.AddWithValue("@design", (component as Videocard).Design);
                command.Parameters.AddWithValue("@tdp", (component as Videocard).Tdp);
                command.Parameters.AddWithValue("@pcieConnector", (component as Videocard).PcieConnector);
                command.Parameters.AddWithValue("@videoCardLength", (component as Videocard).VideoCardLength);

                //Save ID
                int ID = 0;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ID = (int)reader["Id"];
                    }
                }
                return ID;
            }
        }

        internal static void ProcessorModification(Processor fromThisProcessor, Processor toThisProcessor)
        {
            Connect(true);
            SqlTransaction transaction = null;

            try
            {
                int i = SelectID(fromThisProcessor);
                command.Parameters.Clear();
                transaction = connection.BeginTransaction("Modification");
                command.Transaction = transaction;

                command.CommandText = "UPDATE [Component] SET [manufacturer] = @manufacturer, [productsName] = @productsName, [serialNumber] = @serialNumber, [price] = @price, [dateOfPurchase] = @dateOfPurchase, [text] = @text, [warranty] = @warranty WHERE [Id] = @Id";
                command.Parameters.AddWithValue("@Id", i);
                command.Parameters.AddWithValue("@manufacturer", toThisProcessor.Manufacturer);
                command.Parameters.AddWithValue("@productsName", toThisProcessor.ProductsName);
                command.Parameters.AddWithValue("@serialNumber", toThisProcessor.SerialNumber != "" ? fromThisProcessor.SerialNumber : "");
                command.Parameters.AddWithValue("@price", toThisProcessor.Price);
                command.Parameters.AddWithValue("@dateOfPurchase", toThisProcessor.DateOfPurchase);
                command.Parameters.AddWithValue("@text", toThisProcessor.Text == "" ? "" : fromThisProcessor.Text);
                command.Parameters.AddWithValue("@warranty", toThisProcessor.Warranty);

                command.ExecuteNonQuery();
                command.Parameters.Clear();

                command.CommandText =
                    "UPDATE [Processor] SET [Id] = @Id, [l2Cache] = @l2Cache, [l3Cache] = @l3Cache, [cores] = @cores, [threads] = @threads, [process] = @process, [frequency] = @frequency, [turboFrequency] = @turboFrequency, [tdp] = @tdp WHERE [Id] = @Id";
                command.Parameters.AddWithValue("@Id", i);
                command.Parameters.AddWithValue("@l2Cache", (int)(toThisProcessor as Processor).L2Cache);
                command.Parameters.AddWithValue("@l3Cache", (int)(toThisProcessor as Processor).L3Cache);
                command.Parameters.AddWithValue("@cores", (int)(toThisProcessor as Processor).Cores);
                command.Parameters.AddWithValue("@threads", (int)(toThisProcessor as Processor).Threads);
                command.Parameters.AddWithValue("@process", (int)(toThisProcessor as Processor).Process);
                command.Parameters.AddWithValue("@frequency", (toThisProcessor as Processor).Frequency);
                command.Parameters.AddWithValue("@turboFrequency", (toThisProcessor as Processor).TurboFrequency);
                command.Parameters.AddWithValue("@tdp", (int)(toThisProcessor as Processor).Tdp);

                command.ExecuteNonQuery();
                command.Parameters.Clear();

                if (fromThisProcessor is AMDProcessor)
                {
                    if (toThisProcessor is IntelProcessor)
                    {
                        command.CommandText = "DELETE FROM [AMDProcessor] WHERE [Id] = @Id";
                        command.Parameters.AddWithValue("@Id", i);

                        command.ExecuteNonQuery();
                        command.Parameters.Clear();

                        {
                            command.CommandText =
                                "INSERT INTO [IntelProcessor] VALUES (@Id, @intelSocket, @integratedGraphics)";
                            command.Parameters.AddWithValue("@Id", i);
                            command.Parameters.AddWithValue("@intelSocket", (toThisProcessor as IntelProcessor).IntelSocket);
                            command.Parameters.AddWithValue("@integratedGraphics", (toThisProcessor as IntelProcessor).IntegratedGraphics != "" ? (toThisProcessor as IntelProcessor).IntegratedGraphics : "");

                            command.ExecuteNonQuery();
                            command.Parameters.Clear();
                        }
                    }
                }

                transaction.Commit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            Disconnect();
        }
    }
}

