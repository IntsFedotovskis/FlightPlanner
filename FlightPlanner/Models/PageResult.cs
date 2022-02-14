using System.Collections.Generic;
using System.Linq;
using FlightPlanner.Storage;

namespace FlightPlanner.Models
{
    public class PageResult
    {
        private PageResult(List<Flight> flights)
        {
            Items = flights;
            TotalItems = Items.Count;
        }

        public int Page { get; set; }
        public int TotalItems { get; set; }
        public List<Flight> Items { get; set; }

        public static PageResult FindFLight(SearchFlightRequest request)
        {
            var flights = FlightStorage.GetFlightsList().Where(f =>
                    f.From.AirportName == request.From || f.To.AirportName == request.To ||
                    f.DepartureTime == request.DepartureDate)
                .ToList();
            return new PageResult(flights);
        }
    }
}