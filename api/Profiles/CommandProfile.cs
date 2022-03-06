using AutoMapper;
using CommandsAPI.Dtos;
using CommandsAPI.Models;

namespace CommandsAPI.Profiles
{
    public class CommandProfile: Profile
    {
        public CommandProfile()
        {
            //source, target
            CreateMap<Command, CommandReadDto>();
            CreateMap<CommandCreateDto, Command>();
            CreateMap<CommandUpdateDto, Command>();
            
        }
    }
}