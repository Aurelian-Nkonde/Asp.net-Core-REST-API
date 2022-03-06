using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using CommandsAPI.Data;
using CommandsAPI.Models;

namespace CommandsAPI.Data2
{
    public class MockCommandAPIRepo : ICommandAPIRepo
    {
        public void CreateCommand(Command id)
        {
            throw new NotImplementedException();
        }

        public void DeleteCommand(Command id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands()
        {
            var commands = new List<Command>
            {
                new Command
                {
                    Id = 0,
                    HowTo = "How to generate a migration",
                    Platform=".Net Core EF",
                    CommandLine="dotnet ef migrations add <Name of Migration>"
                },
                new Command
                {
                    Id=1,
                    HowTo="Run Migrations",
                    CommandLine="dotnet ef database update",
                    Platform=".Net Core EF"
                }
            };
            return commands;
        }

        public Command GetCommandById(int id)
        {
            return new Command
            {
                Id = 0,
                HowTo = "How to generate a migration",
                CommandLine = "dotnet ef migrations add <Name of Migration>",
                Platform = ".Net Core EF"
            };
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateCommand(Command id)
        {
            throw new NotImplementedException();
        }
    }
}