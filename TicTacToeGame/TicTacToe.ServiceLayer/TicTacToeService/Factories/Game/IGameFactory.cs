namespace TicTacToe.ServiceLayer.TicTacToeService.Factories.Game
{
    using Create;
    using Read;
    using Update;

    /// <summary>
    /// Game Repository CRUD operations Factory
    /// </summary>
    public interface IGameFactory
    {
        /// <summary>
        /// Game repository CREATE operations helper
        /// </summary>
        /// <returns>IGameCreator</returns>
        IGameCreator GetGameCreatorHelper();

        /// <summary>
        /// Game repository READ operations helper
        /// </summary>
        /// <returns>IGameReader</returns>
        IGameReader GetGameReaderHelper();

        /// <summary>
        /// Game repository UPDATE operations helper
        /// </summary>
        /// <returns>IGameUpdator</returns>
        IGameUpdator GetGameUpdatorHelper();
    }
}