namespace CommuteUpdater
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IDisruptionRetriever
    {
        Task<IEnumerable<string>> RetrieveDisruptions();
    }
}