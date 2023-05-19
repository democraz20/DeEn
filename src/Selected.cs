namespace DeEn {
    class Selected {
        public static void Decrypt() {
            Console.Write("Enter file to decrypt> ");
            string? filename = Console.ReadLine();
            if (filename == null || filename == "")  {
                throw new FileNotFoundException("file name cannot be empty!");
            }
        }
        public static void Encrypt() {
            Console.Write("Enter file to encrypt> ");
            string? filename = Console.ReadLine();
            if (filename == null || filename == "")  {
                throw new FileNotFoundException("file name cannot be empty!");
            }
        }
    }
}