import React, { Component } from 'react';
import {
  Button,
  Form,
  FormGroup,
  FormText,
  FormFeedback,
  Input,
  Label,
} from 'reactstrap';
import { Link } from 'react-router-dom';

export default class LoginForm extends Component {
  static displayName = LoginForm.name; 
  constructor(props) {
    super(props);

    this.state = {
      userName: '',
      password: '',
      formText: 'Your username is most likely your email address',
      validate: {
        emailState: '',
        isValid: false,
      },
    };
    this.handleChange = this.handleChange.bind(this);
  }

  handleChange = event => {
    const { target } = event;
    const { validate } = this.state;
    const { name, value } = target;
    if (!value) {
      validate.emailState = '';
      validate.isValid = false;
      this.setState({
        formText: 'Your username is most likely your email address',
        validate,
      });
    }
    this.setState({
      [name]: value,
      formText: '',
    });
  };

  validateEmail() {
    const emailRegex = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    const { userName, validate } = this.state;
    if (emailRegex.test(userName)) {
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
  };

  render() {
    const { userName, validate, formText, password } = this.state;
    return (
      <>
        <p className="text-muted text-center mb-4">
          Don't have an account yet?
          <Link to="/register"> Sign Up</Link>
        </p>
        <Form action="" id="login-form" onSubmit={e => this.handleSubmit(e)}>
          <FormGroup>
            <Label for="loginFormEmail" className="font-weight-bold">
              Username
            </Label>
            <Input
              type="email"
              name="userName"
              id="loginFormEmail"
              // className="is-invalid"
              required
              value={userName}
              valid={validate.emailState === 'has-success'}
              invalid={validate.emailState === 'has-danger'}
              onChange={e => {
                this.handleChange(e);
              }}
            />
            <FormFeedback>Invalid Username/Email Address</FormFeedback>
            <FormText>{formText}</FormText>
          </FormGroup>
          <FormGroup>
            <Label for="loginFormPassword" className="font-weight-bold">
              Password
            </Label>
            <Input
              type="password"
              name="password"
              id="loginFormPassword"
              // className="is-invalid"
              required
              value={password}
              onChange={e => this.handleChange(e)}
            />
            {/* <FormFeedback invalid>Invalid Password</FormFeedback> */}
          </FormGroup>
          <Button color="primary" className="btn-block mt-5">Sign In</Button>
        </Form>
        <div className="d-grid gap-2 mt-4 text-center">
          <Link to="/resetPassword">Forgot password?</Link>
        </div>
      </>
    );
  }
}
