using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Domain.Data.Models;

namespace TodoList.Infrastructure.Data
{
    public class ApplicationDataContext(DbContextOptions<ApplicationDataContext> options) : DbContext(options)
    {
        public DbSet<TaskModel>  Tasks { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
