using System.ComponentModel.DataAnnotations;

namespace JobSearchApplication.Models
{
    public class Job
    {
        [Key]
        public int Id { get; set; }
        public string Jobs { get; set; }
        public string Description { get; set; }
        public DateTime PostedDate { get; set; }
        public int LocationId { get; set; }
        public int MinExperience { get; set; }
        public decimal Salary { get; set; }
        public int CategoryId { get; set; }
        public int EmployerId { get; set; }

        public Location Location { get; set; }
        public Category Category { get; set; }
        public Employer Employer { get; set; }
        public ICollection<Application> Applications { get; set; }
    }
}
