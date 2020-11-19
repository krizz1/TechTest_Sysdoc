import React from 'react';
import IProjectModel from '../../models/interfaces/IProjectModel';
import ProjectRow from './projectrow';
import Table from 'react-bootstrap/Table';

interface ProjectTableProps {
  projects: IProjectModel[],
  showActionsHandler: (id: number) => void,
  addActionsHandler: ( id: number) => void
}

class ProjectTable extends React.Component<ProjectTableProps> {
  render() {
    const projects = this.props.projects;

    return (
      <Table striped bordered hover>
        <thead>
          <tr>
            <th>Name</th>
            <th>Description</th>
            <th>Project Status</th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          
        {projects.map((project:IProjectModel, index: number) => (
          <ProjectRow
            key={index} 
            project={project} 
            showActionsHandler={(id:number) => this.props.showActionsHandler(id)} 
            addActionsHandler={(id:number) => this.props.addActionsHandler(id)} />
        ))}
        </tbody>
      </Table>
    )
  }
}

export default ProjectTable;