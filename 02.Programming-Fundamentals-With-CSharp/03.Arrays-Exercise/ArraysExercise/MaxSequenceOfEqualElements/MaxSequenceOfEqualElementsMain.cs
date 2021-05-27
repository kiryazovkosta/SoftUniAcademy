namespace MaxSequenceOfEqualElements
{
    using System;
    using System.Linq;

    public class MaxSequenceOfEqualElementsMain
    {
        public static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                                ?.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray()
                            ?? new int[] { };

            int sequenceMaxCounter = int.MinValue;
            int sequenceMaxElement = int.MinValue;
            int currentCounter = int.MinValue;
            int currentElement = int.MaxValue;

            for (int numberIndex = 0; numberIndex < numbers.Length; numberIndex++)
            {
                var currentNumber = numbers[numberIndex];
                if (numberIndex == 0)
                {
                    sequenceMaxCounter = 1;
                    sequenceMaxElement = currentNumber;
                    currentCounter = 1;
                    currentElement = currentNumber;
                }
                else if (numberIndex == numbers.Length - 1)
                {
                    if (currentNumber == currentElement)
                    {
                        currentCounter++;
                    }
                    else
                    {
                        if (currentCounter > sequenceMaxCounter)
                        {
                            sequenceMaxCounter = currentCounter;
                            sequenceMaxElement = currentElement;
                        }

                        currentElement = currentNumber;
                        currentCounter = 1;
                    }

                    if (currentCounter > sequenceMaxCounter)
                    {
                        sequenceMaxCounter = currentCounter;
                        sequenceMaxElement = currentElement;
                    }
                }
                else
                {
                    if (currentNumber == currentElement)
                    {
                        currentCounter++;
                    }
                    else
                    {
                        if (currentCounter > sequenceMaxCounter)
                        {
                            sequenceMaxCounter = currentCounter;
                            sequenceMaxElement = currentElement;
                        }

                        currentElement = currentNumber;
                        currentCounter = 1;
                    }
                }
            }

            for (int i = 0; i < sequenceMaxCounter; i++)
            {
                Console.Write($"{sequenceMaxElement} ");
            }
        }
    }
}
