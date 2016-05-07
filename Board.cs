using System;
using System.Text;

namespace Connect_4_Bot
{
    public class Board : ICloneable
    {
        public int[][] _boardArray { get; set; }
        private int _mybotId;

        public void SetMyBotId(int myBotId)
        {
            _mybotId = myBotId;
        }

        public void Update(int[][] boardArray)
        {
            _boardArray = boardArray;
        }

        public int ColsNumber()
        {
            return _boardArray[0].Length;
        }

        private int RowsNumber()
        {
            return _boardArray.Length;
        }

        public FieldState State(int col, int row)
        {
            if (_boardArray[row][col] == 0) return FieldState.Free;
            if (_boardArray[row][col] == _mybotId) return FieldState.Me;
            return FieldState.Opponent;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < RowsNumber(); i++)
            {
                for (int j = 0; j < ColsNumber(); j++)
                {
                    sb.Append(_boardArray[i][j]).Append(" ");
                }
                sb.Append(Environment.NewLine);
            }
            return sb.ToString();
        }

        public void makeMove(int column)
        {
            this._boardArray[column] = this.addChip(this._boardArray[column]);
        }

        public object Clone()
        {
            Board n = new Board();

            n.Update(this._boardArray);

            return n;
        }

        private int[] addChip(int[] current)
        {
            if (current[current.Length - 1] != 0)
            {
                return current;
            }

            for (int x = 0; x < current.Length; x++)
            {
                if (x == current.Length - 1)
                {
                    current[current.Length - 1] = 1;
                    break;
                }
                else if (current[x] != 0)
                {
                    current[x - 1] = 1;
                    break;
                }
            }

            return current;
        }
    }
}