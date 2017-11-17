namespace CommuteUpdater.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using FluentAssertions;
    using Moq;
    using Xunit;

    public class TestTflDisruptionRetriever
    {
        private const string LineId1 = "test";
        private const string LineId2 = "test2";

        private readonly TflDisruptionRetriever _sut;

        private readonly Mock<ITflClient> _tflClient = new Mock<ITflClient>();

        private List<DisruptionResponse> _disruptionResponses = new List<DisruptionResponse>()
        {
            new DisruptionResponse()
            {
                Description = "Test description 1"
            },
            new DisruptionResponse()
            {
                Description = "Test description 2"
            },
        };

        public TestTflDisruptionRetriever()
        {
            _sut = new TflDisruptionRetriever(_tflClient.Object, new[] { LineId1, LineId2 });
        }

        [Fact]
        public async Task TestRetrieveDisruptionsReturnsCorrectData()
        {
            _tflClient.Setup(c => c.GetDisruptionsForLineAsync(LineId1)).ReturnsAsync(_disruptionResponses);
            _tflClient.Setup(c => c.GetDisruptionsForLineAsync(LineId2)).ReturnsAsync(_disruptionResponses);

            var disruptions = await _sut.RetrieveDisruptions();

            disruptions.ToList().Count.Should().Be(4);
        }
    }
}
