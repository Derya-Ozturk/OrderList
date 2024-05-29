using System.ComponentModel.DataAnnotations;

namespace Entities.Entities
{
    public class SalesRepresentive: IEntity
    {
        [Key]
        public int SalesRepresentiveId { get; set; }
        public string? SalesRepresentiveName { get; set; }
        public string? SalesRepresentiveAbbr { get; set; }
        public string? PersonImage { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
