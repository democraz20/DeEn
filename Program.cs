using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace DeEn // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"bin\Debug\net7.0\DeEn.dll";
            byte[] bytes = File.ReadAllBytes(path);

            var Bits = new BitArray(bytes);

            List<bool> bitlist = new List<bool>();
            foreach (bool bit in Bits) {
                bitlist.Add(bit);
            }

            Console.WriteLine(Bits);
//                 string logo = @"
// ▓█████▄ ▓█████ ▓█████  ███▄    █ 
// ▒██▀ ██▌▓█   ▀ ▓█   ▀  ██ ▀█   █ 
// ░██   █▌▒███   ▒███   ▓██  ▀█ ██▒
// ░▓█▄   ▌▒▓█  ▄ ▒▓█  ▄ ▓██▒  ▐▌██▒
// ░▒████▓ ░▒████▒░▒████▒▒██░   ▓██░
//  ▒▒▓  ▒ ░░ ▒░ ░░░ ▒░ ░░ ▒░   ▒ ▒ 
//  ░ ▒  ▒  ░ ░  ░ ░ ░  ░░ ░░   ░ ▒░
//  ░ ░  ░    ░      ░      ░   ░ ░ 
//    ░       ░  ░   ░  ░         ░ 
// ";
//                 Console.WriteLine(logo);
//             //program loom
//             while(true) {
//                 Console.Write("Decrypt or Encrypt a file? (1/2) >");
//                 var choice = Console.ReadKey();
//                 Console.WriteLine();
//                 switch (choice.KeyChar.ToString()) {
//                     case "1":
//                         try {
//                             Selected.Decrypt();
//                         } catch (Exception e) {
//                             var f = String.Format("An Exception occured while decrypting :\n {0}", e.Message);
//                             Console.ForegroundColor = ConsoleColor.Red;
//                             Console.WriteLine(f);
//                             Console.ResetColor();
//                         }
//                         break;
//                     case "2":
//                         try {
//                             Selected.Encrypt();
//                         } catch (Exception e) {
//                             var f = String.Format("An Exception occured while decrypting :\n {0}", e.Message);
//                             Console.ForegroundColor = ConsoleColor.Red;
//                             Console.WriteLine(f);
//                             Console.ResetColor();
//                         }
//                         break;
//                     default:
//                         Console.WriteLine("\nExiting...");
//                         return;
//                 }
//             }
        }
    }
}