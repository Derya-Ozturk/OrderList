using Entities.Entities;

namespace Entities.Dtos
{
    public class UserDto : IDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string? PersonImage { get; set; }
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
