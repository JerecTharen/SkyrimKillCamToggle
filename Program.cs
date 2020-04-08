using System;
using System.IO;

namespace ToggleSkyrimKillCam
{
    class Program
    {
        private static string _root = @"C:\Users\kf7ag\Documents\My Games\Skyrim";
        private static string _yesCamLocation = @"D:\Projects\ToggleSkyrimKillCam\yesCam\Skyrim.ini";
        private static string _noCamLocation = @"D:\Projects\ToggleSkyrimKillCam\noCam\Skyrim.ini";

        static void Main(string[] args)
        {
            Console.WriteLine("Switching skyrim .ini file");

            Console.WriteLine("File being used");

            string fileUsedContents = File.ReadAllText(_root + @"\Skyrim.ini");
            bool isKillCamOff = fileUsedContents.Contains("bVATSdisable=1");

            Console.WriteLine(fileUsedContents);
            Console.WriteLine($"isKillCamOff: {isKillCamOff}");

            bool isKillCamOn;

            if(args.Length > 0)
                if(args[0].ToLower() == "on" || args[0].ToLower() == "off")
                    isKillCamOn = ToggleKillCam(isKillCamOff, args[0].ToLower());
                else
                    isKillCamOn = ToggleKillCam(isKillCamOff);
            else
                isKillCamOn = ToggleKillCam(isKillCamOff);
            
            System.Console.WriteLine(isKillCamOn ? "Kill Cam is now on." : "Kill Cam is now off.");
            System.Console.WriteLine("Shutting down . . .");
            Console.ReadLine();
        }

        private static bool ToggleKillCam(bool isKillCamOff, string onOff = "")
        {
            //returns is kill cam is on
            bool ret = false;
            System.Console.WriteLine("Deleting File");
            string location = _root + @"\Skyrim.ini";
            File.Delete(location);
            System.Console.WriteLine("Copying file");
            if(String.IsNullOrEmpty(onOff))
            {
                File.Copy(isKillCamOff ? _yesCamLocation : _noCamLocation, location);
                ret = !isKillCamOff;
            }
            else if(onOff == "on")
            {
                File.Copy(_yesCamLocation, location);
                ret = true;
            }
            else if(onOff == "off")
            {
                File.Copy(_noCamLocation, location);
                ret = false;
            }
            return ret;
        }
    }
}
