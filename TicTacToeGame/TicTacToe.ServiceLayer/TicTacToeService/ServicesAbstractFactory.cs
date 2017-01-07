namespace TicTacToe.ServiceLayer.TicTacToeService
{
    using Factories.Game;
    using DataLayer.Data;

    /// <summary>
    /// Provides CRUD factories for all repositories 
    /// </summary>
    public class ServicesAbstractFactory : IServicesAbstractFactory
    {
        private readonly ITicTacToeData data;

        public ServicesAbstractFactory(ITicTacToeData data)
        {
            this.data = data;
        }

        /// <summary>
        /// Returns Game CRUD factory 
        /// </summary>
        /// <returns>GameFactory</returns>
        public GameFactory GetGameFactory()
        {
            return new GameFactory(this.data);
        } 
    }
}