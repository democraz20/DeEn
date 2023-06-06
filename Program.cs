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
        private const char PADDINGCHAR = '=';
        static void Main(string[] args)
        {
            string res = en(".gitignore");
            de(res);

            // string path = @"bin\Debug\net7.0\DeEn.dll";
            


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
            //                             // Selected.Decrypt();
            //                             Console.Write("Enter data to decrypt > ");
            //                             string d = Console.ReadLine();
            //                             var returned = de(d);
            //                         } catch (Exception e) {
            //                             var f = String.Format("An Exception occured while decrypting :\n {0}", e.Message);
            //                             Console.ForegroundColor = ConsoleColor.Red;
            //                             Console.WriteLine(f);
            //                             Console.ResetColor();
            //                         }
            //                         break;
            //                     case "2":
            //                         try {
            //                             // Selected.Encrypt();
            //                             Console.WriteLine(en(".gitignore"));
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

        static string en(string filename) {
            byte[] bytes = File.ReadAllBytes(filename);
            var Bits = new BitArray(bytes);
            
            List<bool> bitlist = new List<bool>();
            foreach (bool bit in Bits)
            {
                bitlist.Add(bit);
            }

            string padding = "";
            //padding
            int remainder = bitlist.Count % 6;
            if (remainder != 0) {
                int zerosToAdd = remainder == 0 ? 0 : 6 - remainder;
                for (int i = 0; i < zerosToAdd; i++)
                {   
                    padding += PADDINGCHAR;
                    bitlist.Add(false);
                }
            }
            // Console.WriteLine(bitlist.Count);
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
            //List<bool> has 6 bits
            foreach (List<bool> boolList in chunks)
            {
                int number = 0;
                for (int i = 0; i < boolList.Count; i++)
                {
                    number <<= 1;
                    if (boolList[i])
                    {
                        number |= 1;
                    }
                }
                s = s + base64table[number];
            }
            s += padding;
            // Console.WriteLine(s);
            Console.WriteLine(s);
            Console.WriteLine("Raw bits from file:");
            bitarrcolor(Bits);
            Console.WriteLine("\nPadded Bits:");
            bitarrcolor(new BitArray(bitlist.ToArray()));
            return s;
        }
        static int de(string en) {
            Dictionary<char, int> base64Dictionary = new Dictionary<char, int>
            {
                { 'A', 0 }, { 'B', 1 }, { 'C', 2 }, { 'D', 3 },
                { 'E', 4 }, { 'F', 5 }, { 'G', 6 }, { 'H', 7 },
                { 'I', 8 }, { 'J', 9 }, { 'K', 10 }, { 'L', 11 },
                { 'M', 12 }, { 'N', 13 }, { 'O', 14 }, { 'P', 15 },
                { 'Q', 16 }, { 'R', 17 }, { 'S', 18 }, { 'T', 19 },
                { 'U', 20 }, { 'V', 21 }, { 'W', 22 }, { 'X', 23 },
                { 'Y', 24 }, { 'Z', 25 }, { 'a', 26 }, { 'b', 27 },
                { 'c', 28 }, { 'd', 29 }, { 'e', 30 }, { 'f', 31 },
                { 'g', 32 }, { 'h', 33 }, { 'i', 34 }, { 'j', 35 },
                { 'k', 36 }, { 'l', 37 }, { 'm', 38 }, { 'n', 39 },
                { 'o', 40 }, { 'p', 41 }, { 'q', 42 }, { 'r', 43 },
                { 's', 44 }, { 't', 45 }, { 'u', 46 }, { 'v', 47 },
                { 'w', 48 }, { 'x', 49 }, { 'y', 50 }, { 'z', 51 },
                { '0', 52 }, { '1', 53 }, { '2', 54 }, { '3', 55 },
                { '4', 56 }, { '5', 57 }, { '6', 58 }, { '7', 59 },
                { '8', 60 }, { '9', 61 }, { '+', 62 }, { '/', 63 }
            };

            //get the list of ints from chars
            List<int> intlist = new List<int>{};
            int paddingcount = 0;
            foreach (char c in en) {
                if (c == PADDINGCHAR) {
                    paddingcount += 1;
                } else {
                    intlist.Add(base64Dictionary[c]);
                }
            }

            List<List<bool>> bitslist = new List<List<bool>>();
            foreach (int num in intlist) {
                List<bool> bitList = new List<bool>(6);

                for (int i = 5; i >= 0; i--)
                {
                    bool bit = ((num >> i) & 1) == 1;
                    bitList.Add(bit);
                }
                bitslist.Add(bitList);
            }
            //removing padding
            List<bool> lastList = bitslist[bitslist.Count - 1];
            int itemsToRemove = Math.Min(paddingcount, lastList.Count);
            lastList.RemoveRange(lastList.Count - itemsToRemove, itemsToRemove);

            //writing out
            Console.WriteLine("\nConverted bits: ");
            foreach (List<bool> l in bitslist) {
                BitArray b = new BitArray(l.ToArray());
                bitarrcolor(b);
            }
            // foreach (List<bool> boolist in bitslist) {
            //     foreach (bool bit in boolist)
            //     {
            //         Console.Write(bit ? "1" : "0");
            //     }
            //     Console.WriteLine();
            // }
            return 0;
        }
        static void bitarrcolor(BitArray bitarray) {
            foreach (bool bit in bitarray) {
                if (bit) {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Write("1");
                } else {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write("0");
                }
            }
            Console.ResetColor();
        }
    }
}