import React from "react";
import { Button, Form, FormGroup, Label } from "reactstrap";

import { TASKS_API_URL } from "../../constants";

class TaskForm extends React.Component {
  state = {
    id: 0,
    title: "",
    completed: false,
  };

  componentDidMount() {
    if (this.props.taskItem) {
      const { id, title, completed } = this.props.taskItem;
      this.setState({ id, title, completed });
    }
  }

  onChange = (e) => {
    this.setState({ [e.target.name]: e.target.value });
  };

  submitEdit = (e) => {
    e.preventDefault();
    fetch(`${TASKS_API_URL}/${this.state.id}`, {
      method: "put",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({
        id: this.state.id,
        title: this.state.title,
        completed: true,
      }),
    })
      .then(() => {
        this.props.toggle();
        this.props.updateTaskIntoState(this.state.id);
      })
      .catch((err) => console.log(err));
  };

  render() {
    return (
      <Form onSubmit={this.submitEdit}>
        <FormGroup>
          <Label>
            Task# <span>{this.state.id === "" ? "" : this.state.id}</span>
          </Label>
        </FormGroup>
        <FormGroup>
          <Label>
            <span>{this.state.title === "" ? "" : this.state.title}</span>
          </Label>
        </FormGroup>
        <Button className="float-right" onClick={() => this.props.toggle()}>
          Close
        </Button>
        <Button className="float-right">Complete</Button>
      </Form>
    );
  }
}

export default TaskForm;
