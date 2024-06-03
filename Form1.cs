using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace dIplom3
{
    public partial class Form1 : Form
    {
        private Control activeTool;
        private Point? previousPoint = null;
        private List<IModelObject> lines = new List<IModelObject>();
        private List<SoundSource> soundSources = new List<SoundSource>();
        private List<IModelObject> selectedObjects = new List<IModelObject>();
        private bool isDragging = false;
        private Point? startDragPoint = null;
        public Form1()
        {
            InitializeComponent();
            canvas.MouseClick += canvasClick;
            canvas.Paint += canvasPaint;
            cursorButton.KeyDown += Form1_KeyDown;
        }

        private void ResetToolsBackColor()
        {
            foreach (var elem in panel1.Controls)
            {
                (elem as Button).BackColor = Color.LightGray;
            }
        }

        private void wallButtonClick(object sender, EventArgs e)
        {
            ResetToolsBackColor();
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
                if (e.Button == MouseButtons.Left)
                {
                    foreach (var line in lines)
                    {
                        if (line.HitTest(e.Location) && !selectedObjects.Contains(line))
                        {
                            selectedObjects.Add(line);
                            line.Selected = true;
                            canvas.Invalidate();
                            return;
                        }
                    }
                    foreach (var source in soundSources)
                    {
                        if (source.HitTest(e.Location) && !selectedObjects.Contains(source))
                        {
                            selectedObjects.Add(source);
                            source.Selected = true;
                            canvas.Invalidate();
                            return;
                        }
                    }
                    selectedObjects.Clear();
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
                else if (e.Button == MouseButtons.Right)
                {
                    foreach (var source in selectedObjects)
                    {
                        if (source is SoundSource && source.HitTest(e.Location))
                        {
                            var tmpSource = source as SoundSource;
                            var editForm = new SoundSourceEditForm(tmpSource.parameters, tmpSource.name);
                            editForm.ShowDialog();
                        }
                    }
                }
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
                    soundSources.Add(new SoundSource(e.Location, $"soundSource{soundSources.Count}"));
                }
            }
        }

        private void cursorButton_Click(object sender, EventArgs e)
        {
            ResetToolsBackColor();
            activeTool = sender as Control;
            (sender as Button).BackColor = Color.Red;
        }

        private void soundSourceButton_Click(object sender, EventArgs e)
        {
            ResetToolsBackColor();
            activeTool = sender as Control;
            (sender as Button).BackColor = Color.Red;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                lines = lines.Where(x => !x.Selected).ToList();
                soundSources = soundSources.Where(x => !x.Selected).ToList();
                selectedObjects.Clear();
                canvas.Invalidate();
            }
            else if (e.KeyCode == Keys.H)
            {
                Debug.WriteLine(selectedObjects.Count);
            }
        }

        private void canvasMouseDown(object sender, MouseEventArgs e)
        {
            foreach (IModelObject elem in selectedObjects)
            {
                if (elem.HitTest(e.Location))
                {
                    startDragPoint = e.Location;
                    isDragging = true; 
                    break;
                }
            }
        }
        private void canvasMouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                int dx = e.X - startDragPoint.Value.X;
                int dy = e.Y - startDragPoint.Value.Y;
                foreach (var elem in selectedObjects)
                {
                    var referencePoints = elem.GetReferencePoints().ToArray();
                    for (int i = 0; i < elem.GetReferencePoints().Count; i++)
                    {
                        referencePoints[i].X += dx;
                        referencePoints[i].Y += dy;
                    }
                    elem.SetReferencePoints(new List<Point>(referencePoints));
                }
                startDragPoint = e.Location;
                canvas.Invalidate();
            }
        }
        private void canvasMouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
            startDragPoint = null;
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
                openFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    try
                    {
                        Clear();
                        string xmlText = File.ReadAllText(filePath);
                        Serializer serializer = new Serializer();
                        XmlDocument doc = new XmlDocument();
                        doc.LoadXml(xmlText);
                        XmlNodeList wallNodes = doc.SelectNodes("//walls/wall");
                        if (wallNodes != null)
                        {
                            foreach (XmlNode wall in wallNodes)
                            {
                                Point startPoint = serializer.stringToPoint(wall.Attributes["startPoint"].Value);
                                Point endPoint = serializer.stringToPoint(wall.Attributes["endPoint"].Value);
                                lines.Add(new Line(startPoint, endPoint, LineType.Straight));
                            }
                        }
                        XmlNodeList soundSourceNodes = doc.SelectNodes("//soundSources/soundSource");
                        if (soundSourceNodes != null)
                        {
                            foreach (XmlNode source in soundSourceNodes)
                            {
                                Point center = serializer.stringToPoint(source.Attributes["center"].Value);
                                string name = source.Attributes["name"].Value;
                                int diameter = int.Parse(source.Attributes["diameter"].Value);
                                Dictionary<string, string> parameters = serializer.stringToParametersDict(source.InnerText);
                                soundSources.Add(new SoundSource(center, diameter, name, parameters));
                            }
                        }
                        canvas.Invalidate();
                        MessageBox.Show($"Модель импортирована из файла {filePath}", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при загрузке файла {filePath}", "Доступ запрещен", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
                openFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    try
                    {
                        Serializer serializer = new Serializer();
                        string head = serializer.createXmlHead();
                        serializer.Serialize(filePath, head);
                        string previousFileContent = File.ReadAllText(filePath);
                        int insertPosition = previousFileContent.IndexOf("</globalSettings>");
                        insertPosition += "</globalSettings>".Length;
                        string wallsString = "";
                        string sourcesString = "";
                        foreach (var wall in lines)
                        {
                            wallsString += (wall as Line).ConvertToXmlTag(serializer, 3);
                        }
                        foreach (var source in soundSources)
                        {
                            sourcesString += source.ConvertToXmlTag(serializer, 3);
                        }
                        string body = '\n' + serializer.createXmlTag("primitives", null, $"{serializer.createXmlTag("walls", null, wallsString, 2)}\n{serializer.createXmlTag("soundSources", null, sourcesString, 2)}", 1);
                        string newContentFile = previousFileContent.Insert(insertPosition, body);
                        serializer.Serialize(filePath, newContentFile);

                        MessageBox.Show($"Модель экспортирована в файл {filePath}", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при загрузке файла {filePath}", "Доступ запрещен", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void Clear()
        {
            lines.Clear();
            soundSources.Clear();
            previousPoint = null;
            selectedObjects.Clear();
        }
        
    }
    interface IModelObject
    {
        void Draw(Graphics g);
        bool Selected { get; set; }
        bool HitTest(Point point);
        List<Point> GetReferencePoints();
        void SetReferencePoints(List<Point> referencePoints);
    }
    public class Line: IModelObject
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
        
        public override bool Equals(object obj)
        {
            // Проверяем, является ли obj объектом типа Line
            if (obj == null || !(obj is Line))
            {
                return false;
            }

            // Приводим obj к типу Line
            Line otherLine = (Line)obj;
            // Сравниваем startPoint и endPoint текущего объекта с другим объектом Line
            return this.startPoint.Equals(otherLine.startPoint) && this.endPoint.Equals(otherLine.endPoint);
        }
        public bool HitTest(Point point)
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

        public List<Point> GetReferencePoints()
        {
            return new List<Point> { startPoint.Value, endPoint.Value };
        }

        public void SetReferencePoints(List<Point> referencePoints)
        {
            startPoint = referencePoints.First();
            endPoint = referencePoints.Last();
        }

        private Dictionary<string, string> GetParameters()
        {
            var pars = new Dictionary<string, string>
            {
                { "startPoint", this.startPoint.ToString() },
                { "endPoint", this.endPoint.ToString() },
                { "type", this.type.ToString() },
            };
            return pars;
        }

        public string ConvertToXmlTag(Serializer serializer, int amountTab)
        {
            return serializer.createXmlTag("wall", GetParameters(), "", amountTab);
        }
    }
    public enum LineType
    {
        Straight,
        Curve
    }
    public class SoundSource: IModelObject
    {
        public bool Selected { get; set; } = false;
        public static int STANDART_DIAMETER = 10;
        public string name { get; set; }
        private Point? center;
        private int diameter;
        public Dictionary<string, string> parameters { get; set; }
        public SoundSource()
        {
            name = null;
            center = null;
            diameter = 0;
            parameters = new Dictionary<string, string>();
        }
        public SoundSource(Point? center, int diameter, string name, Dictionary<string, string> parameters)
        {
            this.name = name;
            this.center = center;
            this.diameter = diameter;
            this.parameters = parameters;
        }
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is SoundSource))
            {
                return false;
            }
            SoundSource other = obj as SoundSource;
            return center.Equals(other.center);
        }
        public SoundSource(Point? center, string name)
        {
            this.name = name;
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

        public List<Point> GetReferencePoints()
        {
            return new List<Point> { center.Value };
        }

        public void SetReferencePoints(List<Point> referencePoints)
        {
            center = referencePoints.First();
        }

        private Dictionary<string, string> GetParameters()
        {
            var pars = new Dictionary<string, string>
            {
                { "name", this.name },
                { "diameter", this.diameter.ToString() },
                { "center", this.center.Value.ToString() }
            };
            return pars;
        }
        public string ConvertToXmlTag(Serializer serializer, int amountTag)
        {
            return serializer.createXmlTag("soundSource", GetParameters(), $"{serializer.dictToString(parameters)}", amountTag);
        }
    }
}

