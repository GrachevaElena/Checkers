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
        empty,
        checker,
        damka
    }
    public enum Color
    {
        empty,
        white,
        black
    }

    public class Cell
    {
        private static iController controller;
        private PictureBox body;
        private Figure figure = Figure.empty;
        private Color color = Color.empty;
        Cell(int sizeCell, int x, int y, Panel panel, int sizeBoard)
        {
            body = new PictureBox();
            panel.Controls.Add(body);
            body.Size = new System.Drawing.Size(sizeCell, sizeCell);
            body.Location = new System.Drawing.Point(x * sizeCell, (sizeBoard - 1) * sizeCell - y * sizeCell);
            if ((x + y) % 2 == 1)
                body.Image = Properties.Resources.WhiteCell;
            else
                body.Image = Properties.Resources.BlackCell;                

            body.SizeMode = PictureBoxSizeMode.Zoom;//Масштабирует картинки
            body.Click += new System.EventHandler(ClickCell);//Каждой клетке - событие
        }
        public bool isEmpty() { return (figure == Figure.empty); }
        public Color GetColor() { return color; }

        public void Delete() { }
        public void ChangeColor()
        {
            if (color == Color.white)
                color = Color.black;
            else if (color == Color.black)
                color = Color.white;
        }
        static void SetController(iController _controller)
        {
            controller = _controller;
        }

        public void ClickCell(object sender, EventArgs e)
        {
            controller.ClickCell(this);
        }
    }
}
