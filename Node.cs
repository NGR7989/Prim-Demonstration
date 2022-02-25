using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prim_s_Demonstration
{
    class Node
    {
        private bool occupied;
        private bool u, d, l, r; // Stores which directions are open 

        private int x, y;

        private List<Node> children;

        public bool Occupied { get { return occupied; } set { occupied = value; } }
        public bool[] Directions 
        { 
            get 
            { 
                return new bool[] { u, d, l, r }; 
            }
            set
            {
                u = value[0];
                d = value[1];
                l = value[2];
                r = value[3];
            }
        }
        public int X { get { return x; } }
        public int Y { get { return y; } }
        public List<Node> Children { get { return children; } }

        public Node(int x, int y)
        {
            occupied = false;

            u = false;
            d = false;
            l = false;
            r = false;

            this.x = x;
            this.y = y;

            children = new List<Node>();
        }
    }
}
