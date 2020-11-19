import React from 'react';
import {Button} from 'react-bootstrap';
import IActionModel from '../../models/interfaces/IActionModel';

interface ActionRowProps {
  action: IActionModel,
  projectId: number,
  addActionToProjectHandler: (id: number) => void,
  removeActionFromProjectHandler: ( id: number) => void
}

class ManageProjectActionRow extends React.Component<ActionRowProps> {
  render() {
    const action = this.props.action;

    const project = action.projects.find(x=>x.id === this.props.projectId);
    const hasAction = project !== undefined && project !== null;

    return (
      <tr key={action.id}>
        <td>{action.name}</td>
        <td>{action.description}</td>
        <td>{action.progressStatus.description}</td>
        <td>{action.ragStatus.description}</td>
        <td>
          <Button variant="success" size="sm" disabled={hasAction} className="mr-1" onClick={() => this.props.addActionToProjectHandler(action.id)}><i className="fas fa-plus-circle"></i> Add</Button>
          <Button variant="danger" size="sm" disabled={!hasAction} onClick={() => this.props.removeActionFromProjectHandler(action.id)}><i className="fas fa-minus-circle"></i> Remove</Button>
        </td>
      </tr>
    )
  }
}

export default ManageProjectActionRow;