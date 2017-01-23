namespace TicTacToe.Web.Models.HumanVsHuman.ViewModels
{
    using System.Collections.Generic;

    public class FinishedGameViewModel
    {
        public FinishedGameInfoViewModel GameInfo { get; set; }
        
        public IEnumerable<TileViewModel> GameTiles { get; set; }
    }
}