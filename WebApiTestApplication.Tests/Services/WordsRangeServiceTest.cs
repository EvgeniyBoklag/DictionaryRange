using System.Linq;
using NUnit.Framework;
using WebApiTestApplication.Exceptions;
using WebApiTestApplication.Services;
using WebApiTestApplication.Tests.Const;

namespace WebApiTestApplication.Tests.Services
{
    [TestFixture]
    public class WordsRangeServiceTest
    {
        [SetUp]
        public void Setup()
        {
            InitWordsDictionary();
        }

        private string[] _words;
        
        private void InitWordsDictionary()
        {
            _words = WordsServiceFake.Words;
        }

        [Test]
        public void ShouldReturnExpectedRange_Test()
        {
            IWordsRangeService service = new WordsRangeService(_words);
            var res = service.GetRange("azzuolo", "overface");
            Assert.AreEqual(23, res.Count());
        }

        [Test]
        public void ShouldReturnExpectedRangeWithIfFromGreaterTo_Test()
        {
            IWordsRangeService service = new WordsRangeService(_words);
            var res = service.GetRange("overface", "azzuolo");
            Assert.AreEqual(23, res.Count());
        }

        [Test]
        public void ShouldThrowExceptionIfWordNotExistsInDictionary_Test()
        {
            IWordsRangeService service = new WordsRangeService(new string[] {});
            Assert.Throws<WordNotFoundException>(() => service.GetRange("fake_word", "fake_word2"));
        }


        [Test]
        public void ShouldThrowExceptionWithEmptyDictionary_Test()
        {
            IWordsRangeService service = new WordsRangeService(new string[] {});
            Assert.Throws<WordNotFoundException>(() => service.GetRange("overface", "azzuolo"));
        }

        [Test]
        public void ShouldReturnOneValueFromArgumentEqualsToArgument_Test()
        {
            IWordsRangeService service = new WordsRangeService(_words);
            var res = service.GetRange("overface", "overface");
            Assert.AreEqual(1, res.Count());
        }
    }
}