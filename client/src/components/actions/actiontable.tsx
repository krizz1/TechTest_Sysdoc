import React from 'react';
import IActionModel from '../../models/interfaces/IActionModel';
import ActionRow from './actionrow';
import Table from 'react-bootstrap/Table';

interface ActionTableProps {
  actions: IActionModel[],
  showAssignedProjects:boolean
}

class ActionTable extends React.Component<ActionTableProps> {
  render() {
    const actions = this.props.actions;

    return (
        <Table striped bordered hover>
          <thead>
            <th>Name</th>
            <th>Description</th>
            <th>Action Status</th>
            <th>Rag Status</th>
            {this.props.showAssignedProjects && <th>Assigned to Projects</th>} 
          </thead>
          <tbody>
           
          {actions.map((action:IActionModel) => (
            <ActionRow action={action} showAssignedProjects={this.props.showAssignedProjects} />
          ))}
          </tbody>
        </Table>
      )
  }
}

export default ActionTable;