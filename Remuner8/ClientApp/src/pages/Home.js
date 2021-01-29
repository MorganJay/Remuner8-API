import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import { NavMenu } from '../components/NavMenu';
import HomeStyles from './home.module.css';

export default class Home extends Component {
  static displayName = Home.name;

  render() {
    return (
      <div>
        <NavMenu />
        <h1 className={HomeStyles.heading}>Hello, world!</h1>
        <Link to="/login">Login</Link>
      </div>
    );
  }
}
