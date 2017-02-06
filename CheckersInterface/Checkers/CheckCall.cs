using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
namespace Checkers
{
    class CheckCall
    {
        [DllImport(@"Checkers.dll")]
        public static extern int Call(int x, int y);
    }
}
