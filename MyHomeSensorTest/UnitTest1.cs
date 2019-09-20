using MyHomeSensors.Services;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void TestApiGetAll()
        {
            var httpService = new HttpService();
            var apiService = new ApiService(httpService);

            var data = apiService.GetAll().ConfigureAwait(false).GetAwaiter().GetResult();
            Assert.NotNull(data);
        }
    }
}