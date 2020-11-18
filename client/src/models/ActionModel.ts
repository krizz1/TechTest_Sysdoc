import IActionModel from './interfaces/IActionModel';
import IProgressStatusModel from './interfaces/IProgressStatusModel';
import IRagStatusModel from './interfaces/IRagStatusModel';

export default class ActionModel implements IActionModel {
  id:number;
  name:string;
  description:string;
  progressStatus:IProgressStatusModel;
  ragStatus:IRagStatusModel

  constructor(_id:number, _name:string, _description:string, _progressStatus:IProgressStatusModel, _ragStatus: IRagStatusModel)
  {
      this.id = _id;
      this.name = _name;
      this.description = _description;
      this.progressStatus = _progressStatus;
      this.ragStatus = _ragStatus;
  }
}