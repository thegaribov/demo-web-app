using System.ComponentModel.DataAnnotations;

namespace DemoApplication.Database.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }
        public User User { get; set; }
    }
}
