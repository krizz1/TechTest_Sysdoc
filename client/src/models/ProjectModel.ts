import IProjectModel from './interfaces/IProjectModel';
import IProgressStatusModel from './interfaces/IProgressStatusModel';

export default class ProjectModel implements IProjectModel {
  id:number;
  name:string;
  description:string;
  progressStatus:IProgressStatusModel;

  constructor(_id:number, _name:string, _description:string, _progressStatus:IProgressStatusModel)
  {
      this.id = _id;
      this.name = _name;
      this.description = _description;
      this.progressStatus = _progressStatus;
  }
}