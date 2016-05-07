using System;

namespace Connect_4_Bot
{
    public interface IStrategy
    {
        int NextMove(Board board);
    }

    public class Strategy : IStrategy
    {
        private int _playerId;
        private AlphaBeta algorithm;

        public Strategy()
        {
            this.algorithm = new AlphaBeta();
        }

        public int NextMove(Board board)
        {
            this._playerId = board.GetMyBotId();

            return board.round % 7;
        }

        private double EvaluateBoard(Board board)
        {
            return 23.45989;
        }
    }

}