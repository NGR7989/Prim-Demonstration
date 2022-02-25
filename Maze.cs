using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Prim_s_Demonstration
{
    public partial class Maze : Form
    {
        private int width;
        private int height;

        private Stack<Node> nodeStack;
        private Node[,] nodeGrid;

        Random rng;

        public Color fillColor;
        public Color defaultColor;

        private int nodeSize;

        public Maze(int width, int height)
        {
            InitializeComponent();

            rng = new Random();

            fillColor = Color.Gray;
            defaultColor = Color.Black;

            nodeStack = new Stack<Node>();
            nodeGrid = new Node[width, height];

            nodeSize = 30;

            this.width = width;
            this.height = height;

            // Populate nodeGrid with default nodes with position 
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    nodeGrid[x, y] = new Node(x, y);
                }
            }

            GenerateMaze();
            SetNodeDirections();
            VisualizeMaze();
            //VisualizeTileCover();
        }

        private void VisualizeTileCover()
        {
            foreach (Node node in nodeGrid)
            {
                PictureBox tile = new PictureBox();

                tile.Location = new Point( node.X * nodeSize, node.Y * nodeSize);
                tile.Width = nodeSize;
                tile.Height = nodeSize;
                tile.BackColor = Color.White;

                tile.Click += OnTileClick;


                this.Controls.Add(tile);
                Controls.SetChildIndex(tile, 3);
            }
        }

        private void OnTileClick(object sender, System.EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;

            pb.BackColor = Color.Transparent;
        }

        /// <summary>
        /// Directions are found by going through each child of the 
        /// node and gets the direction to the child
        /// </summary>
        private void SetNodeDirections()
        {
            foreach (Node node in nodeGrid)
            {
                List<Node> children = node.Children;

                // For every child set proper direciton indicator 
                foreach (Node child in children)
                {
                    // Get direction 
                    int xDiff = child.X - node.X;
                    int yDiff = child.Y - node.Y;

                    bool[] parentDirections = node.Directions;
                    bool[] childDirecitons = child.Directions; 

                    bool[] directions = new bool[4];

                    if(yDiff == 0) // Difference is left or right 
                    {
                        if(xDiff == 1) // right
                        {
                            directions[3] = true;
                        }
                        else // left 
                        {
                            directions[2] = true;
                        }
                    }
                    else // Difference is up or down 
                    {
                        if (yDiff == 1) // up
                        {
                            directions[0] = true;
                        }
                        else // down 
                        {
                            directions[1] = true;
                        }
                    }
                    // Setting the parents directions
                    bool[] newDirectionsParent = new bool[] 
                    { 
                        parentDirections[0] || directions[0],
                        parentDirections[1] || directions[1],
                        parentDirections[2] || directions[2],
                        parentDirections[3] || directions[3],
                    };

                    // Setting the childs directions that correlates
                    // in the opposite diriction of its parent 
                    bool[] newDirectionsChild = new bool[]
                    {
                        childDirecitons[0] || directions[1],
                        childDirecitons[1] || directions[0],
                        childDirecitons[2] || directions[3],
                        childDirecitons[3] || directions[2],
                    };

                    node.Directions = newDirectionsParent;
                    child.Directions = newDirectionsChild;
                }
            }
        }
        /// <summary>
        /// Goes through each node and visualizes it in its correct position
        /// </summary>
        private void VisualizeMaze()
        {
            foreach (Node node in nodeGrid)
            {
                GetNodeVisualized(node, (nodeSize / 3), node.X * nodeSize, node.Y * nodeSize);
            }
        }
        /// <summary>
        /// Creates a 3x3 tile node that shows both the position of 
        /// the node but also what directions they can go.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="size"></param>
        /// <param name="xOffset"></param>
        /// <param name="yOffset"></param>
        /// <returns></returns>
        private List<PictureBox> GetNodeVisualized(Node node, int size, int xOffset, int yOffset)
        {
            List<PictureBox> parts = new List<PictureBox>();

            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    PictureBox part = new PictureBox();

                    part.Location = new Point((x * size) + xOffset, (y * size) + yOffset);
                    part.Width = size;
                    part.Height = size;

                    if (x == 1 && y == 1)
                    {
                        part.BackColor = fillColor;
                    }
                    else
                    {
                        part.BackColor = defaultColor;
                    }

                    this.Controls.Add(part);
                    this.Controls.SetChildIndex(part, 2);

                    parts.Add(part);
                }
            }

            // Probably a better way to do this -> TODO Fix to optimize 

            // Check for direction cases 
            bool[] directions = node.Directions;

            if (directions[0]) // up
            {
                parts[5].BackColor = fillColor;
            }
            if (directions[1]) // down
            {
                parts[3].BackColor = fillColor;
            }
            if (directions[2]) // left
            {
                parts[1].BackColor = fillColor;
            }
            if (directions[3]) // right
            {
                parts[7].BackColor = fillColor;
            }

            return parts;
        }
        /// <summary>
        /// Creates a node tree using Prim's algorithm 
        /// </summary>
        private void GenerateMaze()
        {
            // Initial value 
            nodeStack.Push(nodeGrid[0, 0]);
            nodeGrid[0, 0].Occupied = true;

            int counter = 0;

            // Continue until tree is fully connected 
            do
            {
                if(nodeStack.Count == 0)
                {
                    break;
                }

                // Get current
                Node current = nodeStack.Peek();

                // Get neighbors
                List <Node> neighbors = GetNeighbors(current.X, current.Y);

                // Check if valid 
                if(neighbors.Count > 0)
                {
                    // Random child 
                    Node target = neighbors[rng.Next(0, neighbors.Count)];

                    // Add child to current 
                    current.Children.Add(target);

                    // Set target to occupied 
                    target.Occupied = true;

                    // Add target to stack
                    nodeStack.Push(target);

                    counter++;
                }
                else
                {
                    // No longer can go to this node 
                    nodeStack.Pop();
                }


            } while (counter < (width * height));
        }
        /// <summary>
        /// Gets each neighbor in one axis directions but only 
        /// if they are within the bounds of the map and are 
        /// not occupied 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private List<Node> GetNeighbors(int x, int y)
        {
            List<Node> neighbors = new List<Node>();

            if(x + 1 < width) // Right
            {
                if(nodeGrid[x + 1,y].Occupied == false)
                    neighbors.Add(nodeGrid[x + 1, y]);
            }
            if (x - 1 >= 0) // Left 
            {
                if (nodeGrid[x - 1, y].Occupied == false)
                    neighbors.Add(nodeGrid[x - 1, y]);
            }
            if (y + 1 < height) // Up 
            {
                if (nodeGrid[x, y + 1].Occupied == false)
                    neighbors.Add(nodeGrid[x, y + 1]);
            }
            if (y - 1 >= 0) // Down 
            {
                if (nodeGrid[x, y - 1].Occupied == false)
                    neighbors.Add(nodeGrid[x, y - 1]);
            }

            return neighbors;
        }
    }
}
