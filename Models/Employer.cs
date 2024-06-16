using System.ComponentModel.DataAnnotations;

namespace JobSearchApplication.Models
{
    public class Employer
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyDescription { get; set; }
        public string Number { get; set; }
        public int EmployeeCount { get; set; }
        public string Address { get; set; }

        public User User { get; set; }
        public ICollection<Job> Jobs { get; set; }
    }

}
