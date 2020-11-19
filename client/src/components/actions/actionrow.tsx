import React from 'react';
import IActionModel from '../../models/interfaces/IActionModel';

interface ActionRowProps {
  action: IActionModel,
  showAssignedProjects:boolean
}

class ActionRow extends React.Component<ActionRowProps> {
  render() {
    const action = this.props.action;

    return (
      <tr key={action.id}>
        <td>{action.name}</td>
        <td>{action.description}</td>
        <td>{action.progressStatus.description}</td>
        <td>{action.ragStatus.description}</td>
        {this.props.showAssignedProjects && <td>{action.projects != null ? action.projects.length: 0}</td>}
      </tr>
    )
  }
}

export default ActionRow;