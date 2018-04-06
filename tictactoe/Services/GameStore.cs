using System;
using System.Collections.Generic;
using TicTacToe.Models;

namespace TicTacToe.Services
{
    public class GameStore
    {
        private List<Game> games;

        public GameStore()
        {
            games = new List<Game>();
        }

        public Game Start(char player)
        {
            Prune();
            Game game = new Game(player);
            games.Add(game);
            return game;
        }

        public Game JoinGame(string id, char player) {
            Prune();
            Game game = games.Find(x => x.id == id);
            if (game != null && game.JoinGame(player)) { return game; }
            return null;
        }

        public Game JoinGame(char player) {
            Prune();
            Game game = games.Find(x => x.SecondPlayer == '-');
            if (game == null) { return null; } 
            return JoinGame(game.id, player);
        }

        public int Get()
        {
            Prune();
            return games.Count;
        }

        public Game Get(string id)
        {
            Prune();
            return games.Find(x => x.id == id);
        }

        public bool Update(string id, Move move)
        {
            Prune();
            Game game = games.Find(x => x.id == id);
            if (game == null) { return false; }
            return game.Move(move);
        }

        public void Remove(string id)
        {
            games.Remove(games.Find(x => x.id == id));
        }

        public void Remove(Game game)
        {
            games.Remove(game);
        }

        public void Prune()
        {
            Game game;
            for (int i=0; i<games.Count; i++) {
                game = games[i];
                if (games[i].LastMoveOn.AddMinutes(30).CompareTo(DateTime.Now) < 0) {
                    Remove(game);
                }
            }
        }
    }
}