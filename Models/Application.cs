using System.ComponentModel.DataAnnotations;

namespace JobSearchApplication.Models
{
    public class Application
    {
        [Key]
        public int Id { get; set; }
        public int ResumeId { get; set; }
        public int JobId { get; set; }
        public int RoleId { get; set; }
        public int StatusId { get; set; }
        public string Comment { get; set; }

        public Resume Resume { get; set; }
        public Job Job { get; set; }
        public Role Role { get; set; }
        public Status Status { get; set; }
    }
}
