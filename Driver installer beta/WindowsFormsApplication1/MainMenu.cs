using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.IO;
using Settings;
using System.Net;

namespace KonicaMinoltaDriverInstaller
{
    public partial class MainMenu : Form
    {
        bool ok = false;
        AppSettings appsettings = new AppSettings();
        ManagementScope managementScope = new ManagementScope();
        public MainMenu()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
            //if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + "settings.xml"))
            //{
            //    AppSettings settings = new AppSettings();
            //    settings.PrinterIP = "insert ip here";
            //    settings.PrinterName = "insert name here";
            //    SettingsManagement.SaveAppSettings(settings, AppDomain.CurrentDomain.BaseDirectory + "settings.xml");
            //}
            //else appsettings = SettingsManagement.GetAppSettings("settings.xml");
        }
        private bool IsPrinterInstalled(string PrinterName)
        {
            managementScope = new ManagementScope(ManagementPath.DefaultPath);
            managementScope.Connect();
            SelectQuery selectQuery = new SelectQuery();
            selectQuery.QueryString = "Select * from win32_Printer where Name = '" + appsettings.PrinterName + "'";
            ManagementObjectSearcher MOS = new ManagementObjectSearcher(managementScope, selectQuery);
            ManagementObjectCollection MOC = MOS.Get();
            return MOC.Count > 0;
        }
        private void CreateManagementScope(string computerName)
        {
            var wmiConnectionOptions = new ConnectionOptions();
            wmiConnectionOptions.Impersonation = ImpersonationLevel.Impersonate;
            wmiConnectionOptions.Authentication = AuthenticationLevel.Default;
            wmiConnectionOptions.EnablePrivileges = true; 

            string path = "\\\\" + computerName + "\\root\\cimv2";
            managementScope = new ManagementScope(path, wmiConnectionOptions);
            
            managementScope.Connect();
        }
        private bool CheckPrinterPort()
        {
            try
            {
                //Query system for Operating System information
                ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_TCPIPPrinterPort");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(managementScope, query);

                ManagementObjectCollection queryCollection = searcher.Get();
                foreach (ManagementObject m in queryCollection)
                {
                    string mname = m["Name"].ToString();
                    if (mname == textBoxhostaddress.Text)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("CheckPrinterPort FAILED");
                return false;
            }
        }
        private bool CreatePrinterPort()
        {
            try
            {

                if (CheckPrinterPort())
                {
                    MessageBox.Show("Port already exists!");
                    return true;
                }
                var printerPortClass = new ManagementClass(managementScope, new ManagementPath("Win32_TCPIPPrinterPort"), new ObjectGetOptions());
                printerPortClass.Get();
                var newPrinterPort = printerPortClass.CreateInstance();
                newPrinterPort.SetPropertyValue("Name", textBoxhostaddress.Text);
                if(radioraw.Checked) newPrinterPort.SetPropertyValue("Protocol", 1);
                else if (radiolpr.Checked) newPrinterPort.SetPropertyValue("Protocol", 2);
                newPrinterPort.SetPropertyValue("HostAddress", textBoxhostaddress.Text);
                newPrinterPort.SetPropertyValue("PortNumber", textBoxportno.Text);    // default=9100
                newPrinterPort.SetPropertyValue("SNMPEnabled", false);  // true?
                newPrinterPort.SetPropertyValue("Queue", textBoxqname.Text);
                
                newPrinterPort.Put();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Create Printer Port FAILED");
                return false;
            }
        }
        private bool CreatePrinterDriver(string printerDriverFolderPath)
        {
            try
            {
                var endResult = false;
                string printerDriverInfPath = string.Empty;
                var dirs = Directory.GetFiles(printerDriverFolderPath, "*.INF");
                foreach (var item in dirs)
                {
                    printerDriverInfPath = item;
                    break;
                }
                var printerDriverClass = new ManagementClass(managementScope, new ManagementPath("Win32_PrinterDriver"), new ObjectGetOptions());
                var printerDriver = printerDriverClass.CreateInstance();
                printerDriver.SetPropertyValue("Name", textBox1.Text);
                printerDriver.SetPropertyValue("FilePath", printerDriverFolderPath);
                printerDriver.SetPropertyValue("InfName", printerDriverInfPath);

                using (ManagementBaseObject inParams = printerDriverClass.GetMethodParameters("AddPrinterDriver"))
                {
                    inParams["DriverInfo"] = printerDriver;
                    using (ManagementBaseObject result = printerDriverClass.InvokeMethod("AddPrinterDriver", inParams, null))
                    {
                        uint errorCode = (uint)result.Properties["ReturnValue"].Value;
                        switch (errorCode)
                        {
                            case 0:
                                endResult = true;
                                break;
                            case 5:
                                MessageBox.Show("Access Denied.");
                                break;
                            case 87:
                                MessageBox.Show("Names of printer and the name in the driver dont match.");
                                break;
                            case 123:
                                MessageBox.Show("The filename, directory name, or volume label syntax is incorrect.");
                                break;
                            case 1801:
                                MessageBox.Show("Invalid Printer Name.");
                                break;
                            case 1930:
                                MessageBox.Show("Incompatible Printer Driver.");
                                break;
                            case 3019:
                                MessageBox.Show("The specified printer driver was not found on the system and needs to be downloaded.");
                                break;
                        }
                    }
                }
                return endResult;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to create the printer driver");
                return true;
            }
        }
        private bool CreatePrinter()
        {
            try
            {
                var printerClass = new ManagementClass(managementScope, new ManagementPath("Win32_Printer"), new ObjectGetOptions());
                printerClass.Get();
                var printer = printerClass.CreateInstance();
                printer.SetPropertyValue("DriverName", appsettings.DriverName);
                printer.SetPropertyValue("PortName", appsettings.PrinterIP);
                //printer.SetPropertyValue("DisplayName", appsettings.PrinterName);
                printer.SetPropertyValue("Name", appsettings.PrinterName);
                printer.SetPropertyValue("DeviceID", appsettings.PrinterName);
                printer.SetPropertyValue("Location", "Office");
                printer.SetPropertyValue("Network", true);
                printer.SetPropertyValue("Shared", false);
                printer.Put();
                printer.InvokeMethod("SetDefaultPrinter", null);
                printer.InvokeMethod("PrintTestPage", null);
               
                ok = true;
                return true;
            }
            catch (ManagementException ex)
            {
                return false;
            }
        }
        private void InstallPrinterWMI(string printerDriverPath)
        {
            bool printePortCreated = false, printeDriverCreated = false, printeCreated = false;
            try
            {
                //printeDriverCreated = CreatePrinterDriver(printerDriverPath);
                printeCreated = CreatePrinter();
            }
            catch (ManagementException err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                if(printeCreated==true)
                    MessageBox.Show("Installation complete." + Environment.NewLine + "Your driver is ready for use.");
                else MessageBox.Show("Sorry, something went wrong.");
            }
        }
        private void buttonInstallClick(object sender, EventArgs e)
        {
            appsettings.DriverName = textBox1.Text;
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a printer");
                return;
            }
            if (textBoxIP.Text == string.Empty)
            {
                MessageBox.Show("Please enter the IP address");
                return;
            }
            if (textBoxprintername.Text == string.Empty)
            {
                MessageBox.Show("Printer name cannot be empty");
                return;
            }
            appsettings.PrinterIP = textBoxIP.Text;
            appsettings.PrinterName = textBoxprintername.Text;

            Cursor.Current = Cursors.WaitCursor;
            CreateManagementScope("127.0.0.1");
            if (comboBox1.SelectedIndex == 0)
            {
                appsettings.PrinterName = textBoxprintername.Text;
                if (IsPrinterInstalled(appsettings.PrinterName))
                {
                    MessageBox.Show("Printer with this name already exists");
                    return;
                }
                if (!Environment.Is64BitOperatingSystem)
                    InstallPrinterWMI(Paths.DriversPath + "c308-32bit");
                else
                    InstallPrinterWMI(Paths.DriversPath + "c308-64bit");
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                appsettings.PrinterName = textBoxprintername.Text;
                if (IsPrinterInstalled(appsettings.PrinterName))
                {
                    MessageBox.Show("Printer with this name already exists");
                    return;
                }
                if (!Environment.Is64BitOperatingSystem)
                    InstallPrinterWMI(Paths.DriversPath + "c308-32bit");
                else 
                    InstallPrinterWMI(Paths.DriversPath + "c308-64bit");
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                appsettings.PrinterName = textBoxprintername.Text;
                if (IsPrinterInstalled(appsettings.PrinterName))
                {
                    MessageBox.Show("Printer with this name already exists");
                    return;
                }
                if (!Environment.Is64BitOperatingSystem)
                    InstallPrinterWMI(Paths.DriversPath + "c308-32bit");
                else 
                    InstallPrinterWMI(Paths.DriversPath + "c308-64bit");
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                appsettings.PrinterName = textBoxprintername.Text;
                if (IsPrinterInstalled(appsettings.PrinterName))
                {
                    MessageBox.Show("Printer with this name already exists");
                    return;
                }
                if (!Environment.Is64BitOperatingSystem)
                    InstallPrinterWMI(Paths.DriversPath + "308-32bit");
                else
                    InstallPrinterWMI(Paths.DriversPath + "308-64bit");
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                appsettings.PrinterName = textBoxprintername.Text;
                if (IsPrinterInstalled(appsettings.PrinterName))
                {
                    MessageBox.Show("Printer with this name already exists");
                    return;
                }
                if (!Environment.Is64BitOperatingSystem)
                    InstallPrinterWMI(Paths.DriversPath + "308-32bit");
                else
                    InstallPrinterWMI(Paths.DriversPath + "308-64bit");
            }
            else if (comboBox1.SelectedIndex == 5)
            {
                appsettings.PrinterName = textBoxprintername.Text;
                if (IsPrinterInstalled(appsettings.PrinterName))
                {
                    MessageBox.Show("Printer with this name already exists");
                    return;
                }
                if (!Environment.Is64BitOperatingSystem)
                    InstallPrinterWMI(Paths.DriversPath + "4020-32bit");
                else 
                    InstallPrinterWMI(Paths.DriversPath + "4020-64bit");
            }
            else if (comboBox1.SelectedIndex == 6)
            {
                appsettings.PrinterName = textBoxprintername.Text;
                if (IsPrinterInstalled(appsettings.PrinterName))
                {
                    MessageBox.Show("Printer with this name already exists");
                    return;
                }
                if (!Environment.Is64BitOperatingSystem)
                    InstallPrinterWMI(Paths.DriversPath + "4020-32bit");
                else 
                    InstallPrinterWMI(Paths.DriversPath + "4020-64bit");
            }
            else if (comboBox1.SelectedIndex == 7)
            {
                appsettings.PrinterName = textBoxprintername.Text;
                if (IsPrinterInstalled(appsettings.PrinterName))
                {
                    MessageBox.Show("Printer with this name already exists");
                    return;
                }
                if (!Environment.Is64BitOperatingSystem)
                    InstallPrinterWMI(Paths.DriversPath + "4050-32bit");
                else
                    InstallPrinterWMI(Paths.DriversPath + "4050-64bit");
            }
            else if (comboBox1.SelectedIndex == 8)
            {
                appsettings.PrinterName = textBoxprintername.Text;
                if (IsPrinterInstalled(appsettings.PrinterName))
                {
                    MessageBox.Show("Printer with this name already exists");
                    return;
                }
                if (!Environment.Is64BitOperatingSystem)
                    InstallPrinterWMI(Paths.DriversPath + "4050-32bit");
                else 
                    InstallPrinterWMI(Paths.DriversPath + "4050-64bit");
            }
            else if (comboBox1.SelectedIndex == 9)
            {
                appsettings.PrinterName = textBoxprintername.Text;
                if (IsPrinterInstalled(appsettings.PrinterName))
                {
                    MessageBox.Show("Printer with this name already exists");
                    return;
                }
                if (!Environment.Is64BitOperatingSystem)
                    InstallPrinterWMI(Paths.DriversPath + "c224-32bit");
                else 
                    InstallPrinterWMI(Paths.DriversPath + "c224-64bit");
            }


            if (ok)
            {
                Cursor.Current = Cursors.Default;               
            }
            else MessageBox.Show("Sorry, something went wrong");
        }
        private void Exit(object sender, EventArgs e)
        {
            Close();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                textBoxprintername.Text = "KONICA MINOLTA C287SeriesPCL";
                textBox1.Text = "KONICA MINOLTA C287SeriesPCL";
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                textBoxprintername.Text = "KONICA MINOLTA C368SeriesPCL"; 
                textBox1.Text = textBoxprintername.Text;
               
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                textBoxprintername.Text = "KONICA MINOLTA C368SeriesPCL"; 
                textBox1.Text = textBoxprintername.Text;
               
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                textBoxprintername.Text = "KONICA MINOLTA 367SeriesPCL";
                textBox1.Text = textBoxprintername.Text;
              
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                textBoxprintername.Text = "KONICA MINOLTA 368SeriesPCL"; textBox1.Text = textBoxprintername.Text;
                
            }
            else if (comboBox1.SelectedIndex == 5)
            {
                textBoxprintername.Text = "KONICA MINOLTA 4020_3320 PCL6"; textBox1.Text = textBoxprintername.Text;
               
            }
            else if (comboBox1.SelectedIndex == 6)
            {
                textBoxprintername.Text = "KONICA MINOLTA 4020_3320 PCL6"; textBox1.Text = textBoxprintername.Text;
               
            }
            else if (comboBox1.SelectedIndex == 7)
            {
                textBoxprintername.Text = "KONICA MINOLTA 4750 Series PCL6"; textBox1.Text = textBoxprintername.Text;
            
            }
            else if (comboBox1.SelectedIndex == 8)
            {
                textBoxprintername.Text = "KONICA MINOLTA 4750 Series PCL6"; textBox1.Text = textBoxprintername.Text;
              
            }
            else if (comboBox1.SelectedIndex == 9)
            {
                textBoxprintername.Text = "KONICA MINOLTA C554SeriesPCL"; textBox1.Text = textBoxprintername.Text;

            }
        }
        private void buttoninstallport_Click(object sender, EventArgs e)
        {
            if (CreatePrinterPort())
                MessageBox.Show("Printer port successfuly created");

        }
        private void radioraw_CheckedChanged(object sender, EventArgs e)
        {
            textBoxqname.Text = string.Empty;
            textBoxportno.Enabled = true;
        }
        private void radiolpr_CheckedChanged(object sender, EventArgs e)
        {
            textBoxqname.Text = "secure";
            textBoxportno.Enabled = false;
        }
    }
}
