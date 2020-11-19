import IRagStatusModel from './interfaces/IRagStatusModel';

export default class RagStatusModel implements IRagStatusModel {
  id:number;
  description:string;

  constructor(_id:number,  _description:string)
  {
    this.id = _id;
    this.description = _description;
  }
}

