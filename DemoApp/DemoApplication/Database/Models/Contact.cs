using DemoApplication.Database.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace DemoApplication.Database.Models
{
    public class Contact : BaseEntity, IAuditable
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }
        
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
