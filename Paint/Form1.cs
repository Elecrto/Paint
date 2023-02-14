using System.Net.Sockets;

namespace Paint
{
    public partial class Paint : Form
    {
        private bool onClick = false;
        private Points points = new Points(2);
        Graphics g;
        Pen pen = new Pen(Color.Black,3f);

        public Paint()
        {
            InitializeComponent();
            SetSize();
            button8.PerformClick();
        }

        private void SetSize()
        {
            g = panel1.CreateGraphics();
            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            onClick = true;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            onClick = false;
            points.Reset();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!onClick) { return; }
            
            points.Add(e.X, e.Y);
            if(points.Count >= 2)
            {
                g.DrawLines(pen, points.GetPoints());
                points.Add(e.X, e.Y);
            }
        }

        private void panel1_Resize(object sender, EventArgs e)
        {
            SetSize();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pen.Color = ((Button)sender).BackColor;
            button7.BackColor = ((Button)sender).BackColor;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pen.Color = colorDialog1.Color;
                ((Button)sender).BackColor = colorDialog1.Color;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            pen.Width = comboBox1.SelectedIndex * 2;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            pen.Width = 1;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            pen.Color = panel1.BackColor;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                pen.Width = 3;
            }
            else
            {
                pen.Width = comboBox1.SelectedIndex;
            }
        }
    }
}