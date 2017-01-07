namespace TicTacToe.Web.Models.Game.ViewModels
{
    using System.Collections.Generic;
    using Tiles.ViewModels;
    using HumanVsHuman.NewGame.ViewModels;

    public class NewGameViewModel
    {
        public NewGameInfoModel GameInfo { get; set; }

        public IEnumerable<TileViewModel> GameTiles { get; set; }
    }
}