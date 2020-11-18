import IProgressStatusModel from './IProgressStatusModel';
import IRagStatusModel from './IRagStatusModel';

export default interface IActionModel {
  readonly id:number,
  readonly name:string,
  readonly description:string,
  readonly progressStatus:IProgressStatusModel,
  readonly ragStatus:IRagStatusModel
}