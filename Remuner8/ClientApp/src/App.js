import React, { Component } from 'react';
import { Route } from 'react-router';
import { Home } from './components/Home';
import LoginForm from './components/LoginForm';
import './custom.css';

export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <div className="App">
        <LoginForm>
          <Route exact path="/" component={Home} />
          {/* <Route path='/counter' component={Counter} />
          <Route path='/fetch-data' component={FetchData} /> */}
        </LoginForm>
      </div>
    );
  }
}
