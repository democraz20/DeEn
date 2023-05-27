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

            // string path = @"bin\Debug\net7.0\DeEn.dll";
            

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
            ";
                            Console.WriteLine(logo);
                        //program loom
                        while(true) {
                            Console.Write("Decrypt or Encrypt a file? (1/2) >");
                            var choice = Console.ReadKey();
                            Console.WriteLine();
                            switch (choice.KeyChar.ToString()) {
                                case "1":
                                    try {
                                        // Selected.Decrypt();
                                        Console.Write("Enter data to decrypt > ");
                                        string d = Console.ReadLine();
                                        Console.WriteLine(de(d));
                                    } catch (Exception e) {
                                        var f = String.Format("An Exception occured while decrypting :\n {0}", e.Message);
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine(f);
                                        Console.ResetColor();
                                    }
                                    break;
                                case "2":
                                    try {
                                        // Selected.Encrypt();
                                        Console.WriteLine(en(".gitignore"));
                                    } catch (Exception e) {
                                        var f = String.Format("An Exception occured while decrypting :\n {0}", e.Message);
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine(f);
                                        Console.ResetColor();
                                    }
                                    break;
                                default:
                                    Console.WriteLine("\nExiting...");
                                    return;
                            }
                        }
        }

        static string en(string filename) {
            byte[] bytes = File.ReadAllBytes(filename);

            var Bits = new BitArray(bytes);

            List<bool> bitlist = new List<bool>();
            foreach (bool bit in Bits)
            {
                bitlist.Add(bit);
            }

            List<List<bool>> chunks = bitlist.Chunk(6).ToList();

            var base64table = new Dictionary<int, char>(){
                { 0, 'A' }, { 1, 'B' }, { 2, 'C' }, { 3, 'D' },
            { 4, 'E' }, { 5, 'F' }, { 6, 'G' }, { 7, 'H' },
            { 8, 'I' }, { 9, 'J' }, { 10, 'K' }, { 11, 'L' },
            { 12, 'M' }, { 13, 'N' }, { 14, 'O' }, { 15, 'P' },
            { 16, 'Q' }, { 17, 'R' }, { 18, 'S' }, { 19, 'T' },
            { 20, 'U' }, { 21, 'V' }, { 22, 'W' }, { 23, 'X' },
            { 24, 'Y' }, { 25, 'Z' }, { 26, 'a' }, { 27, 'b' },
            { 28, 'c' }, { 29, 'd' }, { 30, 'e' }, { 31, 'f' },
            { 32, 'g' }, { 33, 'h' }, { 34, 'i' }, { 35, 'j' },
            { 36, 'k' }, { 37, 'l' }, { 38, 'm' }, { 39, 'n' },
            { 40, 'o' }, { 41, 'p' }, { 42, 'q' }, { 43, 'r' },
            { 44, 's' }, { 45, 't' }, { 46, 'u' }, { 47, 'v' },
            { 48, 'w' }, { 49, 'x' }, { 50, 'y' }, { 51, 'z' },
            { 52, '0' }, { 53, '1' }, { 54, '2' }, { 55, '3' },
            { 56, '4' }, { 57, '5' }, { 58, '6' }, { 59, '7' },
            { 60, '8' }, { 61, '9' }, { 62, '+' }, { 63, '/' }
            };

            string s = "";
            foreach (List<bool> boolList in chunks)
            {
                int result = 0;
                for (int i = 0; i < boolList.Count; i++)
                {
                    bool bit = boolList[i];
                    if (bit)
                    {
                        result |= 1 << i;
                    }
                }
                s = s + base64table[result];
                // Console.Write(base64table[result]);
            }
            return s;
        }
        static BitArray de(string en) {
            return new BitArray()
        }
    }
}