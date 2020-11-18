import Project from '../models/ProjectModel';

class Mappers{
  static MapToProductModels(items:any)
  { 
    return items.map((item: any) => {
      return new Project(item.id,item.name,item.description,item.progressStatus);
    });
  }
}

export default Mappers;
