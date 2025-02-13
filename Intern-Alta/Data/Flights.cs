using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Intern_Alta.Data
{
    [Table("Flights")]
    public class Flight
    {
        [Key]
        public int FlightsID { get; set; }
        public string FlightsNumber { get; set; }
        public int Route { get; set; }
        public DateTime? Departure { get; set; }
        //public int DocumentID { get; set; }
        public string PointOfLoading { get; set; }
        public string PointOfUnloading { get; set; }

        public virtual ICollection<Document>? Documents { get; set; }
    }
}
