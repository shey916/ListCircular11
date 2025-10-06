using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListCircular
{
    internal class Node
    {
            private int dato;
            private Node next;

            public int Dato
            {
                get { return dato; }
                set { dato = value; }
            }

            public Node Next
            {
                get { return next; }
                set { next = value; }
            }

            public Node(int dato)
            {
                this.dato = dato;
                this.next = null;
            }
        }
    }