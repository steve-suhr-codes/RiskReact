using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Risk;
using Risk.Models;
using Risk.Services;
using Risk.ViewModels;

namespace RiskReact.Controllers
{
    [Route("api/[controller]")]
    public class RiskController : Controller
    {
        private const string CacheKey = "RiskGame";
        private IMemoryCache _cache { get; set; }

        public RiskController(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
        }

        [HttpGet("[action]")]
        public RiskBoardViewModel StartGame()
        {
            var game = new Game(new RiskBoardCreator(), new RiskArmyDelegator());
            game.StartGame();

            _cache.Set(CacheKey, game);

            var vm = ViewModelMapper.RiskBoardViewModel(game);
            return vm;
        }

        [HttpGet("[action]")]
        public RiskBoardViewModel Play()
        {
            var game = _cache.Get<Game>(CacheKey);
            
            if (game.GamePhase == GamePhase.Claim || game.GamePhase == GamePhase.Place)
                game.FastForwardCurrentPhase();
            else
                game.PlayTurn();

            _cache.Set("RiskGame", game);

            var vm = ViewModelMapper.RiskBoardViewModel(game);
            return vm;
        }

    }
}
