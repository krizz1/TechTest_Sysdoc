import React from 'react';
import {GetProjects} from './services/DataService';
import Mappers from './services/Mappers';
import ProjectTable from './components/projects/projecttable';

class Projects  extends React.Component{

  state = {
    projectData: [],
    isLoading: true,
    error: null
  };

  componentDidMount()
  {
    this.LoadProjects();
  }

  async LoadProjects()
  {
    try {
      this.setState({isLoading: true});
      const projectData = Mappers.MapToProductModels(await GetProjects());
      this.setState({projectData});
    } catch(e) {
      this.setState({error: e});
    } finally {
      this.setState({isLoading: false});
    }
  }

  render()
  {
    const { isLoading, projectData, error } = this.state;



    if (error) return "Error loading Projects";
    return isLoading ? "Loading..." : <ProjectTable projects={projectData} />
  }

}

export default Projects;
