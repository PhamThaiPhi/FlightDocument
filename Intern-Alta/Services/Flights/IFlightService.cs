using Intern_Alta.Data;
using Intern_Alta.Models;
namespace Intern_Alta.Services.Flights
{
    public interface IFlightService
    {
     
        List<Flight> GetAllFlights();

        
        Flight GetFlightById(int id);

        
        Flight CreateFlight(FlightModel model);
        Flight UpdateFlight(int id, Flight flight);

        
        bool DeleteFlight(int id);
    }
}
