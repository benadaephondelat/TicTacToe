﻿namespace TicTacToe.Web.FrameworkExtentions.Mappings
{
    using AutoMapper;

    public interface IHaveCustomMappings
    {
        void CreateMappings(IConfiguration configuration);
    }
}