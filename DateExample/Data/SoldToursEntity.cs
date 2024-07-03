using System.ComponentModel.DataAnnotations.Schema;

namespace DateExample.Data
{
    [Table("SoldTours")]
    public class SoldToursEntity : BaseEntity<int>
    {
        public int UserId { get; set; }
        public int? TourId { get; set; }
        public ToursEntity Tour { get; set; }
    }
}
