using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugZila.Models
{
    public class Users
    {
        [Key]
        public int UserID { get; set; }

        public string? Name { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        public string? PasswordHash { get; set; } // 🔐 Store only the hash

        [NotMapped]
        [Required]
        [MinLength(8)]
        public string? Password { get; set; } // Used for input only

        public int UserType { get; set; }

        public ICollection<ProjectUser>? ProjectUsers { get; set; }
        public ICollection<Projects>? ManagedProjects { get; set; }
        public ICollection<Bugs>? CreatedBugs { get; set; }
        public ICollection<Bugs>? DeveloperBugs { get; set; }
    }

}
