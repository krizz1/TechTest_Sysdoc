import React from 'react';
import {Row, Col} from 'react-bootstrap';

import {GetProjects,GetActions,AddActionToProject,RemoveActionFromProject} from '../services/DataService';
import Mappers from '../services/Mappers';

import IProjectModel from '../models/interfaces/IProjectModel';
import IActionModel from '../models/interfaces/IActionModel';

import ProjectTable from '../components/projects/projecttable';
import ActionTable from '../components/actions/actiontable';
import ManageProjectActionTable from '../components/actions/manageprojectactiontable';
import Loading from '../components/loading/loading';

interface IState {
  projectData: IProjectModel[],
  actionData: IActionModel[],
  addActionData: IActionModel[],
  actionHeading: string,
  addActionHeading: string,
  isLoadingProjects: boolean,
  isLoadingActions: boolean,
  error: null,
  editingProjectId: number
}

class Projects extends React.Component<IState> {
  state: IState;

  constructor(props: IState){
    super(props);

    this.state = {
      projectData: new Array<IProjectModel>(),
      actionData: new Array<IActionModel>(),
      addActionData: new Array<IActionModel>(),
      actionHeading: '',
      addActionHeading: '',
      isLoadingProjects: true,
      isLoadingActions: true,
      error: null,
      editingProjectId: 0
    };
  }

  componentDidMount()
  {
    this.LoadProjects();
  }

  async LoadProjects()
  {
    try {
      this.setState({isLoadingProjects: true});
      await this.loadProjectData();
    } catch(e) {
      this.setState({error: e});
    } finally {
      this.setState({isLoadingProjects: false});
    }
  }

  async LoadActions()
  {
    try {
      this.setState({isLoadingActions: true});
      const actionData = Mappers.MapToActionModels(await GetActions());
      this.setState({addActionData: actionData});
    } catch(e) {
      this.setState({error: e});
    } finally {
      this.setState({isLoadingActions: false});
    }
  }

  showProjectActions = (projectId:number) => {
    this.setState({addActionData: new Array<IActionModel>()});
    let project:IProjectModel = this.getProject(projectId);
    let actions:IActionModel[] = project != null ? project.actions : [];
    this.setState({actionHeading: (project != null ? project.name : '')});
    this.setState({actionData: actions});
  }

  showAddProjectActions = (projectId:number) => {
    this.setState({actionData: new Array<IActionModel>()});
    this.setState({actionHeading: ''});

    this.setState({editingProjectId: projectId});

    let project:IProjectModel = this.getProject(projectId);
    this.setState({addActionHeading: (project != null ? project.name : '')});
    this.LoadActions();
  }

  getProject(projectId:number){
    return this.state.projectData.find(x => x.id === projectId)!
  }

  async loadProjectData(){
    const projectData = Mappers.MapToProductModels(await GetProjects());
    this.setState({projectData});
  }

  async addActionToProject(actionId:number) {
      await AddActionToProject(this.state.editingProjectId,actionId);
      await this.LoadActions();
      await this.loadProjectData();
  }

  async removeActionFromProject(actionId:number) {
    await RemoveActionFromProject(this.state.editingProjectId,actionId);
    await this.LoadActions();
    await this.loadProjectData();
}

  render()
  {
    const { isLoadingProjects, projectData, actionData, error, actionHeading, addActionData, addActionHeading, editingProjectId } = this.state;
    if (error) return "Error loading Projects";

    return (
      <>
        <Row>
          <Col><h1>Projects</h1></Col>
        </Row>
        <Row>
          <Col md={12}>
            {isLoadingProjects && <Loading />}
            {!isLoadingProjects && <ProjectTable projects={projectData} showActionsHandler={(id:number) => this.showProjectActions(id)} addActionsHandler={(id:number) => this.showAddProjectActions(id)} />}
          </Col>
        </Row>
        <Row>
          <Col>{actionHeading !== '' && <h2>Actions for project: {actionHeading}</h2>}</Col>
        </Row>
        <Row>
          <Col>
            {actionData.length === 0 && actionHeading !== '' && <div>No actions assigned to this project.</div>}
            {actionData.length > 0 && (<ActionTable actions={actionData} showAssignedProjects={false}></ActionTable>)}
          </Col>
        </Row>
        <Row>
          <Col>{addActionData.length > 0 && <h2>Manage Actions for project: {addActionHeading}</h2>}</Col>
        </Row>
        <Row>
          <Col>
            {addActionData.length > 0 && (
              <ManageProjectActionTable
                actions={addActionData}
                projectId={editingProjectId}
                addActionToProjectHandler={(id) => this.addActionToProject(id)} 
                removeActionFromProjectHandler={(id) => this.removeActionFromProject(id)} />)}
          </Col>
        </Row>
      </>
    )
  }
}

export default Projects;
