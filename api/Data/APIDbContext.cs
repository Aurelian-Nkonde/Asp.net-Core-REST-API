using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CommandsAPI.Models;

public class APIDbContext: DbContext
{
    public APIDbContext(DbContextOptions<APIDbContext> opt): base(opt)
    {

    }

    public DbSet<Command> Commands { get; set; }

}