namespace CommuteUpdater
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Host;

    public static class CommuteUpdaterFunction
    {
        public static string[] LineIds = { "metropolitan", "jubilee" };

        [FunctionName("CommuteUpdaterFunction")]
        public static async Task Run([TimerTrigger("0 0 17 ? * MON,TUE,WED,THU,FRI *")]TimerInfo myTimer, TraceWriter log)
        {
            try
            {
                var tflDisruptionRetriever = new TflDisruptionRetriever(
                    new TflClient("https://api.tfl.gov.uk"),
                    LineIds);

                var wembleyDisruptionRetriever = new WembleyDisruptionRetriever();

                var disruptionSummaries = (await Task.WhenAll(
                        wembleyDisruptionRetriever.RetrieveDisruptions(),
                        tflDisruptionRetriever.RetrieveDisruptions()))
                    .SelectMany(d => d);

                if (disruptionSummaries.Any())
                {
                    var summary = SummaryFormatter.FormatSummaries(disruptionSummaries);
                    var notifier = new TwilioNotifier(new TwilioConfig());
                    await notifier.NotifyOfDisruptions(summary);
                }

                log.Info($"C# Timer trigger function executed at: {DateTime.Now}");
            }
            catch (Exception ex)
            {
                log.Error($"Failed to run at: {DateTime.Now}", ex);
            }
        }
    }

    public static class SummaryFormatter
    {
        public static string FormatSummaries(IEnumerable<string> summaries)
        {
            return string.Join(",", summaries);
        }
    }

    public interface INotifier
    {
        Task NotifyOfDisruptions(string disruptionSummary);
    }

    public class TwilioNotifier : INotifier
    {
        private readonly TwilioConfig _config;

        public TwilioNotifier(TwilioConfig config)
        {
            _config = config;
        }

        public Task NotifyOfDisruptions(string disruptionSummary)
        {
            throw new NotImplementedException();
        }
    }

    public class TwilioConfig
    {
        public string AccountSid { get; set; }
        public string AuthToken { get; set; }
        public string PhoneNumber { get; set; }

        public TwilioConfig()
        {
            AccountSid = ConfigurationManager.AppSettings["AccountSid"];
            AuthToken = GetEnvironmentVariable("AuthToken");
            PhoneNumber = GetEnvironmentVariable("PhoneNumber");
        }

        public string GetEnvironmentVariable(string name)
        {
            return name + ": " +
                   System.Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.Process);
        }
    }
}
