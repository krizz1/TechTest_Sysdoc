import React from 'react';
import IProjectModel from '../../models/interfaces/IProjectModel';

interface ProjectRowProps {
  project: IProjectModel,
  rowClickHandler: ( id: number) => void
}

class ProjectRow extends React.Component<ProjectRowProps> {

helloWorld = (id:number) =>
{
    this.props.rowClickHandler(id);
}

  render() {
    const project = this.props.project;

    return (
      <tr key={project.id}>
        <td>{project.name}</td>
        <td>{project.description}</td>
        <td>{project.progressStatus.description}</td>
        <td><button className="btn btn-primary" onClick={() => this.props.rowClickHandler(project.id)}>Show actions</button></td>
      </tr>
    )
  }
}

export default ProjectRow;