namespace Intern_Alta.Models
{
    public class FlightModel
    {
        public string FlightsNumber { get; set; } // Số chuyến bay
        public int Route { get; set; } // ID tuyến đường
        public DateTime? Departure { get; set; } // Thời gian khởi hành
        public int DocumentID { get; set; } // Khóa ngoại liên kết đến bảng Documents
        public string PointOfLoading { get; set; } // Điểm khởi hành
        public string PointOfUnloading { get; set; } // Điểm dỡ hàng
    }
}
