namespace FlightPlanner.Models
{
    public class SearchFlightRequest
    {
        public SearchFlightRequest(string departureDate,string from, string to)
        {
            DepartureDate = departureDate;
            From = from;
            To = to;
        }

        public string From { get; set; }
        public string To { get; set; }
        public string DepartureDate { get; set; }
    }
}