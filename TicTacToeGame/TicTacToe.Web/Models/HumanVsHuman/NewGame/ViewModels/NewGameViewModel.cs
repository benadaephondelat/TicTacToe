namespace TicTacToe.Web.Models.HumanVsHuman.NewGame.ViewModels
{
    using System;
    using TicTacToe.Models;
    using FrameworkExtentions.Mappings;
    using AutoMapper;

    public class NewGameInfoModel : IMapFrom<Game>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public ApplicationUser HomeSideUser { get; set; }

        public ApplicationUser AwaySideUser { get; set; }

        public int TurnsCount { get; set; }

        public string CurrentTurnHolderId { get; set; }
        
        public string GameName { get; set; }

        public DateTime StartDate { get; set; }

        public bool IsFinished { get; set; }

        public string WinnerName { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Game, NewGameInfoModel>()
                         .ForMember(vm => vm.HomeSideUser, opt => opt.MapFrom(s => s.ApplicationUser))
                         .ForMember(vm => vm.AwaySideUser, opt => opt.MapFrom(s => s.Oponent))
                         .ForMember(vm => vm.CurrentTurnHolderId, opt => opt.MapFrom(s => CalculateTurnHolderId(s.TurnsCount ?? 1, s.ApplicationUser.Id, s.Oponent.Id)));
        }

        /// <summary>
        /// If turns count is odd number then is the homeside user's turn
        /// else it is the awayside's turn
        /// </summary>
        /// <param name="turnsCount">the current turn count</param>
        /// <param name="homeUserId">id of the homeside user</param>
        /// <param name="awayUserId">id of the awayside user</param>
        /// <returns>string</returns>
        public string CalculateTurnHolderId(int turnsCount, string homeUserId, string awayUserId)
        {
            if (IsOddNumber(turnsCount))
            {
                return homeUserId;
            }

            return awayUserId;
        }

        /// <summary>
        /// Checks if a given integer number is odd.
        /// </summary>
        /// <returns>bool</returns>
        private bool IsOddNumber(int turnsCount)
        {
            return turnsCount % 2 != 0;
        }
    }
}