namespace CommuteUpdater.Tests
{
    using System.Threading.Tasks;
    using Xunit;

    public class TestTflClient
    {
        private readonly TflClient _sut;

        public TestTflClient()
        {
            _sut = new TflClient("https://api.tfl.gov.uk/");
        }

        [Fact]
        public async Task MakesRequestToApi()
        {
            var response = await _sut.GetDisruptionsForLineAsync("metropolitan");
        }
    }
}