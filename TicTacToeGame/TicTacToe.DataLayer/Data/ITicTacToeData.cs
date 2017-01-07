namespace TicTacToe.DataLayer.Data
{
    using System.Threading.Tasks;
    using Models;
    using Repository;

    public interface ITicTacToeData
    {
        IGenericRepository<Game> Games { get; }

        IGenericRepository<Tile> Tiles { get; }

        IGenericRepository<ApplicationUser> Users { get; }

        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}