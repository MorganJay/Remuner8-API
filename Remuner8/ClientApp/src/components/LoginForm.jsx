import React, { Component } from 'react';
import {
  Container,
  Form,
  FormGroup,
  FormText,
  FormFeedback,
  Input,
  Label,
} from 'reactstrap';
import LoginStyles from './login.module.css';

export default class LoginForm extends Component {
  static displayName = LoginForm.name;
  constructor(props) {
    super(props);
    this.state = {
      userName: '',
      password: '',
      formText: '',
      validate: {
        emailState: '',
        isValid: false,
      },
    };
    this.handleChange = this.handleChange.bind(this);
    // this.handleSubmit = this.handleSubmit.bind(this);
  }

  handleChange = event => {
    const { target } = event;
    const { validate } = this.state;
    const { name, value } = target;
    if (!value) {
      validate.emailState = '';
      validate.isValid = false;
      this.setState({ validate });
    }
    this.setState({
      [name]: value,
      formText: '',
    });
  };

  validateEmail() {
    const emailRegex = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    const { validate } = this.state;
    if (emailRegex.test(this.state.userName)) {
      validate.emailState = 'has-success';
      validate.isValid = true;
    } else {
      validate.emailState = 'has-danger';
    }
    this.setState({ validate });
  }

  handleSubmit = e => {
    e.preventDefault();
    this.validateEmail();
    console.log(`Email: ${this.state.userName}`);
    console.log(`Password: ${this.state.password}`);
  };

  render() {
    return (
      <div className={LoginStyles.background}>
        <Container className="d-flex flex-column justify-content-center h-100">
          <div
            className={`row justify-content-center  ${LoginStyles.formBody}`}
          >
            <div className="col-9 col-sm-10 col-md-7 col-lg-5 col-xl-4">
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
                          action=""
                          id="login-form"
                          onSubmit={e => this.handleSubmit(e)}
                        >
                          <FormGroup>
                            <Label
                              htmlFor="loginFormEmail"
                              className="font-weight-bold"
                            >
                              Username
                            </Label>
                            <Input
                              type="email"
                              name="userName"
                              id="loginFormEmail"
                              required
                              value={this.state.userName}
                              valid={
                                this.state.validate.emailState === 'has-success'
                              }
                              invalid={
                                this.state.validate.emailState === 'has-danger'
                              }
                              onChange={e => {
                                this.handleChange(e);
                              }}
                            />
                            <FormFeedback valid>
                              That's a tasty looking username you've got there.
                            </FormFeedback>
                            <FormFeedback>
                              Uh oh! Looks like there is an issue with your
                              username. Please enter a valid one.
                            </FormFeedback>
                            <FormText>
                              {this.state.formText &&
                                'Your username is most likely your email.'}
                            </FormText>
                          </FormGroup>
                          <FormGroup>
                            <Label
                              htmlFor="loginFormPassword"
                              className="font-weight-bold"
                            >
                              Password
                            </Label>
                            <Input
                              type="password"
                              name="password"
                              id="loginFormPassword"
                              required
                              value={this.state.password}
                              onChange={e => this.handleChange(e)}
                            />
                          </FormGroup>
                          <div className="d-grid gap-2 mt-5">
                            <input
                              className="btn btn-primary btn-block"
                              type="submit"
                              value="Sign In"
                              //onSubmit= {e => this.handleSubmit(e)}
                            />
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
