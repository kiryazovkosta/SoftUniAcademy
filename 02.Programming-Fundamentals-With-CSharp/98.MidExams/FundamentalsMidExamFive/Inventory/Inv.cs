// ------------------------------------------------------------------------------------------------
//  <copyright file="Inv.cs" company="Business Management System Ltd.">
//      Copyright "2021" (c), Business Management System Ltd.
//      All rights reserved.
//  </copyright>
//  <author>Kosta.Kiryazov</author>
// ------------------------------------------------------------------------------------------------

namespace Inventory
{
    #region Using

    using System;
    using System.Collections.Generic;
    using System.Linq;

    #endregion

    public class Inv
    {
        private static void Main(string[] args)
        {
            List<string> items = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();
            string operation = Console.ReadLine();
            while (operation != "Craft!")
            {
                string[] data = operation.Split("-", 2, StringSplitOptions.RemoveEmptyEntries);
                string command = data[0].Trim();
                switch (command)
                {
                    case "Collect":
                        string item = data[1].Trim();
                        Collect(items, item);
                        break;

                    case "Drop":
                        item = data[1].Trim();
                        Drop(items, item);
                        break;

                    case "Combine Items":
                        string[] values = data[1].Split(":", StringSplitOptions.RemoveEmptyEntries);
                        CombineItems(items, values[0].Trim(), values[1].Trim());
                        break;

                    case "Renew":
                        item = data[1].Trim();
                        Renew(items, item);
                        break;
                }

                operation = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", items));
        }

        private static void Renew(List<string> items, string item)
        {
            if (items.Contains(item))
            {
                items.Remove(item);
                items.Add(item);
            }
        }

        private static void CombineItems(List<string> items, string oldItem, string newItem)
        {
            if (items.Contains(oldItem))
            {
                int index = items.IndexOf(oldItem);
                if (index <= items.Count - 2)
                {
                    items.Insert(index + 1, newItem);
                }
                else
                {
                    items.Add(newItem);
                }
            }
        }

        private static void Drop(List<string> items, string item)
        {
            if (items.Contains(item))
            {
                items.Remove(item);
            }
        }

        private static void Collect(List<string> items, string item)
        {
            if (!items.Contains(item))
            {
                items.Add(item);
            }
        }
    }
}