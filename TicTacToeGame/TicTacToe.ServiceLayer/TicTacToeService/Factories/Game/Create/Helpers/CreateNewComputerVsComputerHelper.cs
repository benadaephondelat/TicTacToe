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

        public new Game CreateNewComputerVsComputerGame(string currentUserName)
        {
            ApplicationUser humanPlayer = base.GetUserByUsername(currentUserName);

            ApplicationUser computer = base.GetUserByUsername("computer@yahoo.com");

            Game game = new Game() { TurnsCount = 1 };

            this.AddUsersToGame(humanPlayer, computer, game);

            this.AddInfoToGame(game.ApplicationUser.UserName, game.Oponent.UserName, game);

            base.AddEmptyTilesToGame(game);

            base.SaveChanges(game, currentUserName);

            return game;
        }

        /// <summary>
        /// Adds a Game's homeside and awayside users 
        /// </summary>
        /// <param name="humanPlayer">Human Player</param>
        /// <param name="computerPlayer">Computer Player</param>
        /// <param name="game">Game</param>
        private void AddUsersToGame(ApplicationUser humanPlayer, ApplicationUser computerPlayer, Game game)
        {
            game.ApplicationUser = humanPlayer;
            game.ApplicationUserId = humanPlayer.Id;

            game.Oponent = computerPlayer;
            game.OponentId = computerPlayer.Id;

            game.OponentName = computerPlayer.UserName;
            game.GameName = humanPlayer.UserName + " vs " + computerPlayer.UserName;
        }

        /// <summary>
        /// Sets game object's properties. GameMode, GameState, StartDate...
        /// </summary>
        private void AddInfoToGame(string homeSideUsername, string awaySideUsername, Game game)
        {
            game.GameMode = GameMode.ComputerVsComputer;
            game.GameState = GameState.NotFinished;
            game.StartDate = DateTime.Now;
        }
    }
}