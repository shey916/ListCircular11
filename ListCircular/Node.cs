using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListCircular
{
    internal class Node
    {
            private int data;
            private Node next;

            public int Data
            {
                get { return data; }
                set { data = value; }
            }

            public Node Next
            {
                get { return next; }
                set { next = value; }
            }

            public Node(int dato)
            {
                this.data = dato;
                this.next = null;
            }
        }
    }