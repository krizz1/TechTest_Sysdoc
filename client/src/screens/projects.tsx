import React from 'react';
import {GetProjects} from '../services/DataService';
import Mappers from '../services/Mappers';
import ProjectTable from '../components/projects/projecttable';
import ActionTable from '../components/actions/actiontable';
import Loading from '../components/loading/loading';
import {Row, Col} from 'react-bootstrap';
import IProjectModel from '../models/interfaces/IProjectModel';
import IActionModel from '../models/interfaces/IActionModel';

class Projects  extends React.Component{

  state = {
    projectData: [],
    actionData: [],
    actionHeading: '',
    isLoading: true,
    error: null,

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

  showProjectActions = (id:number) => {
    let project:IProjectModel = this.state.projectData.find(x => x['id'] === id)!;
    let actions:IActionModel[] = project != null ? project.actions : [];
    this.setState({actionHeading: (project != null ? project.name : '')});
    this.setState({actionData: actions});
  }

  render()
  {
    const { isLoading, projectData, error } = this.state;
    if (error) return "Error loading Projects";

    return (
      <>
        <Row>
          <Col><h1>Projects</h1></Col>
        </Row>
        <Row>
          <Col md={12}>
            {isLoading && <Loading />}
            {!isLoading && <ProjectTable projects={projectData} rowClickHandler={(id:number) => this.showProjectActions(id)} />}
          </Col>
        </Row>
        <Row>
        <Col>{this.state.actionHeading !== '' && <h2>Actions for project: {this.state.actionHeading}</h2>}</Col>
        </Row>
        <Row>
          <Col>
            {this.state.actionData.length === 0 && this.state.actionHeading === '' && <div>Select a project to view action data...</div>}
            {this.state.actionData.length === 0 && this.state.actionHeading !== '' && <div>No actions assigned to this project.</div>}
            {this.state.actionData.length > 0 && (<ActionTable actions={this.state.actionData} showAssignedProjects={false}></ActionTable>)}
          </Col>
        </Row>
      </>
    )
  }
}

export default Projects;
