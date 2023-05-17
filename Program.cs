using System;

namespace DeEn // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
                string logo = @"
▓█████▄ ▓█████ ▓█████  ███▄    █ 
▒██▀ ██▌▓█   ▀ ▓█   ▀  ██ ▀█   █ 
░██   █▌▒███   ▒███   ▓██  ▀█ ██▒
░▓█▄   ▌▒▓█  ▄ ▒▓█  ▄ ▓██▒  ▐▌██▒
░▒████▓ ░▒████▒░▒████▒▒██░   ▓██░
 ▒▒▓  ▒ ░░ ▒░ ░░░ ▒░ ░░ ▒░   ▒ ▒ 
 ░ ▒  ▒  ░ ░  ░ ░ ░  ░░ ░░   ░ ▒░
 ░ ░  ░    ░      ░      ░   ░ ░ 
   ░       ░  ░   ░  ░         ░ 
 ░                               
";
                Console.WriteLine(logo);
            //program loom
            while(true) {
                Console.Write("Decrypt or Encrypt a file? (1/2) >");
                var choice = Console.ReadKey();
                switch (choice.KeyChar.ToString()) {
                    case "1":
                        break;
                    case "2":
                        break;
                    default:
                        Console.WriteLine("Exiting...");
                        return;
                }
            }
        }
    }
}