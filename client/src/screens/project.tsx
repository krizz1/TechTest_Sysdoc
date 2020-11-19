import React from 'react';
import {GetProject} from '../services/DataService';
import Mappers from '../services/Mappers';
import ProjectTable from '../components/projects/projecttable';
import Loading from '../components/loading/loading';
import {Row, Col} from 'react-bootstrap';

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
      const projectData = Mappers.MapToProductModels(await GetProject(1));
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

    return (
      <>
        <h1>Projects</h1>
        <Row>
          <Col md={12}>
            {isLoading && <Loading />}
            {!isLoading && <ProjectTable projects={projectData} rowClickHandler={() => null} />}
          </Col>
        </Row>
        
      </>
    )
  }
}

export default Projects;
