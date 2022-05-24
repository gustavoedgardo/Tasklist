import React, { Component, Fragment } from "react";
import { Button, Modal, ModalHeader, ModalBody } from "reactstrap";
import TaskForm from "./TaskForm";

class TaskModal extends Component {
  state = {
    modal: false,
  };

  toggle = () => {
    this.setState((previous) => ({
      modal: !previous.modal,
    }));
  };

  render() {
    let title = "Task View";
    return (
      <Fragment>
        <Button className="float-right" onClick={this.toggle}>
          View
        </Button>
        <Modal
          isOpen={this.state.modal}
          toggle={this.toggle}
          className={this.props.className}
        >
          <ModalHeader toggle={this.toggle}>{title}</ModalHeader>
          <ModalBody>
            <TaskForm
              addTaskToState={this.props.addTaskToState}
              updateTaskIntoState={this.props.updateTaskIntoState}
              toggle={this.toggle}
              taskItem={this.props.taskItem}
            />
          </ModalBody>
        </Modal>
      </Fragment>
    );
  }
}

export default TaskModal;
