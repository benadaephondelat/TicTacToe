namespace TicTacToe.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Enums;

    public class Game
    {
        private ICollection<Tile> tiles;

        public Game()
        {
            this.Tiles = new HashSet<Tile>();
        }

        [Key]
        public int Id { get; set; }

        [Obsolete("Change to HomeSideUserId")]
        public string ApplicationUserId { get; set; }

        [Obsolete("Change to HomeSideUser")]
        [ForeignKey("ApplicationUserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

        [Obsolete("Change to AwaySideUserId")]
        public string OponentId { get; set; }

        [Obsolete("Change to AwaySideUser")]
        [ForeignKey("OponentId")]
        public virtual ApplicationUser Oponent { get; set; }

        public string OponentName { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int? TurnsCount { get; set; }

        public bool IsFinished { get; set; }

        public string WinnerId { get; set; }

        public string GameName { get; set; }

        public GameMode GameMode { get; set; }

        public GameState GameState { get; set; }

        public virtual ICollection<Tile> Tiles
        {
            get
            {
                return this.tiles;
            }

            set
            {
                this.tiles = value;
            }
        }
    }
}