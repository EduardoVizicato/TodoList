using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Domain.Models.Requests
{
    public class TaskModelRequest
    {
        public string Name { get; set; }
        public bool IsCompleted { get; set; }
    }
}
