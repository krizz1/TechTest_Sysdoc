import React from 'react';
import IProjectModel from '../../models/interfaces/IProjectModel';

interface ProjectRowProps {
  project: IProjectModel,
  showActionsHandler: ( id: number) => void,
  addActionsHandler: ( id: number) => void
}

class ProjectRow extends React.Component<ProjectRowProps> {
  render() {
    const project = this.props.project;

    return (
      <tr key={project.id}>
        <td>{project.name}</td>
        <td>{project.description}</td>
        <td>{project.progressStatus.description}</td>
        <td>
          <button className="btn btn-primary btn-sm mr-1" onClick={() => this.props.showActionsHandler(project.id)}><i className="far fa-eye"></i> Show actions</button>
          <button className="btn btn-primary btn-sm" onClick={() => this.props.addActionsHandler(project.id)}><i className="fas fa-tasks"></i> Manage actions</button>
        </td>
      </tr>
    )
  }
}

export default ProjectRow;