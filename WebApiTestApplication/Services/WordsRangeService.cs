using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using WebApiTestApplication.Exceptions;

namespace WebApiTestApplication.Services
{
    public class WordsRangeService : IWordsRangeService
    {
        private readonly List<string> _wordsList;

        /// <summary>
        ///     .ctor
        /// </summary>
        /// <param name="source">Array or words.</param>
        public WordsRangeService(string[] source)
        {
            _wordsList = new List<string>(source);
        }

        /// <summary>
        ///     .ctor
        /// </summary>
        /// <param name="sourceFilePath">Path to the dictionary file.</param>
        public WordsRangeService(string sourceFilePath)
        {
            var source = File.ReadAllLines(sourceFilePath);
            _wordsList = new List<string>(source);
        }

        /// <summary>
        ///     Get words range by the passed parameters.
        /// </summary>
        /// <param name="from">Start parameter from range.</param>
        /// <param name="to">End parameter from range.</param>
        /// <returns>Range of words, between start and end parameters.</returns>
        public IEnumerable<string> GetRange(string from, string to)
        {
            var startIndex = _wordsList.IndexOf(from);
            var endIndex = _wordsList.IndexOf(to);
            if (startIndex == -1)
            {
                throw new WordNotFoundException($"Word {@from} not found.");
            }

            if (endIndex == -1)
            {
                throw new WordNotFoundException($"Word {@to} not found.");
            }
            if (endIndex < startIndex)
            {
                var tmp = startIndex;
                startIndex = endIndex;
                endIndex = tmp;
            }
            IEnumerable<string> res = _wordsList.GetRange(startIndex, endIndex - startIndex + 1);
            return res;
        }
    }
}