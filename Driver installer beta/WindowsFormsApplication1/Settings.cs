using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Settings
{
    public class AppSettings
    {
        public string PrinterIP;
        public string PrinterName;
        public string DriverName;
        public AppSettings()
        {
            PrinterIP = string.Empty;
            PrinterName = string.Empty;
            DriverName = string.Empty;
        }
        public AppSettings(string ip, string name,string driver)
        {
            PrinterIP = ip;
            PrinterName = name;
            DriverName = driver;
        }
    }
    //public static class SettingsManagement
    //{       
    //    public static void SaveAppSettings(AppSettings settings, string filename)
    //    {
    //        FileStream fs = null;
    //        try
    //        {
    //            // To save the application setting values into xml.
    //            XmlSerializer xmlSerializer = new XmlSerializer(typeof(AppSettings));
    //            fs = new FileStream(filename, FileMode.Create);
    //            xmlSerializer.Serialize(fs, settings);               
    //        }
    //        catch { }
    //        finally
    //        {
    //            if (fs != null)
    //                fs.Close();
    //        }
    //    }

    //    public static AppSettings GetAppSettings(string filename)
    //    {
    //        // To retrieve the application setting values from xml.
    //        AppSettings settings = new AppSettings();
    //        FileStream fs = null;
    //        try
    //        {
    //            XmlSerializer xmlSerializer = new XmlSerializer(typeof(AppSettings));
    //            fs = new FileStream(filename, FileMode.Open);
    //            settings = (AppSettings)xmlSerializer.Deserialize(fs);          
    //        }
    //        catch { }
    //        finally
    //        {
    //            if (fs != null)
    //                fs.Close();
    //        }
    //        return settings;
    //    }    
    //}
}
