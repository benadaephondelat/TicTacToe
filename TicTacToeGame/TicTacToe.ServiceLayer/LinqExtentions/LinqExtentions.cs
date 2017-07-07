namespace TicTacToe.ServiceLayer.LinqExtentions
{
    using System.Collections.Generic;
    using System.Linq;
    using Models;

    public static class LinqExtentions
    {
        /// <summary>
        /// Returns the last finished game
        /// </summary>
        /// <param name="source">List of games</param>
        /// <returns>Game</returns>
        public static Game GetLastFinishedGame(this IEnumerable<Game> source)
        {
            return source.Where(g => g.IsFinished).OrderByDescending(g => g.EndDate).FirstOrDefault();
        }
    }
}