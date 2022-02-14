using FlightPlanner.Models;

namespace FlightPlanner.Storage
{
    public class FlightRequest
    {
        public static bool IsValid(SearchFlightRequest request)
        {
            if (request == null)
                return false;
            if (request.From == null || request.To == null)
                return false;
            if (request.From == request.To)
                return false;
            return true;
        }
    }
}