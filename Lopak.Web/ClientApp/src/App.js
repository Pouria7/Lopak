import React from 'react';
import { HashRouter as Router, Route, Switch, Redirect,BrowserRouter } from 'react-router-dom';
import Home from './components/pages/Home';
import Counter from './components/pages/Counter';
import FetchData from './components/pages/FetchData';
import RouteDashboardLayout from './components/RouteDashboardLayout';
import RouteHomeLayout from './components/RouteHomeLayout';
import {LoginPage} from './components/pages/LoginPage';


export default () => (
  <BrowserRouter>
            <Switch>
   {/*            <Route exact path="/">
                <Redirect to="/login" />
              </Route> */}
              <RouteHomeLayout exact path='/' component={Home} />
              <RouteDashboardLayout path='/counter' component={Counter} />
              <RouteHomeLayout path='/fetch-data/:startDateIndex?' component={FetchData} />
              <RouteDashboardLayout path='/login' component={LoginPage} />
              {/* <Route component={PageNotFound} /> */}
            </Switch>
   </BrowserRouter>

);



