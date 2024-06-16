using System.ComponentModel.DataAnnotations;

namespace JobSearchApplication.Models
{
    public class Jobseeker
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }

        public User User { get; set; }
        public ICollection<Resume> Resumes { get; set; }
    }
}
