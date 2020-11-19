import IProgressStatusModel from './IProgressStatusModel';
import IActionModel from './IActionModel';

export default interface IProjectModel {
  readonly id:number,
  readonly name:string,
  readonly description:string,
  readonly progressStatus:IProgressStatusModel,
  readonly actions:IActionModel[]
}