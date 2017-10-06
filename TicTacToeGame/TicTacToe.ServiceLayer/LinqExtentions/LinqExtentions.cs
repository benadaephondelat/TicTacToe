namespace TicTacToe.ServiceLayer.LinqExtentions
{
    using System.Collections.Generic;
    using System.Linq;
    using Models;
    using Models.Enums;

    public static class LinqExtentions
    {
        /// <summary>
        /// Returns the last finished game
        /// </summary>
        /// <param name="source">List of games</param>
        /// <returns>Game</returns>
        public static Game GetLastFinishedGame(this IEnumerable<Game> source, GameMode gameMode)
        {
            Game result = source.Where(g => g.IsFinished && g.GameMode == gameMode)
                                .OrderByDescending(g => g.EndDate)
                                .FirstOrDefault();

            return result;
        }
    }
}