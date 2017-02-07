using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckerInterface
{
    public class Game_model_observable : iSubject, iGame
    {
        private StatusGame statusGame;
        private bool ii;
        private int sizeCell;
        private int sizeBoard;

        public void registerObserver(iObserver o)
        {

        }
        public void removeObserver(iObserver o)
        {

        }
        public void notifyObservers()
        {

        }

        public void SetStatusGame(StatusGame st)
        {
            statusGame = st;
        }
        public void Set_ii(bool _ii)
        {
            ii = _ii;
        }
        public void SetSizeCell(int size)
        {
            sizeCell = size;
        }
        public void SetSizeBoard(int size)
        {
            sizeBoard = size;
        }

        public int GetSizeCell()
        {
            return sizeCell;
        }
        public int GetSizeBoard()
        {
            return sizeBoard;
        }
    }
}
