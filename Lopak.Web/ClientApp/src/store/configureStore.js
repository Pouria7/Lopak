import { applyMiddleware, combineReducers, compose, createStore } from 'redux';
import thunk from 'redux-thunk';
import { routerReducer, routerMiddleware } from 'react-router-redux';
import { createLogger } from 'redux-logger';
import * as Counter from './Counter';
import * as WeatherForecasts from './WeatherForecasts';
import { authentication } from './authentication';
import { users } from './users';
import { alert } from './alert';

export default function configureStore (history, initialState) {
  const reducers = {
    counter: Counter.reducer,
    weatherForecasts: WeatherForecasts.reducer,
    authentication,
    users,
    alert
  };

  const loggerMiddleware = createLogger();

  const middleware = [
    thunk,
    routerMiddleware(history)
  ];

  // In development, use the browser's Redux dev tools extension if installed
  const enhancers = [];
  const isDevelopment = process.env.NODE_ENV === 'development';
  if (isDevelopment && typeof window !== 'undefined' && window.devToolsExtension) {
    enhancers.push(window.devToolsExtension());
  }

  const rootReducer = combineReducers({
    ...reducers,
    routing: routerReducer
  });

  return createStore(
    rootReducer,
    initialState,
    compose(applyMiddleware(...middleware), ...enhancers)
  );
}
