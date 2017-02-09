using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace CheckerInterface
{
    public enum Figure
    {
        checker,
        damka,
        empty
    }
    public enum Color
    {
        white,
        black,
        empty
    }
    public enum Backlight
    {
        false_,
        true_
    }

    public class Cell
    {
        private static iController controller;
        private static System.Drawing.Bitmap[,,] imgFigure = new System.Drawing.Bitmap[2, 2, 2];
        private PictureBox body;
        private Figure figure = Figure.empty;
        private Color color = Color.empty;
        public readonly int x, y;

        public Cell(int sizeCell, int x, int y, Panel panel)
        {
            this.x = x; this.y = y;
            body = new PictureBox();
            panel.Controls.Add(body);
            body.Size = new System.Drawing.Size(sizeCell, sizeCell);
            body.Location = new System.Drawing.Point(x * sizeCell, y * sizeCell);
            if ((x + y) % 2 == 1)
                body.Image = Properties.Resources.BlackCell;
            else
                body.Image = Properties.Resources.WhiteCell;                

            body.SizeMode = PictureBoxSizeMode.Zoom;//Масштабирует картинки
            body.Click += new System.EventHandler(ClickCell);//Каждой клетке - событие
        }
        public static void SetController(iController _controller)
        {
            controller = _controller;
        }
        public static void SetImages()
        {
            imgFigure[(int)Color.white, (int)Figure.checker, 0] = Properties.Resources.WhiteChecker;
            imgFigure[(int)Color.white, (int)Figure.checker, 1] = Properties.Resources.LightWhiteChecker;
            imgFigure[(int)Color.white, (int)Figure.damka, 0] = Properties.Resources.WhiteQueen;
            imgFigure[(int)Color.white, (int)Figure.damka, 1] = Properties.Resources.LightWhiteQueen;

            imgFigure[(int)Color.black, (int)Figure.checker, 0] = Properties.Resources.BlackChecker;
            imgFigure[(int)Color.black, (int)Figure.checker, 1] = Properties.Resources.LightBlackChecker;
            imgFigure[(int)Color.black, (int)Figure.damka, 0] = Properties.Resources.BlackQueen;
            imgFigure[(int)Color.black, (int)Figure.damka, 1] = Properties.Resources.LightBlackQueen;
        }

        public bool isEmpty() { return (figure == Figure.empty); }
        public Color GetColor() { return color; }

        public void SetEmpty()
        {
            color = Color.empty;
            figure = Figure.empty;
            body.Image = Properties.Resources.BlackCell;
        }
        public void SetOtherColor()
        {
            if (color == Color.white) color = Color.black;
            else if (color == Color.black) color = Color.white;
        }
        public void SetFigure(Color col, Figure fig)
        {
            color = col;
            figure = fig;
            body.Image = imgFigure[(int)color, (int)figure, (int)Backlight.false_];      
        }
        public void BacklightOn()
        {
            body.Image = imgFigure[(int)color, (int)figure, (int)Backlight.true_];
        }
        public void BacklightOff()
        {
            body.Image = imgFigure[(int)color, (int)figure, (int)Backlight.false_];
        }

        public void ClickCell(object sender, EventArgs e)
        {
            controller.ClickCell(this);
        }
    }
}
