using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dIplom3
{
    public partial class Form1 : Form
    {
        private Control activeTool;
        private Point? previousPoint = null;
        private List<Line> lines = new List<Line>();
        private Line selectedLine = null;
        public Form1()
        {
            InitializeComponent();
            canvas.MouseClick += canvasClick;
            canvas.Paint += canvasPaint;
        }

        private void wallButtonClick(object sender, EventArgs e)
        {
            activeTool = sender as Control;
            (sender as Button).BackColor = Color.Red;
        }

        private void canvasPaint(object sender, PaintEventArgs e)
        {
            foreach (var line in lines)
            {
                line.Draw(e.Graphics);
            }
        }

        private void canvasClick(object sender, MouseEventArgs e)
        {
            if (activeTool != null && activeTool.Equals(wallButton))  
            {
                if (previousPoint is null)
                {
                    previousPoint = e.Location;
                }
                else
                {
                    using (Graphics g = canvas.CreateGraphics())
                    {
                        g.DrawLine(Pens.Black, previousPoint.Value, e.Location);
                        lines.Add(new Line(previousPoint, e.Location, LineType.Straight));
                        previousPoint = null;
                    }
                }
            }
            else if (activeTool != null && activeTool.Equals(cursorButton))
            {
                foreach (var line in lines)
                {
                    if (line.hitTest(e.Location))
                    {
                        selectedLine = line;
                        selectedLine.Selected = true;
                        canvas.Invalidate();
                        return;
                    }
                }
                selectedLine = null;
                foreach (var line in lines)
                {
                    line.Selected = false;
                }
                canvas.Invalidate();
            }
        }

        private void cursorButton_Click(object sender, EventArgs e)
        {
            activeTool = sender as Control;
            (sender as Button).BackColor = Color.Red;
        }
    }
    public class Line
    {
        private Point? startPoint;
        private Point? endPoint;
        private LineType type;
        public bool Selected { get; set; } = false;
        public Line()
        {
            startPoint = null;
            endPoint = null;
        }
        public Line(Point? startPoint, Point? endPoint, LineType type)
        {
            this.startPoint = startPoint;
            this.endPoint = endPoint;
            this.type = type;
        }
        public bool hitTest(Point point)
        {
        // Сделать так, чтобы линия не выделялась, если точка принадлежит прямой, но не принадлежит отрезку-линии.
            const int HitRange = 5;
            double distance = Math.Abs((endPoint.Value.Y - startPoint.Value.Y) * point.X - (endPoint.Value.X - startPoint.Value.X) * point.Y + endPoint.Value.X * startPoint.Value.Y - endPoint.Value.Y * startPoint.Value.X) /
                          Math.Sqrt(Math.Pow(endPoint.Value.Y - startPoint.Value.Y, 2) + Math.Pow(endPoint.Value.X - startPoint.Value.X, 2));

            return distance <= HitRange;
        }
        public void Draw(Graphics g)
        {
            Pen pen = Selected ? Pens.Red : Pens.Black;
            g.DrawLine(pen, startPoint.Value, endPoint.Value);
        }
    }
    public enum LineType
    {
        Straight,
        Curve
    }
}

