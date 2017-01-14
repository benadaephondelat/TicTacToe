namespace TicTacToe.Web.Models.Game.ViewModels
{
    using System.Collections.Generic;
    using Tiles.ViewModels;
    using HumanVsHuman.NewGame.ViewModels;

    public class HumanVsHumanGameViewModel
    {
        public HumanVsHumanGameInfoModel GameInfo { get; set; }

        public IEnumerable<TileViewModel> GameTiles { get; set; }
    }
}