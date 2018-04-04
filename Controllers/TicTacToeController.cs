using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace TicTacToe.Controllers
{
    [Route("api/[controller]")]
    public class GamesController : Controller
    {
        private GameStore _GameStore { get; }

        public GamesController(
            GameStore gameStore
        )
        {
            _GameStore = gameStore;
        }

        // GET api/games
        [HttpGet]
        public int Get()
        {
            return _GameStore.Get();
        }

        // POST api/games
        [HttpPost]
        public string Post([FromBody] _gameJson request)
        {
            return Serialize(_GameStore.Get(request.id));
        }

        // POST api/games/start
        [HttpPost("start")]
        public string Start([FromBody] _playerJson request)
        {
            return Serialize(_GameStore.Start(request.player));
        }

        // POST api/games/join
        [HttpPost("join")]
        public string Join([FromBody] _playerJson request)
        {
            Game game;
            if (request.id != null)
            {
                game = _GameStore.JoinGame(request.id, request.player);
            }
            else
            {
                game = _GameStore.JoinGame(request.player);
            }
            return Serialize(game);
        }

        // POST api/games/move/5
        [HttpPost("move")]
        public bool Post([FromBody] _moveJson moveJson)
        {
            return _GameStore.Update(moveJson.id, moveJson.move);
        }

        private string Serialize(Object o)
        {
            return JsonConvert.SerializeObject(o);
        }

        private Object Deserialize(string s)
        {
            return JsonConvert.DeserializeObject(s);
        }

        public class _gameJson
        {
            public string id { get; set; }
        }

        public class _playerJson
        {
            public string id { get; set; }
            public char player { get; set; }
        }

        public class _moveJson
        {
            public string id { get; set; }
            public Move move { get; set; }
        }
    }
}
