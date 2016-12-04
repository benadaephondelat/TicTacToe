using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using TicTacToe.Models;
using TicTacToe.DataLayer.Repository;

namespace TicTacToe.DataLayer.Data
{
    public class TicTacToeData : ITicTacToeData
    {
        private readonly IApplicationDbContext context;
        private readonly IDictionary<Type, object> repositories;

        public TicTacToeData(IApplicationDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IGenericRepository<ApplicationUser> Users
        {
            get { return GetRepository<ApplicationUser>(); }
        }

        public int SaveChanges()
        {
            return context.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return context.SaveChangesAsync();
        }

        private IGenericRepository<T> GetRepository<T>() where T : class
        {
            var type = typeof(T);

            if (repositories.ContainsKey(type))
            {
                return (IGenericRepository<T>)repositories[type];
            }

            Type typeOfRepository = typeof(GenericRepository<T>);

            object repository = Activator.CreateInstance(typeOfRepository, context);

            repositories.Add(type, repository);

            return (IGenericRepository<T>)repositories[type];
        }
    }
}