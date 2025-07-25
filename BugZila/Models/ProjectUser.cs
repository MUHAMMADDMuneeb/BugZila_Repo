using System.ComponentModel.DataAnnotations.Schema;

namespace BugZila.Models
{
    public class ProjectUser
    {
        [ForeignKey("User")]
        public int UserID { get; set; }
        public Users? User { get; set; }

        [ForeignKey("Project")]
        public int ProjectID { get; set; }
        public Projects? Project { get; set; }
    }
}
