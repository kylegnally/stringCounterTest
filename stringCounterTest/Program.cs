using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stringCounterTest
{
    class Program
    {
        static void Main(string[] args)
        {
#if DEBUG
            args = new[] { "testfile.txt" };
#endif

            if (args.Length > 1)
            {
                Console.WriteLine("File writing is unsupported.");
                Environment.Exit(0);
            }
            else HandleFile(ReadFile(args));

        }

        private static char[] ReadFile(string[] args)
        {
            char[] chars = null;
            if (args != null)
            {
                if (File.Exists(args[0]))
                {
                    try
                    {
                        string fullPath = Environment.CurrentDirectory + "\\" + args[0];
                        using (StreamReader reader = new StreamReader(fullPath))
                        {
                            char[] contents = reader.ReadToEnd().ToCharArray();
                            return contents;
                        }
                    }
                    catch
                    {
                        throw new FileLoadException();
                    }
                }
                throw new FileNotFoundException();
            }
            throw new NullReferenceException();
        }

        private static void HandleFile(char[] chars)
        {
            CharacterFrequency[] allCharsAsObj;
            int[] asciiVals = new int[256];
            allCharsAsObj = new CharacterFrequency[chars.Length];
            int i = 0;
            int j = 0;

            for (i = 0; i < asciiVals.Length; i++)
            {
                for (j = 0; j < allCharsAsObj.Length; j++)
                {
                    if ((int) chars[j] == i)
                    {
                        allCharsAsObj[j] = new CharacterFrequency();
                        allCharsAsObj[j].Character = chars[j];
                        allCharsAsObj[j].IncrementFrequency();
                    }
                }
            }
            
            foreach (CharacterFrequency character in allCharsAsObj)
            {
                Console.WriteLine("Character " + character.Character + " appears " + character.Frequency + " times in the array.\n");
            }

        }

    }
}
