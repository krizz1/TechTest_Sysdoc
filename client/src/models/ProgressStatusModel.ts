import IProgressStatusModel from './interfaces/IProgressStatusModel';

export default class ProgressStatusModel implements IProgressStatusModel {
  id:number;
  description:string;

  constructor(_id:number,  _description:string)
  {
      this.id = _id;
      this.description = _description;
  }
}

