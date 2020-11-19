import IProjectModel from './interfaces/IProjectModel';
import IProgressStatusModel from './interfaces/IProgressStatusModel';
import IActionModel from './interfaces/IActionModel';

export default class ProjectModel implements IProjectModel {
  id:number;
  name:string;
  description:string;
  progressStatus:IProgressStatusModel;
  actions:IActionModel[];

  constructor(_id:number, _name:string, _description:string, _progressStatus:IProgressStatusModel, _actions:IActionModel[])
  {
    this.id = _id;
    this.name = _name;
    this.description = _description;
    this.progressStatus = _progressStatus;
    this.actions = _actions;
  }
}