import React from 'react';
import ReactDOM from 'react-dom';

import { Provider } from 'react-redux';
import { createStore, compose, applyMiddleware } from 'redux';
import thunk from 'redux-thunk';
import { BrowserRouter as Router, Route, Redirect } from 'react-router-dom';

import CreateVehicleContainer from './createvehicle/CreateVehicleContainer';
import ViewVehicleContainer from './viewvehicle/ViewVehicleContainer';
import VehicleReducer from './reducers/VehicleReducer';
import Layout from './layout/Layout';
import Routes from './routes';

import './index.css';
import 'bootstrap/dist/css/bootstrap.css';

const composeEnhancer = window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__ || compose;

const store = createStore(
  VehicleReducer, 
  composeEnhancer(applyMiddleware(thunk)));

const routing = (
  <Provider store={store}>
    <Router>
      <Route
        exact
        name="home"
        render={props => (
          <Layout {...props}>
            <ViewVehicleContainer {...props} />
          </Layout>  
        )}
        path={Routes.HomePage.path}
      />
      <Route
        exact
        render={props => (
          <Layout {...props}>
            <CreateVehicleContainer {...props} />
          </Layout>
        )}
        path={Routes.VehiclePage.path}        
      />
      <Redirect 
        from="/"
        to="home"
      />
    </Router>
  </Provider>
)

ReactDOM.render(
  routing, document.getElementById('root'))