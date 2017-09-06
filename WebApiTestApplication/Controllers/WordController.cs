using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using WebApiTestApplication.Exceptions;
using WebApiTestApplication.Filters;
using WebApiTestApplication.Services;

namespace WebApiTestApplication.Controllers
{
    [WordsRangeExceptionFilter]
    public class WordController : ApiController
    {
        private readonly IWordsRangeService _wordsRangeService;

        public WordController(IWordsRangeService wordsRangeService)
        {
            _wordsRangeService = wordsRangeService;
        }

        public async Task<IEnumerable<string>> Get()
        {
            return await Task.FromResult(new string[] {});
        }

        // GET api/values

        public IEnumerable<string> Get(string from, string to)
        {
            if (string.IsNullOrEmpty(from) || string.IsNullOrEmpty(to))
            {
                throw new InvalidWordRangeArgumentException("Invalid word range arguments 'from' or 'to'.");
            }
            return _wordsRangeService.GetRange(from, to);
        }
    }
}