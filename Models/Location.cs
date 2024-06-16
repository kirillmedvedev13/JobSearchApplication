using System.ComponentModel.DataAnnotations;

namespace JobSearchApplication.Models
{
    public class Location
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }

        public ICollection<Resume> Resumes { get; set; }
        public ICollection<Job> Jobs { get; set; }
    }
}
