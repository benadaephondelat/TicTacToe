namespace TicTacToe.Web.Models.HumanVsHuman.ViewModels
{
    using System.Collections.Generic;

    public class HumanVsHumanGameViewModel
    {
        public HumanVsHumanGameInfoModel GameInfo { get; set; }

        public IEnumerable<TileViewModel> GameTiles { get; set; }
    }
}