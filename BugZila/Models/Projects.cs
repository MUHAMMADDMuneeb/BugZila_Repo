using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugZila.Models
{
    public class Projects
    {
        [Key]
        public int ProjectID { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime Deadline { get; set; }

        public ICollection<ProjectUser>? ProjectUsers { get; set; }

        [ForeignKey("Manager")]
        public int? ManagerID { get; set; }
        public Users? Manager { get; set; }

        public ICollection<Bugs>? ProjectBugs { get; set; }   

    }
}
