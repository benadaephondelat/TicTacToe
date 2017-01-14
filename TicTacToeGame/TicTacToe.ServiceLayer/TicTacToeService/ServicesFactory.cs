namespace TicTacToe.ServiceLayer.TicTacToeService
{
    using Factories.Game;
    using DataLayer.Data;

    /// <summary>
    /// Provides CRUD factories for all repositories 
    /// </summary>
    public class ServicesFactory : IServicesFactory
    {
        private readonly ITicTacToeData data;

        public ServicesFactory(ITicTacToeData data)
        {
            this.data = data;
        }

        /// <summary>
        /// Returns Game Repository CRUD operations Factory 
        /// </summary>
        /// <returns>GameFactory</returns>
        public IGameFactory GetGameFactory()
        {
            return new GameFactory(this.data);
        } 
    }
}