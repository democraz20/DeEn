using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public static class ListExtensions
{
    public static IEnumerable<List<T>> Chunk<T>(this List<T> list, int chunkSize)
    {
        for (int i = 0; i < list.Count; i += chunkSize)
        {
            yield return list.GetRange(i, Math.Min(chunkSize, list.Count - i));
        }
    }
}



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
            
            List<List<bool>> chunks = bitlist.Chunk(6).ToList();

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