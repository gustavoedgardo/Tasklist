import React, { Component } from 'react';
import logo from '../../src/logo.svg';
import {
    Navbar,
    NavbarBrand,
    NavbarToggler
} from 'reactstrap';

class AppHeader extends Component {

    state = {
        isOpen: false
    };
    toggle = this.toggle.bind(this);

    toggle() {
        this.setState({
            isOpen: !this.state.isOpen
        })
    }

    render() {
        return <Navbar color="dark" dark expand="md">
            <NavbarBrand href="/">
            <img src={logo} width="128" className="d-inline-block align-top" alt="logo" />
            </NavbarBrand>
            <NavbarToggler onClick={this.toggle} />
        </Navbar>;
    }
}

export default AppHeader;