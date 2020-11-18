import React from 'react';
import IProjectModel from '../../models/interfaces/IProjectModel';

interface ProjectRowProps {
  project: IProjectModel
}

class ProjectRow extends React.Component<ProjectRowProps> {
  render() {
    const project = this.props.project;

    return (
      <tr key={project.id}>
        <td>{project.name}</td>
        <td>{project.description}</td>
        <td>{project.progressStatus.description}</td>
      </tr>
    )
  }
}

export default ProjectRow;