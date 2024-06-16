using System.ComponentModel.DataAnnotations;

namespace JobSearchApplication.Models
{
    public class Status
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Application> Applications { get; set; }
    }
}
