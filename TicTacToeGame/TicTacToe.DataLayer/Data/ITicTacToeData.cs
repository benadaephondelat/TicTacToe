using System;
using System.Threading.Tasks;

using TicTacToe.Models;
using TicTacToe.DataLayer.Repository;

namespace TicTacToe.DataLayer.Data
{
    public interface ITicTacToeData
    {
        IGenericRepository<ApplicationUser> Users { get; }

        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}