using System.ComponentModel.DataAnnotations;

namespace TodoProject.Models
{
    public class TaskMaster
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public bool IsDone { get; set; } = false;
    }
}
