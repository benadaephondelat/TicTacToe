namespace TicTacToe.ServiceLayer.TicTacToeService.Factories.Game.Create.Helpers
{
    using System;
    using DataLayer.Data;
    using Models;
    using Models.Enums;

    public class CreateNewComputerVsComputerHelper : GameCreator
    {
        public CreateNewComputerVsComputerHelper(ITicTacToeData data) : base(data)
        {
        }

        public new Game CreateNewComputerVsComputerGame(string currentUserName, string startingFirstComputerName, string startingSecondComputerName)
        {
            ApplicationUser humanPlayer = base.GetUserByUsername(currentUserName);

            ApplicationUser computer = base.GetUserByUsername(startingFirstComputerName);

            ApplicationUser secondComputer = base.GetUserByUsername(startingSecondComputerName);

            Game game = new Game() { TurnsCount = 1 };

            this.AddUsersToGame(humanPlayer, computer, secondComputer, game);

            this.AddInfoToGame(game);

            base.AddEmptyTilesToGame(game);

            base.SaveChanges(game, currentUserName);

            return game;
        }

        /// <summary>
        /// Adds a Game's homeside and awayside users 
        /// </summary>
        /// <param name="gameOwner">Human player</param>
        /// <param name="computer">The first computer</param>
        /// <param name="secondComputer">The second computer</param>
        /// <param name="game">Game</param>
        private void AddUsersToGame(ApplicationUser gameOwner, ApplicationUser computer, ApplicationUser secondComputer, Game game)
        {
            game.GameOwner = gameOwner;
            game.GameOwnerId = gameOwner.Id;

            game.ApplicationUser = computer;
            game.ApplicationUserId = computer.Id;

            game.Oponent = secondComputer;
            game.OponentId = secondComputer.Id;

            game.OponentName = secondComputer.UserName;
            game.GameName = computer.UserName + " vs " + secondComputer.UserName;
        }

        /// <summary>
        /// Sets game object's properties. GameMode, GameState, StartDate...
        /// </summary>
        private void AddInfoToGame(Game game)
        {
            game.GameMode = GameMode.ComputerVsComputer;
            game.GameState = GameState.NotFinished;
            game.StartDate = DateTime.Now;
        }
    }
}