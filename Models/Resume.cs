using System.ComponentModel.DataAnnotations;

namespace JobSearchApplication.Models
{
    public class Resume
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Experience { get; set; }
        public int LocationId { get; set; }
        public string Skills { get; set; }
        public string Education { get; set; }
        public int CategoryId { get; set; }
        public int JobseekerId { get; set; }

        public Location Location { get; set; }
        public Category Category { get; set; }
        public Jobseeker Jobseeker { get; set; }
        public ICollection<Application> Applications { get; set; }
    }
}
