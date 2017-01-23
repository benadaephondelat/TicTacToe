namespace TicTacToe.ServiceLayer.TicTacToeService.Factories.Game.Update
{
    using System.Linq;
    using DataLayer.Data;
    using Helpers;
    using Models;
    using TicTacToeCommon.Exceptions.Game;

    public class GameUpdator : IGameUpdator
    {
        protected readonly ITicTacToeData data;

        public GameUpdator(ITicTacToeData data)
        {
            this.data = data;
        }

        public void CheckGameForOutcome(int gameId)
        {
            CheckGameForOutcomeHelper checkGameForOutcomeHelper = new CheckGameForOutcomeHelper(this.data);

            checkGameForOutcomeHelper.CheckGameForOutcome(gameId);
        }

        public void PlaceTurn(int gameId, int tileIndex, string currentUserName)
        {
            PlaceTurnHelper placeTurnHelper = new PlaceTurnHelper(this.data);

            placeTurnHelper.PlaceTurn(gameId, tileIndex, currentUserName);
        }

        /// <summary>
        /// Returns a game by id or throws exception
        /// </summary>
        /// <param name="gameId"></param>
        /// <exception cref="GameNotFoundException"></exception>
        /// <returns>Game</returns>
        protected Game GetGameById(int gameId)
        {
            Game game = this.data.Games.All().FirstOrDefault(g => g.Id == gameId);

            if (game == null)
            {
                throw new GameNotFoundException();
            }

            return game;
        }
    }
}