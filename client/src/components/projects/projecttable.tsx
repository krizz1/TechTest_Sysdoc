import React from 'react';
import IProjectModel from '../../models/interfaces/IProjectModel';
import ProjectRow from './projectrow';
import Table from 'react-bootstrap/Table';

interface ProjectTableProps {
  projects: IProjectModel[]
}

class ProjectTable extends React.Component<ProjectTableProps> {
  render() {
    const projects = this.props.projects;

    return (
        <Table striped bordered hover>
          <thead>
            <th>Name</th>
            <th>Description</th>
            <th>Status</th>
          </thead>
          <tbody>
           
          {projects.map((project:IProjectModel) => (
            <ProjectRow project={project} />
          ))}
          </tbody>
        </Table>
      )
  }
}

export default ProjectTable;