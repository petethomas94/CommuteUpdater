namespace CommuteUpdater.Tests
{
    using System.Threading.Tasks;
    using Xunit;

    public class TestWembleyDisruptionRetriever
    {
        [Fact]
        public async Task test()
        {
            var dr = new WembleyDisruptionRetriever();

            await dr.RetrieveDisruptions();
        }
    }
}
