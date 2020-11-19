import IProgressStatusModel from './IProgressStatusModel';
import IRagStatusModel from './IRagStatusModel';
import IProjectModel from './IProjectModel';

export default interface IActionModel {
  readonly id:number,
  readonly name:string,
  readonly description:string,
  readonly progressStatus:IProgressStatusModel,
  readonly ragStatus:IRagStatusModel,
  readonly projects:IProjectModel[]
}