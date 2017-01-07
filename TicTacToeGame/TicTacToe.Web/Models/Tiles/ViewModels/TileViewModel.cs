﻿namespace TicTacToe.Web.Models.Tiles.ViewModels
{
    using TicTacToe.Models;
    using FrameworkExtentions.Mappings;

    public class TileViewModel : IMapFrom<Tile>
    {
        public int Id { get; set; }

        public bool IsEmpty { get; set; }

        public string Value { get; set; }
    }
}