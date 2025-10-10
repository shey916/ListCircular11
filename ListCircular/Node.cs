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

            public Node(int data)
            {
                this.data = data;
                this.next = null;
            }
        public override string ToString()
        {
            // Usando el nombre de la variable de instancia 'data'
            return "Dato:" + data;
        }
    }
    }