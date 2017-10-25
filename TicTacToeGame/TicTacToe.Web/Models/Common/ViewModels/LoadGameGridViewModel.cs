namespace TicTacToe.Web.Models.Common.ViewModels
{
    using System;
    using AutoMapper;
    using TicTacToe.Models;
    using FrameworkExtentions.Mappings;

    public class LoadGameGridViewModel : IMapFrom<Game>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public int? TurnsCount { get; set; }

        public string HomeSideUserName { get; set; }

        public string OponentName { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Game, LoadGameGridViewModel>()
                         .ForMember(vm => vm.HomeSideUserName, opt => opt.MapFrom(s => s.ApplicationUser.UserName));
        }
    }
}