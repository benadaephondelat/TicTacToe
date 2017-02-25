namespace TicTacToe.Web.Models.HumanVsHuman.ViewModels
{
    using System.Collections.Generic;

    public class GameViewModel
    {
        public GameInfoViewModel GameInfo { get; set; }

        public IEnumerable<TileViewModel> GameTiles { get; set; }
    }
}