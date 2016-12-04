using System.Threading.Tasks;

namespace TicTacToe.DataLayer
{
    public interface IApplicationDbContext
    {
        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}