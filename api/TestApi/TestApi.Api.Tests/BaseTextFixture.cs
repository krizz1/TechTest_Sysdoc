using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System.Net.Http;
using System.Threading.Tasks;
using TestApi.Data;

namespace TestApi.Api.Tests
{
    public class BaseTextFixture
    {
        protected TestServer _testServer;
        protected HttpClient _testClient;
        protected SysdocContext _dbContext;

        [OneTimeSetUp]
        public async Task Setup()
        {
            var builder = new WebHostBuilder()
                .UseStartup<Startup>()
                .ConfigureServices(services =>
                {
                    services.AddDbContext<SysdocContext>(options => options.UseInMemoryDatabase("TestingDB"));
                })
                .ConfigureTestServices(services =>
                {
                });

            _testServer = new TestServer(builder);
            _dbContext = _testServer.Host.Services.GetService(typeof(SysdocContext)) as SysdocContext;
            _testClient = _testServer.CreateClient();

            await AddProjectsToDb();
            await AddActionsToDb();
            await AddProductActionsToDb();
        }

        protected async Task AddProjectsToDb()
        {
            await AddNewProject(1);
            await AddNewProject(2);
        }

        protected async Task AddActionsToDb()
        {
            await AddNewAction(1);
            await AddNewAction(2);
            await AddNewAction(3);
            await AddNewAction(4);
        }

        protected async Task AddProductActionsToDb()
        {
            await AddNewProjectAction(1, 1);
        }

        #region Project Functions

        private async Task AddNewProject(int id)
        {
            if (await _dbContext.Projects.AnyAsync(x => x.Id == id) == true)
                return;
            
            _dbContext.Projects.Add(NewProject(id));
            _dbContext.SaveChanges();
        }

        private Data.Models.Project NewProject(int id) =>
            new Data.Models.Project()
            {
                Id = id,
                Name = "",
                Description = "",
                ProgressStatus = Data.Models.ProgressStatus.ACTIVE
            };

        #endregion

        #region Action Functions

        private async Task AddNewAction(int id)
        {
            if (await _dbContext.Actions.AnyAsync(x => x.Id == id) == true)
                return;

            _dbContext.Actions.Add(NewAction(id));
            _dbContext.SaveChanges();
        }

        private Data.Models.Action NewAction(int id) =>
            new Data.Models.Action()
            {
                Id = id,
                Name = "",
                Description = "",
                ProgressStatus = Data.Models.ProgressStatus.ACTIVE,
                RagStatus = Data.Models.RagStatus.GREEN
            };

        #endregion

        #region ProjectAction Functions

        private async Task AddNewProjectAction(int projectId, int actionId)
        {
            if (await _dbContext.ProjectActions.AnyAsync(x => x.ProjectId == projectId && x.ActionId == actionId) == true)
                return;

            _dbContext.ProjectActions.Add(NewProjectAction(projectId, actionId));
            _dbContext.SaveChanges();
        }

        private Data.Models.ProjectAction NewProjectAction(int projectId, int actionId) =>
            new Data.Models.ProjectAction()
            {
                ProjectId = projectId,
                ActionId = actionId
            };

        #endregion
    }
}
