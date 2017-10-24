namespace TicTacToe.ServiceLayer.TicTacToeService.Factories.Game.Create.Helpers
{
    using System;
    using DataLayer.Data;
    using Models;
    using Models.Enums;

    public class CreateNewHumanVsComputerGameHelper : GameCreator
    {
        public CreateNewHumanVsComputerGameHelper(ITicTacToeData data) : base(data)
        {
        }

        public new Game CreateNewHumanVsComputerGame(string currentUserName, string computerUsername, bool isHumanStartingFirst)
        {
            ApplicationUser humanPlayer = base.GetUserByUsername(currentUserName);

            ApplicationUser computer = base.GetUserByUsername(computerUsername);

            Game game = new Game() { TurnsCount = 1 };

            this.AddUsersToGame(humanPlayer, computer, game, isHumanStartingFirst);

            this.AddInfoToGame(game.ApplicationUser.UserName, game.Oponent.UserName, game);

            base.AddEmptyTilesToGame(game);

            base.SaveChanges(game, currentUserName);

            return game;
        }

        /// <summary>
        /// Adds a Game's homeside and awayside users based on who is starting first
        /// </summary>
        /// <param name="humanPlayer">Human Player</param>
        /// <param name="computerPlayer">Computer Player</param>
        /// <param name="game">Game</param>
        /// <param name="isHumanFirst">Is the human player starting first</param>
        private void AddUsersToGame(ApplicationUser humanPlayer, ApplicationUser computerPlayer, Game game, bool isHumanFirst)
        {
            game.GameOwner = humanPlayer;
            game.GameOwner.Id = humanPlayer.Id;

            if (isHumanFirst)
            {
                game.ApplicationUser = humanPlayer;
                game.ApplicationUserId = humanPlayer.Id;

                game.Oponent = computerPlayer;
                game.OponentId = computerPlayer.Id;

                game.OponentName = computerPlayer.UserName;
                game.GameName = humanPlayer.UserName + " vs " + computerPlayer.UserName;
            }
            else
            {
                game.ApplicationUser = computerPlayer;
                game.ApplicationUserId = computerPlayer.Id;

                game.Oponent = humanPlayer;
                game.OponentId = humanPlayer.Id;

                game.OponentName = humanPlayer.UserName;
                game.GameName = computerPlayer.UserName + " vs " + humanPlayer.UserName;
            }
        }

        /// <summary>
        /// Sets game object's properties. GameMode, GameState, StartDate...
        /// </summary>
        private void AddInfoToGame(string homeSideUsername, string awaySideUsername, Game game)
        {
            game.GameMode = GameMode.HumanVsComputer;
            game.GameState = GameState.NotFinished;
            game.StartDate = DateTime.Now;
        }
    }
}