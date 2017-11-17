namespace CommuteUpdater
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ITflClient
    {
        Task<List<DisruptionResponse>> GetDisruptionsForLineAsync(string lineId);
    }
}