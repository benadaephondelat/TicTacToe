namespace TicTacToe.ServiceLayer.TicTacToeService.Factories.Game
{
    using CRUD;
    using DataLayer.Data;

    /// <summary>
    /// Game CRUD operations factory
    /// </summary>
    public class GameFactory
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
        public GameCreator GetGameCreatorHelper()
        {
            return new GameCreator(this.data);
        }
    }
}