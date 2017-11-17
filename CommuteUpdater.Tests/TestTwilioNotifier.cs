namespace CommuteUpdater.Tests
{
    using Xunit;

    public class TestTwilioNotifier
    {
        private TwilioNotifier _notifier;

        public TestTwilioNotifier()
        {
            _notifier = new TwilioNotifier(new TwilioConfig());
        }

        [Fact]
        public void Test()
        {

        }
    }
}
