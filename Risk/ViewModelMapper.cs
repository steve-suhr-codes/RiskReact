using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Risk.ViewModels;

namespace Risk
{
    public static class ViewModelMapper
    {
        public static RiskBoardViewModel RiskBoardViewModel(Game game)
        {
            if (game == null) return null;

            var result = new RiskBoardViewModel
            {
                Countries = game.Table.Board.Countries.Select(x => new CountryViewModel
                {
                    Name = x.Value.Name,
                    Continent = x.Value.Continent,
                    OccupyingArmyCount = x.Value.OccupyingArmyCount,
                    OccupyingPlayerName = x.Value.OccupyingPlayer?.Name,
                    OccupyingPlayerColor = x.Value.OccupyingPlayer?.Color ?? PlayerColor.None
                }).ToList()
            };
            return result;
        }
    }
}
