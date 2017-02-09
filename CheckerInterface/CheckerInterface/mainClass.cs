using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckerInterface
{

    static class mainClass
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetCompatibleTextRenderingDefault(false);
            Game_model_observable game = new Game_model_observable();
            iController controller = new Controller(game);
            /*Application.EnableVisualStyles();                   //для проверки, а не запорол ли запуск программы)
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());*/
        }
    }
}
