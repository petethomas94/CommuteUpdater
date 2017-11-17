namespace CommuteUpdater
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class TflDisruptionRetriever : IDisruptionRetriever
    {
        private readonly ITflClient _client;
        private readonly string[] _lineIds;

        public TflDisruptionRetriever(ITflClient client, string[] lineIds)
        {
            _client = client;
            _lineIds = lineIds;
        }

        public async Task<IEnumerable<string>> RetrieveDisruptions()
        {
            var getDisruptions = _lineIds.Select(id => _client.GetDisruptionsForLineAsync(id));

            return (await Task.WhenAll(getDisruptions))
                .SelectMany(d => d)
                .Select(d => d.Description);
        }
    }
}