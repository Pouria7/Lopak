
import React from 'react';
import { Route } from 'react-router-dom'
import HomeLayout from './HomeLayout';

const RouteHomeLayout = ({ component: Component, ...rest }) => {
  console.log("RouteHomeLayout");
  //todo: logic for validate user 

  return (
    <Route {...rest} render={matchProps => (
      <HomeLayout>
        <Component {...matchProps} />
      </HomeLayout>
    )} />
  )
};

export default RouteHomeLayout;
