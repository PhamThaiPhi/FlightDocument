using Intern_Alta.Data;

namespace Intern_Alta.Services.Flights
{
    public class FlightService : IFlightService
    {
        private readonly MyDbContext _context;

        public FlightService(MyDbContext context)
        {
            _context = context;
        }

        public List<Flight> GetAllFlights()
        {
            return _context.Flights.ToList();
        }

        public Flight GetFlightById(int id)
        {
            return _context.Flights.SingleOrDefault(f => f.FlightsID == id);
        }

        public Flight CreateFlight(Flight flight)
        {
            if (flight == null)
            {
                throw new ArgumentNullException(nameof(flight), "Flight data is invalid.");
            }

            _context.Flights.Add(flight);
            _context.SaveChanges();
            return flight;
        }
        public Flight UpdateFlight(int id, Flight flight)
        {
            var existingFlight = _context.Flights.SingleOrDefault(f => f.FlightsID == id);
            if (existingFlight == null)
            {
                throw new KeyNotFoundException($"Flight with ID {id} not found.");
            }

            existingFlight.FlightsNumber = flight.FlightsNumber;
            existingFlight.Departure = flight.Departure;
            existingFlight.PointOfUnloading = flight.PointOfUnloading;
            existingFlight.PointOfLoading = flight.PointOfLoading;
            

            _context.SaveChanges();
            return existingFlight;
        }

        public bool DeleteFlight(int id)
        {
            var flight = _context.Flights.SingleOrDefault(f => f.FlightsID == id);
            if (flight == null)
            {
                return false;
            }

            _context.Flights.Remove(flight);
            _context.SaveChanges();
            return true;
        }
    }
}
