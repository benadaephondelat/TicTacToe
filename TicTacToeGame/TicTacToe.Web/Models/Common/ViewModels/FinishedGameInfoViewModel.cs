namespace TicTacToe.Web.Models.Common.ViewModels
{
    using System;
    using TicTacToe.Models;
    using TicTacToe.Models.Enums;
    using FrameworkExtentions.Mappings;
    using AutoMapper;

    public class FinishedGameInfoViewModel : IMapFrom<Game>, IHaveCustomMappings
    {
        public string HomeSideUserId { get; set; }

        public string HomeSideUserName { get; set; }

        public string AwaySideUserId { get; set; }

        public string AwaySideUserName { get; set; }

        public string WinnerId { get; set; }

        public string GameName { get; set; }

        public GameState GameState { get; set; }

        public DateTime StartDate { get; set; }

        public TimeSpan GameDuration { get; set; }

        public int TurnsCount { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Game, FinishedGameInfoViewModel>()
                         .ForMember(vm => vm.HomeSideUserName, opt => opt.MapFrom(s => s.ApplicationUser.UserName))
                         .ForMember(vm => vm.HomeSideUserId, opt => opt.MapFrom(s => s.ApplicationUserId))
                         .ForMember(vm => vm.AwaySideUserId, opt => opt.MapFrom(s => s.OponentId))
                         .ForMember(vm => vm.AwaySideUserName, opt => opt.MapFrom(s => s.Oponent.UserName))
                         .ForMember(vm => vm.GameDuration, opt => opt.MapFrom(s => s.EndDate - s.StartDate));
        }
    }
}