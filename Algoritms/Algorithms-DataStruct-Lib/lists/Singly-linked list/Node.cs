using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms_DataStruct_Lib.lists
{
    public class Node<T>
    {
        public T value { get; set; }
        public Node<T> Next { get; set; }

        public Node(T value)
        {
            this.value = value;
        }
    }
}
