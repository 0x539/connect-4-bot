using System;
using System.Text;

namespace Connect_4_Bot
{
    public class Board : ICloneable
    {
        public int[][] BoardArray { get; set; }
        private int _mybotId;

        public int round {
            get
            {
                int count = 0;
                for (int x = 0; x < this.BoardArray.Length; x++)
                {
                    for (int y = 0; y < this.BoardArray[x].Length; y++)
                    {
                        if (this.BoardArray[x][y] != 0)
                        {
                            count++;
                        }
                    }
                }

                return count;
            }
        }

        public int GetMyBotId()
        {
            return this._mybotId;
        }

        public void SetMyBotId(int myBotId)
        {
            _mybotId = myBotId;
        }

        public void Update(int[][] boardArray)
        {
            BoardArray = boardArray;
        }

        public int ColsNumber()
        {
            return BoardArray[0].Length;
        }

        private int RowsNumber()
        {
            return BoardArray.Length;
        }

        public FieldState State(int col, int row)
        {
            if (BoardArray[row][col] == 0) return FieldState.Free;
            if (BoardArray[row][col] == _mybotId) return FieldState.Me;
            return FieldState.Opponent;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < RowsNumber(); i++)
            {
                for (int j = 0; j < ColsNumber(); j++)
                {
                    sb.Append(BoardArray[i][j]).Append(" ");
                }
                sb.Append(Environment.NewLine);
            }
            return sb.ToString();
        }

        public void MakeMove(int column, int player)
        {
            if (column > this.BoardArray.Length)
            {
                return;
            }

            int totalRows = this.RowsNumber();

            for (int x = totalRows - 1; x >= 0; x--)
            {
                int[] row = this.BoardArray[x];

                if (row[column] == 0)
                {
                    this.BoardArray[x][column] = player;
                    break;
                }
            }
        }

        public object Clone()
        {
            Board n = new Board();

            n.BoardArray = this.BoardArray;

            return n;
        }

        public bool IsTerminal(bool player)
        {
            return true;
        }

        public int GetTotalScore(bool player)
        {
            return player ? 100 : 0;
        }
    }
}