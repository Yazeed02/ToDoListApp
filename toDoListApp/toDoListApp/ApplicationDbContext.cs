using Microsoft.EntityFrameworkCore;
using toDoListApp.Models;
using System.Diagnostics.CodeAnalysis;

namespace toDoListApp
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }
        public DbSet<ToDoItem> ToDoItems { get; set; }

    }
}
