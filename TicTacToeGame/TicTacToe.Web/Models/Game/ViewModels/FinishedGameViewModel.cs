namespace TicTacToe.Web.Models.Game.ViewModels
{
    using System.Collections.Generic;
    using Tiles.ViewModels;

    public class FinishedGameViewModel
    {
        public FinishedGameInfoViewModel GameInfo { get; set; }
        
        public IEnumerable<TileViewModel> GameTiles { get; set; }
    }
}