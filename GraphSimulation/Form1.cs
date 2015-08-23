using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace GraphSimulation
{
    public partial class Form1 : Form
    {
        public Graphics myGraph;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnNewFile_Click(object sender, EventArgs e)
        {
            pbCanvas.Width = panel1.Width / 2;
            pbCanvas.Height = panel1.Height;
            pbCanvas.Left = (panel1.Width - pbCanvas.Width) / 2;
            myGraph = pbCanvas.CreateGraphics();
            pbCanvas.Enabled = true;
            pbCanvas.Visible = true;
        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            MessageBox.Show("\"Save File\" Clicked");
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            MessageBox.Show("\"Print\" Clicked");
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            pbCanvas.Size += new Size(100, 100);
            pbCanvas.Left = (panel1.Width - pbCanvas.Width) / 2;
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            pbCanvas.Size += new Size(-100, -100);
            pbCanvas.Left = (panel1.Width - pbCanvas.Width) / 2;
        }

        private void btnZoomAdjust_Click(object sender, EventArgs e)
        {
            pbCanvas.Width = panel1.Width / 2;
            pbCanvas.Height = panel1.Height;
            pbCanvas.Left = (panel1.Width - pbCanvas.Width) / 2;
        }

        private void btnNewNode_Click(object sender, EventArgs e)
        {
            if (btnNewNode.Checked)
                this.Cursor = Cursors.Cross;
            else
                this.Cursor = Cursors.Default;
        }

        private void btnDelNode_Click(object sender, EventArgs e)
        {
            MessageBox.Show("\"Delete Node\" Clicked");
        }

        private void btnMoveNode_Click(object sender, EventArgs e)
        {
            MessageBox.Show("\"Move Node\" Clicked");
        }

        private void pbCanvas_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.Cursor == Cursors.Cross)
            {
                Pen myPen = new Pen(System.Drawing.Color.DarkCyan, 5);
                Rectangle myRectangle = new Rectangle(e.X, e.Y, 25, 25);
                myGraph = pbCanvas.CreateGraphics();
                myGraph.DrawEllipse(myPen, myRectangle);
            }
        }
    }
}
