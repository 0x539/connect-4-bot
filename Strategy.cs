using System;

namespace Connect_4_Bot
{
    public interface IStrategy
    {
        int NextMove(Board board);
    }

    public class Strategy : IStrategy
    {
        public int round;

        public int NextMove(Board board)
        {
            if (round > board.ColsNumber() - 1)
            {
                round = 0;
            }

            return round++;
        }
    }

}