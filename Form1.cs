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
    public partial class Form1 : Form
    {
        RadioButton[] mapTypes;

        private Maze map;

        public Form1()
        {
            InitializeComponent();

            mapTypes = new RadioButton[4];

            mapTypes[0] = radioButton_Default;
            mapTypes[1] = radioButton_LoadByClick;
            mapTypes[2] = radioButton_LoadByRing;
            mapTypes[3] = radioButton_LoadSlow;
        }

        private void button_Generate_Click(object sender, EventArgs e)
        {
            /*
            int mapType = 0;
            for (int i = 0; i < mapTypes.Length; i++)
            {
                if(mapTypes[i].Checked)
                {
                    mapType = i;
                    break;
                }
            }
            */

            map = new Maze(
                Convert.ToInt32(textBox_MapWidth.Text),
                Convert.ToInt32(textBox_MapHeight.Text)
                );

            map.Show();
            
        }
    }
}
