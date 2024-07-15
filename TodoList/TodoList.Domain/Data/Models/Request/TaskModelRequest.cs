using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Domain.Data.Models.Request
{
    public class TaskModelRequest
    {
        public string? Name { get; set; }
        [Required]
        [NotNull]
        public bool IsCompleted { get; set; }
        public UserRequest? User { get; set; }
    }
}
