using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Intern_Alta.Data
{
    [Table("Flights")]
    public class Flight
    {
        [Key]
        public int FlightsID { get; set; } // Khóa chính cho chuyến bay
        public string FlightsNumber { get; set; } // Số chuyến bay
        public int Route { get; set; } // ID tuyến đường
        public DateTime Departure { get; set; } // Thời gian khởi hành
        public int DocumentID { get; set; } // Khóa ngoại liên kết đến bảng Documents
        public string PointOfLoading { get; set; } // Điểm khởi hành
        public string PointOfUnloading { get; set; } // Điểm dỡ hàng
    }
}
