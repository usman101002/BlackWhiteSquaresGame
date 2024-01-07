using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackWhiteSquaresGame
{
    public class GameModel
    {
        private bool[,] game;
        public readonly int Size;
        public event Action<int, int, bool> StateChanged;

        public GameModel(int size)
        {
            Size = size;
            game = new bool[size, size];
        }

        public void Start()
        {
            for (int row = 0; row < Size; row++)
            for (int column = 0; column < Size; column++)
                SetState(row, column, (row + column) % 2 == 0);
        }

        public void SetState(int row, int column, bool state)
        {
            game[row, column] = state;
            if (StateChanged != null) StateChanged(row, column, game[row, column]);
        }

        public void FlipState(int row, int column)
        {
            SetState(row, column, !game[row, column]);
        }

        public void Flip(int row, int column)
        {
            for (int iRow = 0; iRow < Size; iRow++)
                if (iRow != row) FlipState(iRow, column);
            for (int iColumn = 0; iColumn < Size; iColumn++)
                if (iColumn != column) FlipState(row, iColumn);
            FlipState(row, column);
        }
    }
}
