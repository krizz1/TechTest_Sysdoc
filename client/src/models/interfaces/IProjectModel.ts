import IProgressStatusModel from './IProgressStatusModel';

export default interface IProjectModel {
  readonly id:number,
  readonly name:string,
  readonly description:string,
  readonly progressStatus:IProgressStatusModel
}