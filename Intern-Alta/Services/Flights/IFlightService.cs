using Intern_Alta.Data;
using Intern_Alta.Models;
namespace Intern_Alta.Services.Flights
{
    public interface IFlightService
    {
        // Lấy danh sách tất cả chuyến bay
        List<Flight> GetAllFlights();

        // Lấy thông tin chuyến bay theo ID
        Flight GetFlightById(int id);

        // Tạo mới một chuyến bay
        Flight CreateFlight(FlightModel model);
        Flight UpdateFlight(int id, Flight flight);

        // Xóa chuyến bay theo ID
        bool DeleteFlight(int id);
    }
}
