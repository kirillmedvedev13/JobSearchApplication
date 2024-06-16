using System.ComponentModel.DataAnnotations;

namespace JobSearchApplication.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<User> Users { get; set; }
        public ICollection<Application> Applications { get; set; }
    }
}
