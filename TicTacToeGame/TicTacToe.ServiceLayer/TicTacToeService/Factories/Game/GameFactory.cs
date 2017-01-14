namespace TicTacToe.ServiceLayer.TicTacToeService.Factories.Game
{
    using CRUD;
    using DataLayer.Data;

    /// <summary>
    /// Game Repository CRUD operations factory
    /// </summary>
    public class GameFactory : IGameFactory
    {
        private readonly ITicTacToeData data;

        public GameFactory(ITicTacToeData data)
        {
            this.data = data;
        }

        /// <summary>
        /// Contains methods for CREATE operations on the Game class
        /// </summary>
        /// <returns>GameCreator</returns>
        public IGameCreator GetGameCreatorHelper()
        {
            return new GameCreator(this.data);
        }

        /// <summary>
        /// Contains methods for READ operations on the Game class
        /// </summary>
        /// <returns>GameReader</returns>
        public IGameReader GetGameReaderHelper()
        {
            return new GameReader(this.data);
        }

        /// <summary>
        /// Contains methods for UPDATE operations on the Game class
        /// </summary>
        /// <returns>GameUpdator</returns>
        public IGameUpdator GetGameUpdatorHelper()
        {
            return new GameUpdator(this.data);
        }
    }
}