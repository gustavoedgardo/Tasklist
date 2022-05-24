import React, { Component } from "react";
import { Toast, ToastHeader, ToastBody } from "reactstrap";
import ToastContainer from "react-bootstrap/ToastContainer";
import TaskModal from "./form/TaskModal";

class TasksListView extends Component {
  render() {
    const taskItems = this.props.taskItems;
    return (
      <ToastContainer className="p-3" position="middle-bottom">
        {!taskItems || taskItems.length <= 0 ? (
          <div align="center">
            <b>No Tasks yet</b>
          </div>
        ) : (
          taskItems.map((item) => (
            <Toast className="d-inline-block m-1" key={item.id}>
              <ToastHeader>Task #{item.id}</ToastHeader>
              <ToastBody>
                {item.title}
                <br />
                {!item.completed ? (
                  <TaskModal
                    taskItem={item}
                    updateTaskIntoState={this.props.updateState}
                  />
                ):(<br />)}
              </ToastBody>
            </Toast>
          ))
        )}
      </ToastContainer>
    );
  }
}

export default TasksListView;
