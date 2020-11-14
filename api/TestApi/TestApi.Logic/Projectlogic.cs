using System.Collections.Generic;
using System.Threading.Tasks;
using TestApi.Data;
using TestApi.Domain;
using System.Linq;

namespace TestApi.Logic
{
    public class Projectlogic : BaseLogic, IProjectLogic
    {
        public Projectlogic(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<Project> GetById(int projectId)
        {
            var project = await GetProjectById(projectId);
            project.Actions = await GetProjectActionsById(projectId);
            return project;
        }

        public async Task<IEnumerable<Project>> GetAll()
        {
            var projects = (await GetAllProjects()).ToList();

            foreach (var project in projects)
                project.Actions = (await GetProjectActionsById(project.Id)).ToList();

            return projects;
        }

        public async Task AddActionToProject(int projectId, int actionId)
        {
            var project = await _unitOfWork.Projects.GetById(projectId);

            PkCheck<Data.Models.Project>(project, projectId);

            var action = await _unitOfWork.Actions.GetById(actionId);

            PkCheck<Data.Models.Action>(action, actionId);

            await _unitOfWork.ProjectActions.Add(new Data.Models.ProjectAction()
            {
                ProjectId = projectId,
                ActionId = actionId
            });

            await _unitOfWork.SaveChanges();
        }

        #region Internal Functions

        private void PkCheck<T>(T input, int id)
        {
            if (input == null)
                throw new KeyNotFoundException($"Project with id {id} does not exist");
        }

        private async Task<Project> GetProjectById(int projectId) =>
            Mapping.Project.MapOne(await _unitOfWork.Projects.GetById(projectId) ?? throw new KeyNotFoundException($"Project with id {projectId} does not exist"));

        private async Task<IEnumerable<Project>> GetAllProjects() =>
           Mapping.Project.MapMany(await _unitOfWork.Projects.GetAll());

        private async Task<IEnumerable<Domain.Action>> GetProjectActionsById(int projectId) =>
            Mapping.Action.MapMany(await _unitOfWork.Actions.GetByProjectId(projectId));

        #endregion

       
    }
}
