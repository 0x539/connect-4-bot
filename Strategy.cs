using System;

namespace Connect_4_Bot
{
    public interface IStrategy
    {
        int NextMove(Board board);
    }

    public class Strategy : IStrategy
    {
        public int move;

        public int NextMove(Board board)
        {
            if (move > board.ColsNumber() - 1)
            {
                move = 0;
            }

            return move++;
        }
    }

}