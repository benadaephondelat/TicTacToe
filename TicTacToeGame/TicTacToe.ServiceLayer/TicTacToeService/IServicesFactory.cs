namespace TicTacToe.ServiceLayer.TicTacToeService
{
    using Factories.Game;

    /// <summary>
    /// Interface containing all repositories's CRUD operations factories
    /// </summary>
    public interface IServicesFactory
    {
        /// <summary>
        /// Returns a factory containing Game Repository CRUD operations helpers  
        /// </summary>
        /// <returns>IGameFactory</returns>
        IGameFactory GetGameFactory();
    }
}