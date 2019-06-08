import React from 'react';
import { Container } from 'reactstrap';
import HomeNavMenu from './features/HomeNavMenu';
import HomeFooter from './features/HomeFooter'
import './pages/Home.css';

export default props => (
  <div>
     <HomeNavMenu /> 
    <Container fluid>
      {props.children}
    </Container>
  <footer>
    <HomeFooter/>
  </footer>
  </div>
);
