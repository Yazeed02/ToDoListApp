using System;
using System.ComponentModel.DataAnnotations;

namespace toDoListApp.Models
{
    public class ToDoItem
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Task description is required.")]
        [StringLength(100, ErrorMessage = "Task cannot exceed 100 characters.")]
        public string Task { get; set; }

        public bool IsCompleted { get; set; } = false;

        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
