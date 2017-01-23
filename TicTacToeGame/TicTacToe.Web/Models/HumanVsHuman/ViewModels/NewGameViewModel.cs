namespace TicTacToe.Web.Models.HumanVsHuman.ViewModels
{
    using System;
    using TicTacToe.Models;
    using FrameworkExtentions.Mappings;
    using AutoMapper;

    public class HumanVsHumanGameInfoModel : IMapFrom<Game>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string HomeSideUserId { get; set; }

        public string HomeSideUserName { get; set; }

        public string AwaySideUserId { get; set; }

        public string AwaySideUserName { get; set; }

        public int TurnsCount { get; set; }

        public string CurrentTurnHolderId { get; set; }
        
        public string GameName { get; set; }

        public DateTime StartDate { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Game, HumanVsHumanGameInfoModel>()
                         .ForMember(vm => vm.HomeSideUserName, opt => opt.MapFrom(s => s.ApplicationUser.UserName))
                         .ForMember(vm => vm.HomeSideUserId, opt => opt.MapFrom(s => s.ApplicationUserId))
                         .ForMember(vm => vm.AwaySideUserId, opt => opt.MapFrom(s => s.OponentId))
                         .ForMember(vm => vm.AwaySideUserName, opt => opt.MapFrom(s => s.Oponent.UserName))
                         .ForMember(vm => vm.CurrentTurnHolderId, opt => opt.MapFrom(s => this.GetCurrentTurnHolderId(s.TurnsCount ?? 1, s.ApplicationUser.Id, s.Oponent.Id)));
        }

        /// <summary>
        /// If turns count is odd number then it's the homeside user's turn
        /// </summary>
        /// <param name="turnsCount">the current turn count</param>
        /// <param name="homeUserId">id of the homeside user</param>
        /// <param name="awayUserId">id of the awayside user</param>
        /// <returns>string</returns>
        public string GetCurrentTurnHolderId(int turnsCount, string homeUserId, string awayUserId)
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