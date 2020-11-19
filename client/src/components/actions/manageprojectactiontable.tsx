import React from 'react';
import IActionModel from '../../models/interfaces/IActionModel';
import ManageProjectActionRow from './manageprojectactionrow';
import Table from 'react-bootstrap/Table';

interface ActionTableProps {
  actions: IActionModel[],
  projectId: number,
  addActionToProjectHandler: ( id: number) => void
  removeActionFromProjectHandler: ( id: number) => void
}

class ManageProjectActionTable extends React.Component<ActionTableProps> {
  render() {
    const actions = this.props.actions;

    return (
      <Table striped bordered hover size="sm">
        <thead>
          <tr>
            <th>Name</th>
            <th>Description</th>
            <th>Action Status</th>
            <th>Rag Status</th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          {actions.map((action:IActionModel, index:number) => (
            <ManageProjectActionRow
              key={index}
              action={action}
              projectId={this.props.projectId}
              addActionToProjectHandler={(id) => this.props.addActionToProjectHandler(id)}
              removeActionFromProjectHandler={(id) => this.props.removeActionFromProjectHandler(id)} />
          ))}
        </tbody>
      </Table>
    )
  }
}

export default ManageProjectActionTable;