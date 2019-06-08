import React from 'react';
import { Container } from 'reactstrap';
import NavMenu from './features/NavMenu';

export default props => (
  <div>
    <NavMenu />
    <Container fluid>
      {props.children}
    </Container>
  </div>
);
