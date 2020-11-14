using NUnit.Framework;
using System.Threading.Tasks;

namespace TestApi.Api.Tests
{
    public class ProjectTests : BaseTextFixture
    {
        [Test]
        [Category("Project")]
        public async Task Get_Ok()
        {
            var projectId = 1;
            var response = await _testClient.GetAsync($"api/1/project/{projectId}");
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
        }

        [Test]
        [Category("Project")]
        public async Task Get_BadRequest()
        {
            var projectId = 0;
            var response = await _testClient.GetAsync($"api/1/project/{projectId}");
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.BadRequest);
        }

        [Test]
        [Category("Project")]
        public async Task Get_NotFound()
        {
            var projectId = 100;
            var response = await _testClient.GetAsync($"api/1/project/{projectId}");
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.NotFound);
        }

        [Test]
        [Category("Action")]
        public async Task Patch_Ok()
        {
            var projectId = 1;
            var actionId = 2;
            var response = await _testClient.PatchAsync($"api/1/project/{projectId}/AssignAction/{actionId}", null);
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
        }

        [Test]
        [Category("Action")]
        public async Task Patch_BadRequest()
        {
            var projectId = 0;
            var actionId = 0;
            var response = await _testClient.PatchAsync($"api/1/project/{projectId}/AssignAction/{actionId}", null);
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.BadRequest);
        }

        [Test]
        [Category("Action")]
        public async Task Patch_NotFound()
        {
            var projectId = 100;
            var actionId = 5;
            var response = await _testClient.PatchAsync($"api/1/project/{projectId}/AssignAction/{actionId}", null);
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.NotFound);
        }
    }
}