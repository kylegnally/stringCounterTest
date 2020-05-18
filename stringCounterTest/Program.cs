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
        //private CharacterFrequency[] characterFreqAsArrayOfObjects;
        static void Main(string[] args)
        {
#if DEBUG
            //args = new[] { "wap.txt", "out.txt" };
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
            foreach (char aCharacter in chars)
            {
                int k = (int) chars[i];
                if (k == asciiVals[j])
                {
                    allCharsAsObj[i] = new CharacterFrequency(chars[i]);
                    allCharsAsObj[i].Character = chars[i];
                    allCharsAsObj[i].IncrementFrequency();
                }
                i++;
                
            }
            //for (int i = 0; i < asciiVals.Length; i++)
            //{
            //    int j = i;
            //    if ((int) chars[i] == j)
            //    {
            //        allCharsAsObj[i] = new CharacterFrequency(chars[i]) {Character = chars[i]};
            //        allCharsAsObj[i].IncrementFrequency();
            //    }
            //    //for (int j = 0; j < chars.Length; j++)
            //    //{
            //    //    if ((int)chars[j] == i)
            //    //    {
            //    //        allCharsAsObj[i] = new CharacterFrequency(chars[i]);
            //    //        allCharsAsObj[i].Character = chars[i];
            //    //        allCharsAsObj[i].IncrementFrequency();
            //    //    }
                    
            //    //}
            //}

            foreach (CharacterFrequency character in allCharsAsObj)
            {
                Console.WriteLine("Character " + character.Character + " appears " + character.Frequency + "times in the array.");
            }

            //int[] counter = new int[256];
            //int len = chars.Length;
            //CharacterFrequency[] characterFreqAsArrayOfObjects = new CharacterFrequency[len];

            ////for (int i = 0; i < len; i++)
            ////{
            ////    for (int j = 0; j < counter.Length; j++)
            ////    {
            ////        if ((int)chars[i] == counter[i])
            ////        {
            ////            CharacterFrequency aCharacterObject = new CharacterFrequency();
            ////            aCharacterObject = characterFreqAsArrayOfObjects[i];
            ////        }
            ////    }
            ////}

            //// We are creating another array with the size of String
            ////char array[] = new char[str.length()];
            //char[] charArray = new char[len];
            //for (int i = 0; i < len; i++)
            //{
            //    charArray[i] = chars[i];
            //    int flag = 0;
            //    for (int j = 0; j <= i; j++)
            //    {

            //        /* If a char is found in String then set the flag 
            //         * so that we can print the occurrence
            //         */
            //        if (chars[i] == charArray[j])
            //            flag++;
            //    }

            //    if (flag == 1)
            //        Console.WriteLine("Occurrence of char " + chars[i]
            //                                                 + " in the String is:" + counter[chars[i]]);
            //}

            //foreach (char aChar in chars)
            //{
            //    // get the ASCII value of aChar and use it as the index
            //    /*char[i].Character = aChar*/;
            //    int charToCheckIndex = (int)aChar;
            //    for (i = 0; i < chars.Length; i++)
            //    {
            //        // look for matching 
            //        if ((int)chars[i] == charToCheckIndex)
            //        {
            //            aFreqObjArr[charToCheckIndex].IncrementFrequency();       // this doesn't work; the value is always reset to 1 when the loop exits even when I see it get incremented in the debugger
            //            //aFreqObjArr[charToCheckIndex].IncrementFrequency();
            //            //CharacterFrequencyObjectArray[i] = aFreqObjArr[charToCheckIndex];
            //            //i++;
            //        }
            //    }
            //    // CharacterFrequency characterFrequencyObject = new CharacterFrequency(chars[i]);
            //}
        }

    }
}
