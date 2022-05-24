import React, { Component } from 'react';
import { Col, Container, Row } from 'reactstrap';
import TasksListView from './TasksListView'
import {TASKS_API_URL} from '../constants';

class Home extends Component {
  state = {
    taskItems: []
  }

  componentDidMount() {
    this.getTaskItems();
  }

  getTaskItems = () => {
    fetch(TASKS_API_URL)
      .then(res => res.json())
      .then(res => this.setState({ taskItems: res }))
      .catch(err => console.log(err));
  }

  addTaskToState = taskItem => {
    this.setState(previous => ({
      taskItems: [...previous.taskItems, taskItem]
    }));
  }

  updateState = (id) => {
    this.getTaskItems();
  }

  deleteItemFromState = id => {
    const updated = this.state.taskItems.filter(item => item.id !== id);
    this.setState({ taskItems: updated })
  }

  render() {
    return <Container style={{ paddingTop: "100px" }}>
      <Row>
        <Col>
          <h3>Task list View</h3>
        </Col>
      </Row>
      <Row>
        <Col>
            {<TasksListView
            taskItems={this.state.taskItems}
            updateState={this.updateState}/>}
        </Col>
      </Row>
    </Container>;
  }
}

export default Home;
