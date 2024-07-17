using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Domain.Models.Requests
{
    public class UserModelRequest
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
    }
}
