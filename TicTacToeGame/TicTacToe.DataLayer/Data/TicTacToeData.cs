namespace TicTacToe.DataLayer.Data
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;
    using Repository;

    public class TicTacToeData : ITicTacToeData
    {
        private readonly IApplicationDbContext context;
        private readonly IDictionary<Type, object> repositories;

        public TicTacToeData(IApplicationDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IGenericRepository<Game> Games
        {
            get { return GetRepository<Game>(); }
        }
        public IGenericRepository<Tile> Tiles
        {
            get { return GetRepository<Tile>(); }
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