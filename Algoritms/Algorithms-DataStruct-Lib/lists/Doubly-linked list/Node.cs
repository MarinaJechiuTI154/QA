using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms_DataStruct_Lib.lists.Doubly_linked_list
{
    public class Node<T>
    {
        public T Value { set; get; }
        public Node<T> Next { set; get; }
        public Node<T> Prev { set; get; }

        public Node(T value)
        {
            this.Value = value;
        }

    }
}
