namespace TicTacToe.DataLayer
{
    using System.Data.Entity;
    using System.Threading.Tasks;
    using Models;

    public interface IApplicationDbContext
    {
        IDbSet<Game> Games { get; set; }

        IDbSet<Tile> Tiles { get; set; }

        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}