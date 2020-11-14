using NUnit.Framework;
using System.Threading.Tasks;

namespace TestApi.Api.Tests
{
    public class ActionTests : BaseTextFixture
    {
        [Test]
        [Category("Action")]
        public async Task Get_Ok()
        {
            var actionId = 1;
            var response = await _testClient.GetAsync($"api/1/action/{actionId}");
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
        }

        [Test]
        [Category("Action")]
        public async Task Get_BadRequest()
        {
            var actionId = 0;
            var response = await _testClient.GetAsync($"api/1/action/{actionId}");
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.BadRequest);
        }

        [Test]
        [Category("Action")]
        public async Task Get_NotFound()
        {
            var actionId = 100;
            var response = await _testClient.GetAsync($"api/1/action/{actionId}");
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.NotFound);
        }
    }
}