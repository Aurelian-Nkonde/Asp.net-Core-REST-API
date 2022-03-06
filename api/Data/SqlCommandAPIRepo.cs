using System;
using System.Collections.Generic;
using CommandsAPI.Models;
using CommandsAPI.Data;
using System.Linq;


namespace CommandsAPI.ReadData
{

    public class SqlCommandAPIRepo : ICommandAPIRepo
    {

        private readonly APIDbContext _context;
        public SqlCommandAPIRepo(APIDbContext context)
        {
            _context = context;
        }

        public void CreateCommand(Command cmd)
        {
            if(cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            _context.Commands.Add(cmd);
        }

        public void DeleteCommand(Command cmd)
        {
            if(cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            _context.Commands.Remove(cmd);
        }

        public IEnumerable<Command> GetAllCommands()
        {
            var allCommands = _context.Commands.ToList();
            return allCommands;
        }

        public Command GetCommandById(int id)
        {
            var command = _context.Commands.FirstOrDefault(a => a.Id == id);
            return command;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateCommand(Command id)
        {
            // we do nothing here
        }
    }

}