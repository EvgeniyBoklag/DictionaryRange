using System.Collections.Generic;

namespace WebApiTestApplication.Services
{
    public interface IWordsRangeService
    {
        IEnumerable<string> GetRange(string from, string to);
    }
}