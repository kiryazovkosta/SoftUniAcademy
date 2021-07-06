// ------------------------------------------------------------------------------------------------
//  <copyright file="List.cs" company="Business Management System Ltd.">
//      Copyright "2021" (c), Business Management System Ltd.
//      All rights reserved.
//  </copyright>
//  <author>Kosta.Kiryazov</author>
// ------------------------------------------------------------------------------------------------

namespace ShoppingList
{
    #region Using

    using System;
    using System.Collections.Generic;
    using System.Linq;

    #endregion

    public class List
    {
        private static void Main(string[] args)
        {
            List<string> groceries = Console.ReadLine().Split("!", StringSplitOptions.RemoveEmptyEntries).ToList();
            string input = Console.ReadLine();
            while (input != "Go Shopping!")
            {
                string[] command = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string operation = command[0];
                switch (operation)
                {
                    case "Urgent":
                        string item = command[1];
                        Urgent(groceries, item);
                        break;
                    case "Unnecessary":
                        item = command[1];
                        Unnecessary(groceries, item);
                        break;
                    case "Correct":
                        string oldItem = command[1];
                        string newItem = command[2];
                        Correct(groceries, oldItem, newItem);
                        break;
                    case "Rearrange":
                        item = command[1];
                        Rearrange(groceries, item);
                        break;
                    default:
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", groceries));
        }

        private static void Rearrange(List<string> groceries, string item)
        {
            if (groceries.Contains(item))
            {
                groceries.Remove(item);
                groceries.Add(item);
            }
        }

        private static void Correct(List<string> groceries, string oldItem, string newItem)
        {
            if (groceries.Contains(oldItem))
            {
                int index = groceries.IndexOf(oldItem);
                groceries[index] = newItem;
            }
        }

        private static void Unnecessary(List<string> groceries, string item)
        {
            if (groceries.Contains(item))
            {
                groceries.Remove(item);
            }
        }

        private static void Urgent(List<string> groceries, string item)
        {
            if (!groceries.Contains(item))
            {
                groceries.Insert(0, item);
            }  
        }
    }
}