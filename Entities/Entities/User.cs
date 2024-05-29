using System.ComponentModel.DataAnnotations;

namespace Entities.Entities
{
    public partial class User : IEntity
    {
        [Key]
        public int UserId { get; set; }

        public string? UserName { get; set; }

        public string? PersonImage { get; set; }

        public  ICollection<Order> Orders { get; set; }
    }
}
