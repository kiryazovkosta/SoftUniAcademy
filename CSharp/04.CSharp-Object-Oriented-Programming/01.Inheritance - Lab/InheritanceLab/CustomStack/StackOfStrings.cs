namespace CustomStack
{
    using System.Collections.Generic;
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            return base.Count == 0;
        }

        public void AddRange(Stack<string> elements)
        {
            foreach (var element in elements)
            {
                base.Push(element);
            }
        }
    }
}