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
        private List<SoundSource> soundSources = new List<SoundSource>();
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
            foreach (var source in soundSources)
            {
                source.Draw(e.Graphics);
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
                        //Потенциальный баг - selectedLine - последняя выделенная линия, хотя визуально выделенных линий может быть много
                        //Потенциальное решение - вместо переменной selectedLine завести список, в котором хранить все выделенные элементы
                    }
                }
                foreach(var source in soundSources)
                {
                    if (source.HitTest(e.Location))
                    {
                        source.Selected = true;
                        canvas.Invalidate();
                        return;
                    }
                }
                selectedLine = null;
                foreach (var line in lines)
                {
                    line.Selected = false;
                }
                foreach (var source in soundSources)
                {
                    source.Selected = false;
                }
                canvas.Invalidate();
            }
            else if (activeTool != null && activeTool.Equals(soundSourceButton))
            {
                // Добавить проверку на коллизии нового источника звука с уже существующими (см chatGPT)
                using (Graphics g = canvas.CreateGraphics())
                {
                    Brush brush = Brushes.Green;
                    Pen pen = Pens.Black;
                    int diameter = SoundSource.STANDART_DIAMETER;
                    g.DrawEllipse(pen, e.Location.X - diameter / 2, e.Location.Y - diameter / 2, diameter, diameter);
                    g.FillEllipse(brush, e.Location.X - diameter / 2, e.Location.Y - diameter / 2, diameter, diameter);
                    soundSources.Add(new SoundSource(e.Location));
                }
            }
        }

        private void cursorButton_Click(object sender, EventArgs e)
        {
            activeTool = sender as Control;
            (sender as Button).BackColor = Color.Red;
        }

        private void soundSourceButton_Click(object sender, EventArgs e)
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
            const int HitRange = 5;
            double distance = Math.Abs((endPoint.Value.Y - startPoint.Value.Y) * point.X - (endPoint.Value.X - startPoint.Value.X) * point.Y + endPoint.Value.X * startPoint.Value.Y - endPoint.Value.Y * startPoint.Value.X) /
                          Math.Sqrt(Math.Pow(endPoint.Value.Y - startPoint.Value.Y, 2) + Math.Pow(endPoint.Value.X - startPoint.Value.X, 2));
            bool insideRectangle = point.X >= Math.Min(startPoint.Value.X, endPoint.Value.X) &&
                            point.X <= Math.Max(startPoint.Value.X, endPoint.Value.X) &&
                            point.Y >= Math.Min(startPoint.Value.Y, endPoint.Value.Y) &&
                            point.Y <= Math.Max(startPoint.Value.Y, endPoint.Value.Y);
            return distance <= HitRange && insideRectangle;
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
    public class SoundSource
    {
        public bool Selected { get; set; } = false;
        public static int STANDART_DIAMETER = 10;
        private Point? center;
        private int diameter;
        private Dictionary<string, string> parameters;
        public SoundSource()
        {
            center = null;
            diameter = 0;
            parameters = new Dictionary<string, string>();
        }
        public SoundSource(Point? center)
        {
            this.center = center;
            diameter = STANDART_DIAMETER;
            parameters = new Dictionary<string, string>();
        }
        public void Draw(Graphics g) 
        {
            Brush brush = Brushes.Green;
            Pen pen = Selected ? Pens.Red : Pens.Black;
            g.DrawEllipse(pen, center.Value.X - diameter / 2, center.Value.Y - diameter / 2, diameter, diameter);
            g.FillEllipse(brush, center.Value.X - diameter / 2, center.Value.Y - diameter / 2, diameter, diameter);
        }
        public bool HitTest(Point point)
        {
            // Рассчитываем расстояние между центром круга и точкой
            double distance = Math.Sqrt(Math.Pow(point.X - center.Value.X, 2) + Math.Pow(point.Y - center.Value.Y, 2));

            // Если расстояние меньше или равно радиусу круга, то точка находится внутри круга
            return distance <= diameter / 2;
        }
    }
}

