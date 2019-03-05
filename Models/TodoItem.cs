﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Todo.Models
{
    public class TodoItem
    {
        public Guid TodoItemId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
