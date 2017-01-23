namespace TicTacToe.ServiceLayer.TicTacToeService.Factories.Game.Read
{
    using System.Linq;
    using Models;
    using DataLayer.Data;
    using TicTacToeCommon.Exceptions.Game;

    public class GameReader : IGameReader
    {
        private readonly ITicTacToeData data;

        public GameReader(ITicTacToeData data)
        {
            this.data = data;
        }

        public Game GetGameById(int gameId)
        {
            Game game = this.data.Games.All().FirstOrDefault(g => g.Id == gameId);

            if (game == null)
            {
                throw new GameNotFoundException();
            }

            return game;
        }

        public bool IsGameFinished(int gameId)
        {
            Game game = this.data.Games.All().FirstOrDefault(g => g.Id == gameId);

            if (game == null)
            {
                throw new GameNotFoundException();
            }

            return game.IsFinished;
        }
    }
}