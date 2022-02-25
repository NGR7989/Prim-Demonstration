using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prim_s_Demonstration
{
    public partial class Map : Form
    {

        private int width;
        private int height;

        private Color PathTile;
        private Color FillTile;

        private bool[,] tileMap; // True -> Occupied, False -> Unoccupied 
        private Stack<int> tileStack; 

        Random rng;

        List<PictureBox> mapPanels;

        public Map(int width, int height, int mapType)
        {
            InitializeComponent();

            rng = new Random();

            PathTile = Color.Black;
            FillTile = Color.White;

            tileStack = new Stack<int>();
            mapPanels = new List<PictureBox>();

            this.width = width;
            this.height = height;

            tileMap = new bool[width, height];

            for(int i = 0; i < width * height; i++)
            {
                tileMap[i % width, i / height] = new bool();
            }

            GenerateMap();
            VisualizeMap();

            switch(mapType)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
            }
        }

        private void VisualizeMap()
        {
            for (int x = 0; x < tileMap.GetLength(0); x++)
            {
                for (int y = 0; y < tileMap.GetLength(1); y++)
                {
                    PictureBox pb = new PictureBox();

                    pb.Location = new Point(x * 25, y * 25);
                    pb.Width = 25;
                    pb.Height = 25;
                    
                    if(tileMap[x,y] == true)
                    {
                        pb.BackColor = PathTile;
                    }
                    else
                    {
                        pb.BackColor = FillTile;
                    }

                    mapPanels.Add(new PictureBox());
                    this.Controls.Add(pb);
                }
            }
        }

        private void GenerateMap()
        {
            // Starting point and add to stack 
            tileStack.Push(0);

            do
            {
                // Start 
                int current = tileStack.Peek();

                int currentY = current / width;
                int currentX = current - (currentY * width); // Gets remainder from integer division 

                // Get possible directions
                List<int[]> neighborChoices = GetNeighborsNoDiagonals(currentX, currentY);

                int[] choice;

                int targetX = currentX;
                int targetY = currentY;

                // Trys to find a valid neighbor 
                while (neighborChoices.Count > 0)
                {
                    // Random choice
                    int index = rng.Next(0, neighborChoices.Count);
                    choice = neighborChoices[index];

                    targetX = choice[0];
                    targetY = choice[1];

                    // Checks if choice is valid 
                    if (CanConnect(currentX, currentY, targetX, targetY))
                    {
                        // We know that it is a valid choice now 
                        tileMap[targetX, targetY] = true;
                        tileStack.Push((targetX * width) + targetY);

                        break;
                    }
                    else
                    {
                        // Don't repeat unusable neighbor 
                        neighborChoices.RemoveAt(index);
                    }
                }

                if(neighborChoices.Count == 0)
                {
                    // Go backwards in stack and try again 
                    tileStack.Pop();
                }
                
            } while (tileStack.Count != 0);
        }

        /// <summary>
        /// Only returns neighbors that are in a single
        /// axis direction from the origin 
        /// </summary>
        /// <param name="x">Origin's X pos</param>
        /// <param name="y">Origin's Y pos</param>
        /// <returns></returns>
        private List<int[]> GetNeighborsNoDiagonals(int x, int y)
        {
            // Contains lists of nieghbors which hold x and y pos
            List<int[]> neighbors = new List<int[]>();

            // Up
            if (y - 1 >= 0)
            {
                if(!tileMap[x, y - 1])
                {
                    neighbors.Add(new int[] { x, y - 1 });
                }
            }
            // Down
            if (y + 1 < height)
            {
                if(!tileMap[x, y + 1])
                {
                    neighbors.Add(new int[] { x, y + 1 });
                }
            }
            // Left
            if (x - 1 >= 0)
            {
                if(!tileMap[x - 1, y])
                {
                    neighbors.Add(new int[] { x - 1, y });
                }
            }
            // Right
            if (x + 1 < width)
            {
                if(!tileMap[x + 1, y])
                {
                    neighbors.Add(new int[] { x + 1, y });
                }
            }

            return neighbors;
        }
        /// <summary>
        /// Only returns neighbors that are diagonal 
        /// from the origin 
        /// </summary>
        /// <param name="x">Origin's X pos</param>
        /// <param name="y">Origin's Y pos</param>
        /// <returns></returns>
        private List<int[]> GetDiagonalNeighbors(int x, int y)
        {
            // Contains lists of nieghbors which hold x and y pos
            List<int[]> neighbors = new List<int[]>();

            // Upper left
            if ((y - 1 >= 0) && (x - 1 >= 0))
            {
                if(!tileMap[x -1, y - 1]) 
                {
                    neighbors.Add(new int[] { y - 1, x - 1 });
                }
            }

            // Upper right
            if ((y - 1 >= 0) && (x + 1 < width))
            {
                if(!tileMap[x + 1, y - 1])
                {
                    neighbors.Add(new int[] { y - 1, x + 1 });
                }
            }

            // Bottom left
            if ((y + 1 < height) && (x - 1 >= 0))
            {
                if (!tileMap[x - 1, y + 1])
                {
                    neighbors.Add(new int[] { y + 1, x - 1 });
                }
            }

            // Bottom right 
            if ((y + 1 < height) && (x + 1 < width))
            {
                if (!tileMap[x + 1, y + 1])
                {
                    neighbors.Add(new int[] { y + 1, x + 1 });
                }
            }

            return neighbors;
        }
        /// <summary>
        /// Gets neighbors in both the diagonals
        /// and the single axis directions 
        /// </summary>
        /// <param name="x">Origin's X pos</param>
        /// <param name="y">Origin's Y pos</param>
        /// <returns></returns>
        private List<int[]> GetAllNeighbors(int x, int y)
        {
            List<int[]> AllNeighbors = new List<int[]>();

            List<int[]> diagonals = GetDiagonalNeighbors(x, y);
            List<int[]> notDiagonals = GetNeighborsNoDiagonals(x, y);

            foreach (int[] n in diagonals)
            {
                AllNeighbors.Add(n);
            }

            foreach (int[] n in notDiagonals)
            {
                AllNeighbors.Add(n);
            }

            return AllNeighbors;
        }
        /// <summary>
        /// Checks if the origin can connect to the 
        /// next point 
        /// </summary>
        /// <param name="startX">Origin's X pos</param>
        /// <param name="startY">Origin's Y pos</param>
        /// <param name="endX">Target's X pos</param>
        /// <param name="endY">Target's Y pos</param>
        /// <returns></returns>
        private bool CanConnect(int startX, int startY, int endX, int endY)
        {
            bool usable = true;

            // Get neighbors
            List<int[]> targetNeighbors = GetAllNeighbors(endX, endY);

            // Find what side to ignore
            // Value is 0 or direction to ignore 
            int checkX = startX - endX;
            int checkY = startY - endY;

            // Check if it has any other neighbors asides from 
            // start that are occupied 
            foreach (int[] neighbor in targetNeighbors)
            {
                int x = neighbor[0];
                int y = neighbor[1];

                // Skips origin and its two side tiles
                if(x == (endX + checkX) || y == (endY + checkY))
                {
                    continue;
                }
                
                // Checks if occupied 
                if(tileMap[x,y] == true)
                {
                    usable = false;
                    break;
                }
            }

            return usable;
        }

        private void Map_Load(object sender, EventArgs e)
        {

        }
    }
}
