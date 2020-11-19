import IActionModel from './interfaces/IActionModel';
import IProgressStatusModel from './interfaces/IProgressStatusModel';
import IRagStatusModel from './interfaces/IRagStatusModel';
import IProjectModel from './interfaces/IProjectModel';

export default class ActionModel implements IActionModel {
  id:number;
  name:string;
  description:string;
  progressStatus:IProgressStatusModel;
  ragStatus:IRagStatusModel;
  projects:IProjectModel[];

  constructor(_id:number, _name:string, _description:string, _progressStatus:IProgressStatusModel, _ragStatus: IRagStatusModel, _projects: IProjectModel[])
  {
      this.id = _id;
      this.name = _name;
      this.description = _description;
      this.progressStatus = _progressStatus;
      this.ragStatus = _ragStatus;
      this.projects = _projects;

  }
}