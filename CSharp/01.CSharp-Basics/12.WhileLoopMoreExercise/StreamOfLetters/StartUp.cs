namespace StreamOfLetters
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string word = string.Empty;
            string fullWord = string.Empty;
            bool isC = false;
            bool isO = false;
            bool isN = false;

            string input = Console.ReadLine();
            while (input != "End")
            {
                if (Char.IsLetter(input, 0))
                {
                    if (input == "c")
                    {
                        if (isC)
                        {
                            word += input;
                        }
                        else
                        {
                            isC = true;
                            if (isC && isO && isN)
                            {
                                fullWord += word + " ";
                                isC = false;
                                isO = false;
                                isN = false;
                                word = string.Empty;
                            }
                        }
                    }
                    else if (input == "o")
                    {
                        if (isO)
                        {
                            word += input;
                        }
                        else
                        {
                            isO = true;
                            if (isC && isO && isN)
                            {
                                fullWord += word + " ";
                                isC = false;
                                isO = false;
                                isN = false;
                                word = string.Empty;
                            }
                        }
                    }
                    else if (input == "n")
                    {
                        if (isN)
                        {
                            word += input;
                        }
                        else
                        {
                            isN = true;
                            if (isC && isO && isN)
                            {
                                fullWord += word + " ";
                                isC = false;
                                isO = false;
                                isN = false;
                                word = string.Empty;
                            }
                        }
                    }
                    else
                    {
                        word += input;
                    }
                }

                input = Console.ReadLine();
            }

            if (!String.IsNullOrEmpty(fullWord))
            {
                Console.WriteLine(fullWord);
            }
        }
    }
}
