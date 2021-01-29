import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import { NavMenu } from '../components/NavMenu';

export default class Home extends Component {
  static displayName = Home.name;

  render() {
    return (
      <div>
        <NavMenu />
        <h1>Hello, world!</h1>
        <Link to="/login">Login</Link>
      </div>
    );
  }
}
