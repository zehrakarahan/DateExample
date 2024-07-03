using System.ComponentModel.DataAnnotations.Schema;

namespace DateExample.Data
{
    [Table("Tours")]
    public class ToursEntity : BaseEntity<int>
    {
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }

    }
}
