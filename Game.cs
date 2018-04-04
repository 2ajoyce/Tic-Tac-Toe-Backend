using System;

namespace TicTacToe
{
    public class Game
    {
        public string id;
        public char[] Board;
        public DateTime LastMoveOn;
        public char FirstPlayer;
        public char SecondPlayer;
        public char Winner;

        public Game(char player)
        {
            id = Guid.NewGuid().ToString();
            Board = new char[9];
            for (int i = 0; i < 9; i++)
            {
                Board.SetValue('-', i);
            }
            LastMoveOn = DateTime.Now;
            FirstPlayer = player;
            SecondPlayer = '-';
            Winner = '-';
        }

        public bool JoinGame(char player) {
            if(SecondPlayer != '-') { return false; }
            SecondPlayer = player;
            return true;
        }

        public bool Move(Move move)
        {
            char player = move.Player;
            int position = move.Position;

            if (getWinner() != '-') { return false; }
            if (!isValidPlayer(player)) { return false; }
            if (!isMyTurn(player)) { return false; }
            if (!isValidMove(position)) { return false; }
            Board[position] = player;
            LastMoveOn = DateTime.Now;
            Winner = getWinner();
            return true;
        }

        private char getWinner()
        {
            // Horizontal Rows
            if (Board[0] == Board[1] && Board[0] == Board[2] && Board[0] != '-') { return Board[0]; }
            if (Board[3] == Board[4] && Board[3] == Board[5] && Board[3] != '-') { return Board[3]; }
            if (Board[6] == Board[7] && Board[6] == Board[8] && Board[6] != '-') { return Board[6]; }

            // Vertical Rows
            if (Board[0] == Board[3] && Board[0] == Board[6] && Board[0] != '-') { return Board[0]; }
            if (Board[1] == Board[4] && Board[1] == Board[7] && Board[1] != '-') { return Board[1]; }
            if (Board[2] == Board[5] && Board[2] == Board[8] && Board[2] != '-') { return Board[2]; }

            // Diagonal Rows
            if (Board[0] == Board[4] && Board[0] == Board[8] && Board[0] != '-') { return Board[0]; }
            if (Board[2] == Board[4] && Board[2] == Board[6] && Board[2] != '-') { return Board[2]; }

            return '-';
        }

        private bool isMyTurn(char player) {
            int first = 0;
            int second = 0;
            for (int i=0; i<Board.Length; i++) {
                if(Board[i] == FirstPlayer) { first++; }
                else if (Board[i] == SecondPlayer) { second++; }
            }
            return (player == FirstPlayer && first <= second) || (player == SecondPlayer && first > second);
        }

        private bool isValidPlayer(char player)
        {
            return player == FirstPlayer || player == SecondPlayer;
        }

        private bool isValidMove(int position)
        {
            if (!isValidLocation(position)) { return false; }
            if (!IsEmptyLocation(position)) { return false; }
            return true;
        }

        private bool isValidLocation(int position)
        {
            if (position >= 0 && position <= 8) { return true; }
            return false;
        }

        private bool IsEmptyLocation(int position)
        {
            if (Board[position] == '-') { return true; }
            return false;
        }
    }
}