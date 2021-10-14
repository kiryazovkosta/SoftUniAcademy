// ------------------------------------------------------------------------------------------------
//  <copyright file="BookComparator.cs" company="Business Management System Ltd.">
//      Copyright "" (c), Business Management System Ltd.
//      All rights reserved.
//  </copyright>
//  <author>Kosta.Kiryazov</author>
// ------------------------------------------------------------------------------------------------

namespace IteratorsAndComparators
{
    using System;
    using System.Collections.Generic;

    public class BookComparator : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            if (x.Title.CompareTo(y.Title) != 0)
            {
                return x.Title.CompareTo(y.Title);
            }

            return y.Year.CompareTo(x.Year);
        }
    }
}