import React from 'react';
import {GetActions} from '../services/DataService';
import Mappers from '../services/Mappers';
import ActionTable from '../components/actions/actiontable';
import Loading from '../components/loading/loading';
import {Row, Col} from 'react-bootstrap';

class Actions  extends React.Component{

  state = {
    actionData: [],
    isLoading: true,
    error: null
  };

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
