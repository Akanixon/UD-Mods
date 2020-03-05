using System;


namespace publishMods
{
    class Program
    {
        public void publish()
        {
            var p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "D:\\Software\\steamcmd\\steamcmd.exe";
            Console.Write("Username: ");
            string userName = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();
            Console.Write("SteamGuard: ");
            string steamGuard = Console.ReadLine();
            string[] vdfPath = { "C:\\Users\\AkaNi\\source\\repos\\UD-Mods\\publishMods\\UDFoundation.vdf", "C:\\Users\\AkaNi\\source\\repos\\UD-Mods\\publishMods\\MKBlocks.vdf" };
            p.StartInfo.Arguments = "+login " + userName + " " + password + " " + steamGuard + " +workshop_build_item " + vdfPath[1] + " +quit";
            p.Start();
        }

        public static void Main(string[] args)
        {
            Program p = new Program();
            p.publish();
        }
    }
}
