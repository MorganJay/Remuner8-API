import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import Container from 'reactstrap/lib/Container';

import './custom.css';

export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <div className="App">
          <Layout>
            <Route exact path="/" component={Home} />
            {/* <Route path='/counter' component={Counter} />
       <Route path='/fetch-data' component={FetchData} /> */}
          </Layout>
      </div>
    );
  }
}
