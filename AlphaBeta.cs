using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Connect_4_Bot
{
    class AlphaBeta
    {
        bool MaxPlayer = true;

        public int Iterate(Board board, int depth, int alpha, int beta, bool player)
        {
            if (depth == 0 || board.IsTerminal(player))
            {
                return board.GetTotalScore(Player);
            }


            return 0;
        }
    }
}
