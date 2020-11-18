import React from 'react';
import IProjectModel from '../../models/interfaces/IProjectModel';
import ProjectRow from './projectrow';

interface ProjectTableProps {
  projects: IProjectModel[]
}

class ProjectTable extends React.Component<ProjectTableProps> {
  constructor(props: ProjectTableProps) {
    super(props);
  }

  render() {
    const projects = this.props.projects;

    return (
      projects.map((project:IProjectModel) => (
        <table>
          <thead>
            <th>Name</th>
            <th>Description</th>
            <th>Status</th>
          </thead>
          <tbody>
            <ProjectRow project={project} />
          </tbody>
        </table>
      ))
    )
  }
}

export default ProjectTable;