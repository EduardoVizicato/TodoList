﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Domain.Data.Models
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public ICollection<TaskModel> Tasks { get; set; }

        public User()
        {
            Tasks = new List<TaskModel>();
        }
    }
}
