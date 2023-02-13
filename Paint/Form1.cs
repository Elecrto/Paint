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
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pen.Color = ((Button)sender).BackColor;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pen.Color = colorDialog1.Color;
                ((Button)sender).BackColor = colorDialog1.Color;
            }
        }
    }
}