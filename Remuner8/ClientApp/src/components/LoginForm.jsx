import React, { Component } from 'react';
import {
  Container,
  Form,
  FormGroup,
  Input,
  Label
} from 'reactstrap';
import LoginStyles from './login.module.css';

export default class LoginForm extends Component {
  static displayName = LoginForm.name;

  render() {
    return (
      <div className={LoginStyles.background}>
        <Container className="d-flex flex-column justify-content-center h-100">
          <div
            className={`row justify-content-center  ${LoginStyles.formBody}`}
          >
            <div className="col-9 col-sm-10 col-md-7 col-lg-6 col-xl-5">
              <div className={`${LoginStyles.rounded} card-bordered`}>
                <div className="card-body">
                  <div className="mb-4">
                    <div className="text-center">
                      <img
                        src="/images/default.png"
                        alt="Remuner8"
                        className="img-fluid"
                        width="150"
                      />
                      <p className="text-muted mb-4">
                        Don't have an account yet?
                        <a href="/"> Sign Up</a>
                      </p>
                    </div>
                    <div className="row justify-content-center">
                      <div className="col-11 col-sm-10 col-md-10 col-lg-10">
                        <Form
                          action="POST"
                          id="login-form"
                          className="form form-vertical"
                          required
                        >
                          <FormGroup>
                            <Label for="exampleEmail">Email</Label>
                            <Input
                              type="email"
                              name="email"
                              id="exampleEmail"
                              required
                            />
                          </FormGroup>
                          <FormGroup>
                            <Label for="examplePassword">Password</Label>
                            <Input
                              type="password"
                              name="password"
                              id="examplePassword"
                            />
                          </FormGroup>
                          <div className="d-grid gap-2 mt-5">
                            <button
                              className="btn btn-primary btn-block"
                              type="button"
                            >
                              Sign In
                            </button>
                          </div>
                        </Form>
                        <div className="d-grid gap-2 mt-4 text-center">
                          <a href="/">Forgot password?</a>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </Container>
      </div>
    );
  }
}
