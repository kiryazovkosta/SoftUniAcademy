﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GenericScale
{
    public class EqualityScale<T> 
    {
        private T left;
        private T right;

        public EqualityScale(T left, T right)
        {
            this.left = left;
            this.right = right;
        }

        public bool AreEqual()
        {
            bool areEqual = this.left.Equals(this.right);
            return areEqual;
        }
    }
}