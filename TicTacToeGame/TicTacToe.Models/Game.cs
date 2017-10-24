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

        public string ApplicationUserId { get; set; }

        [ForeignKey("ApplicationUserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

        public string OponentId { get; set; }

        [ForeignKey("OponentId")]
        public virtual ApplicationUser Oponent { get; set; }

        public string GameOwnerId { get; set; }

        [ForeignKey("GameOwnerId")]
        public virtual ApplicationUser GameOwner { get; set; }

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