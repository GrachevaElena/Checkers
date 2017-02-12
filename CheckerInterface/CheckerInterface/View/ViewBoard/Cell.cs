using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace CheckerInterface
{
    public class Cell
    {
        private static iController controller;
        private static System.Drawing.Bitmap[,,] imgFigure = new System.Drawing.Bitmap[2, 2, 2];
        private PictureBox body;
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
        public void SetEmpty()
        {
            body.Image = Properties.Resources.BlackCell;
        }

        public void SetFigure(Color col, Figure fig, Light l)
        {
            body.Image = imgFigure[(int)col, (int)fig, (int)l];      
        }

        public void ClickCell(object sender, EventArgs e)
        {
            controller.ClickCell(x, y);
        }
    }
}
