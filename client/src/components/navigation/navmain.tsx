import React from 'react';
import {Navbar, Nav} from 'react-bootstrap';

const NavMain = () => {
    return (
      <Navbar>
        <Navbar.Brand href="/">Sysdoc Tech Test</Navbar.Brand>
        <Nav className="mr-auto">
          <Nav.Link href="/projects">Projects</Nav.Link>
          <Nav.Link href="/actions">Actions</Nav.Link>
        </Nav>
      </Navbar>
    )
}

export default NavMain;