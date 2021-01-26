import React, { Component } from 'react';
import { Container } from 'reactstrap';
import { NavMenu } from './NavMenu';
import LayoutStyles from './layout.module.css';

export class Layout extends Component {
  static displayName = Layout.name;

  render() {
    return (
        <div className={LayoutStyles.background}>
          <Container className="d-flex flex-column justify-content-center h-100">
          <div className={LayoutStyles.formBody}>
            <div className="col">
              <div className="text-center">
                <img
                  src="/images/profile.png"
                  alt="Remuner8"
                  className="img-fluid"
                />
                <p>
                  Don't have an account yet?
                  <a href="/">Sign Up</a>
                </p>
              </div>
            </div>
          </div>
          </Container>
        </div>
    );
  }
}
