namespace TicTacToe.ServiceLayer.TicTacToeService.Factories.Game.Read
{
    using System.Linq;
    using System.Collections.Generic;
    using Models;
    using Models.Enums;
    using DataLayer.Data;
    using TicTacToeCommon.Exceptions.Game;
    using TicTacToeCommon.Exceptions.User;

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

        public IEnumerable<Game> GetAllUnfinishedGames(string currentUsername, GameMode gameMode)
        {
            ApplicationUser user = this.data.Users.All().FirstOrDefault(u => u.UserName == currentUsername);

            if (user == null)
            {
                throw new UserNotFoundException();
            }

            IEnumerable<Game> unfinishedGames = user.Games.Where(g => g.IsFinished == false && g.GameMode == gameMode);

            return unfinishedGames;
        }
    }
}