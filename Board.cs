using System;
using System.Text;

namespace Connect_4_Bot
{
    public class Board
    {
        public int[][] _boardArray { get; set; }
        private int _mybotId;

        public int round {
            get
            {
                int count = 0;
                for (int x = 0; x < this._boardArray.Length; x++)
                {
                    for (int y = 0; y < this._boardArray[x].Length; y++)
                    {
                        if (this._boardArray[x][y] != 0)
                        {
                            count++;
                        }
                    }
                }

                return count;
            }
        }

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

        public void MakeMove(int column, int player)
        {
            if (column > this._boardArray.Length)
            {
                return;
            }

            int totalRows = this.RowsNumber();

            for (int x = totalRows - 1; x >= 0; x--)
            {
                int[] row = this._boardArray[x];

                if (row[column] == 0)
                {
                    this._boardArray[x][column] = player;
                    break;
                }
            }
        }
    }
}