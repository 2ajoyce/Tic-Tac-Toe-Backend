namespace TicTacToe
{
    public class Move
    {
        public char Player;
        public int Position;

        public Move(char player, int position)
        {
            Player = player;
            Position = position;
        }
    }
}