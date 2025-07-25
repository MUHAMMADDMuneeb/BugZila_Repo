using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugZila.Models
{
    public class Bugs
    {
        [Key]
        public int BugID { get; set; }
        [Required]
        public int Type { get; set; }
        public int Status { get; set; }
        [Required]
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime Deadline { get; set; }

        
        [ForeignKey("Creator")]
        public int CreatorID { get; set; }
        public Users Creator { get; set; }
        [ForeignKey("Developer")]
        public int? DeveloperID { get; set; }
        public Users? Developer { get; set; }
        [ForeignKey("Project")]
        public int ProjectID { get; set; }
        public Projects? Project { get; set; }

        public byte[]? Screenshot { get; set; }
    }
}
