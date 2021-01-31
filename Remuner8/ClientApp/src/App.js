import React, { Component } from 'react';
import { Route, Switch } from 'react-router';
import Home from './pages/Home';
import LoginPage from './pages/Login';
import RegistrationPage from './pages/Register';
import './custom.css';

export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <div className="App">
        <Switch>
          <Route exact path="/" component={Home} />
          <Route path="/login" component={LoginPage} />
          <Route path="/register" component={RegistrationPage} />
        </Switch>
      </div>
    );
  }
}
