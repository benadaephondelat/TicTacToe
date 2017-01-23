﻿namespace TicTacToe.Web.Models.Game.ViewModels
{
    using System.Collections.Generic;
    using Tiles.ViewModels;

    public class HumanVsHumanGameViewModel
    {
        public HumanVsHumanGameInfoModel GameInfo { get; set; }

        public IEnumerable<TileViewModel> GameTiles { get; set; }
    }
}