using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace JobSearchApplication.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }

        public Role Role { get; set; }
        public Jobseeker Jobseeker { get; set; }
        public Employer Employer { get; set; }
    }
}
