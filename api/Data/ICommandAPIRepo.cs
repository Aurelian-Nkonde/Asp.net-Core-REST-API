using System;
using System.Collections.Generic;
using CommandsAPI.Models;


namespace CommandsAPI.Data
{
    public interface ICommandAPIRepo
    {
        bool SaveChanges();

        IEnumerable<Command> GetAllCommands();
        Command GetCommandById(int id);
        void DeleteCommand(Command id);
        void UpdateCommand(Command id);
        void CreateCommand(Command id);
    }
}
