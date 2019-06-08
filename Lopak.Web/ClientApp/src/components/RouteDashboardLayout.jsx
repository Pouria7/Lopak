
import React from 'react';
import { Route } from 'react-router-dom'
import DashboardLayout from './DashboardLayout';

const RouteDashboardLayout = ({ component: Component, ...rest }) => {
  console.log("RouteDashboardLayout");
  //todo: logic for validate user 

  return (
    <Route {...rest} render={matchProps => (
      <DashboardLayout>
        <Component {...matchProps} />
      </DashboardLayout>
    )} />
  )
};

export default RouteDashboardLayout;
