using System.Linq;
using System.Net.Http;
using System.Web.Http;
using NUnit.Framework;
using WebApiTestApplication.Controllers;
using WebApiTestApplication.Exceptions;
using WebApiTestApplication.Services;
using WebApiTestApplication.Tests.Const;

namespace WebApiTestApplication.Tests.Controllers
{
    [TestFixture]
    public class WordControllerTest
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
            var controller = new WordController(service)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
            // Act on Test  
            var response = controller.Get("azzuolo", "overface");
            Assert.AreEqual(23, response.Count());
        }

        [Test]
        public void ShouldThrowExceptionIfArgumentsInvalid_Test()
        {
            IWordsRangeService service = new WordsRangeService(_words);
            var controller = new WordController(service)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
            // Act on Test  

            Assert.Throws<InvalidWordRangeArgumentException>(() => controller.Get("", "overface"));
            Assert.Throws<InvalidWordRangeArgumentException>(() => controller.Get("overface", ""));
        }
    }
}