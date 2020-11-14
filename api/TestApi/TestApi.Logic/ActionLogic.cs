using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApi.Data;
using TestApi.Domain;

namespace TestApi.Logic
{
    public class ActionLogic:BaseLogic,IActionLogic
    {
        public ActionLogic(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }      

        public async Task<Action> GetById(int projectId)
        {
            var action = await GetActionById(projectId);
            action.Projects = await GetActionProjectsById(projectId);
            return action;
        }

        public async Task<IEnumerable<Action>> GetAll()
        {
            var actions = (await GetAllActions()).ToList();

            foreach (var action in actions)
                action.Projects = (await GetActionProjectsById(action.Id)).ToList();

            return actions;
        }

        #region Internal Functions

        private async Task<Action> GetActionById(int actionId) =>
            Mapping.Action.MapOne(await _unitOfWork.Actions.GetById(actionId) ?? throw new KeyNotFoundException($"Action with id {actionId} does not exist"));

        private async Task<IEnumerable<Action>> GetAllActions() =>
            Mapping.Action.MapMany(await _unitOfWork.Actions.GetAll());

        private async Task<IEnumerable<Project>> GetActionProjectsById(int actionId) =>
            Mapping.Project.MapMany(await _unitOfWork.Projects.GetByActionId(actionId));

        #endregion
    }
}
