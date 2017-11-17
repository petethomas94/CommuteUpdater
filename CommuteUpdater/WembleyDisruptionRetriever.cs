namespace CommuteUpdater
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AngleSharp;

    public class WembleyDisruptionRetriever : IDisruptionRetriever
    {
        private static string _dateFormat = "dd MMMM yyyy";
        private static string _eventsLocation = "https://clubwembley.wembleystadium.com/Events/EventsCalendar";
        private static string _sports = "#S1";
        private static string _concerts = "#C1";

        public async Task<IEnumerable<string>> RetrieveDisruptions()
        {
            var summary = new List<string>();

            var results = await Task.WhenAll(
                EventOnToday(_eventsLocation + _sports, DateTime.Today),
                EventOnToday(_eventsLocation + _concerts, DateTime.Today));

            if (results.Contains(true))
            {
                summary.Add("There are currently events on at Wembley");
            }

            return summary;
        }

        private async Task<bool> EventOnToday(string url, DateTime date)
        {
            var config = Configuration.Default.WithDefaultLoader();

            var document = await BrowsingContext.New(config).OpenAsync(url);

            var dateString = date.ToString(_dateFormat);

            return document.QuerySelectorAll("time")
                .Select(t => t.InnerHtml == dateString)
                .Any();
        }

    }
}