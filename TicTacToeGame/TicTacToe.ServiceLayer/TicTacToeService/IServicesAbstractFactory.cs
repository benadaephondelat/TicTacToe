namespace TicTacToe.ServiceLayer.TicTacToeService
{
    using Factories.Game;

    /// <summary>
    /// Abstract Factory Interface containing all CRUD Factories
    /// </summary>
    public interface IServicesAbstractFactory
    {
        GameFactory GetGameFactory();
    }
}