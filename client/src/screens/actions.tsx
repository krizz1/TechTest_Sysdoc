import React from 'react';
import {Row, Col} from 'react-bootstrap';

import {GetActions} from '../services/DataService';
import Mappers from '../services/Mappers';

import IActionModel from '../models/interfaces/IActionModel';

import ActionTable from '../components/actions/actiontable';
import Loading from '../components/loading/loading';

interface IState {
  actionData: IActionModel[],
  isLoading: boolean,
  error: null
}

class Actions extends React.Component<IState> {
  state: IState;

  constructor(props: IState){
    super(props);

    this.state = {
      actionData: new Array<IActionModel>(),
      isLoading: true,
      error: null
    };
  }

  componentDidMount()
  {
    this.LoadProjects();
  }

  async LoadProjects()
  {
    try {
      this.setState({isLoading: true});
      const actionData = Mappers.MapToActionModels(await GetActions());
      this.setState({actionData});
    } catch(e) {
      this.setState({error: e});
    } finally {
      this.setState({isLoading: false});
    }
  }

  render()
  {
    const { isLoading, actionData, error } = this.state;
    if (error) return "Error loading Projects";

    return (
      <>
        <h1>Actions</h1>
        <Row>
          <Col md={12}>
            {isLoading && <Loading />}
            {!isLoading && <ActionTable actions={actionData} showAssignedProjects={true} />}
          </Col>
        </Row>
      </>
    )
  }
}

export default Actions;
