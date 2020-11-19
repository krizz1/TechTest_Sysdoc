import ProjectModel from '../models/ProjectModel';
import ActionModel from '../models/ActionModel';

class Mappers{
  static MapToProductModels(items:any)
  { 
    return items.map((item: any) => {
      return new ProjectModel(item.id,item.name,item.description,item.progressStatus,item.actions);
    });
  }

  static MapToActionModels(items:any)
  { 
    return items.map((item: any) => {
      return new ActionModel(item.id,item.name,item.description,item.progressStatus,item.ragStatus,item.projects);
    });
  }
}

export default Mappers;
