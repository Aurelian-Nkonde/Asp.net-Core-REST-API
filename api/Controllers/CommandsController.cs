using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CommandsAPI.Data;
using CommandsAPI.Models;
using AutoMapper;
using CommandsAPI.Dtos;

namespace CommandsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController: ControllerBase
    {

        private readonly ICommandAPIRepo _repository;
        private readonly IMapper _mapper;
        public CommandsController(ICommandAPIRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var commands = _repository.GetAllCommands();
            // return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commands));
            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commands));
        }


        [HttpGet("{id}", Name = "GetCommandById")]
        public ActionResult<CommandReadDto> GetCommandById(int id)
        {
            var command = _repository.GetCommandById(id);
            if (command == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<CommandReadDto>(command));
        }


        [HttpPost]
        // returning type of request, the expected parameter commandCreateDto is of type CommandCreateDto
        public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
        {
            var commandModel = _mapper.Map<Command>(commandCreateDto);  // mapping our new created commandCreateDto to our command model
            _repository.CreateCommand(commandModel); //creating our object
            _repository.SaveChanges(); //save changes in our database

            //map back our created commandModel to commandReadDto
            var CommandReadDto = _mapper.Map<CommandReadDto>(commandModel);
            return CreatedAtRoute(nameof(GetCommandById),
            new {Id = CommandReadDto.Id}, CommandReadDto);

        }



        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, CommandUpdateDto commandUpdateDto)
        {
            var commandModelFromRepo = _repository.GetCommandById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(commandUpdateDto, commandModelFromRepo);
            _repository.UpdateCommand(commandModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
            
        }


        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var commandFromRepo = _repository.GetCommandById(id);
            if(commandFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteCommand(commandFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}