import React, { Component } from 'react';
import {
  Form,
  FormGroup,
  FormText,
  FormFeedback,
  Input,
  Label,
} from 'reactstrap';

export default class LoginForm extends Component {
  static displayName = LoginForm.name;
  constructor(props) {
    super(props);
    this.state = {
      userName: '',
      password: '',
      formText: 'Your username is most likely your email.',
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
        formText: 'Your username is most likely your email.',
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
    // if (this.state.validate.isValid){
    //   this.setState({
    //     userName: '', password: ''
    //   })
    // }
  };

  render() {
    return (
      <>
        <p className="text-muted text-center mb-4">
          Don't have an account yet?
          <a href="/"> Sign Up</a>
        </p>
        <Form action="" id="login-form" onSubmit={e => this.handleSubmit(e)}>
          <FormGroup>
            <Label htmlFor="loginFormEmail" className="font-weight-bold">
              Username
            </Label>
            <Input
              type="email"
              name="userName"
              id="loginFormEmail"
              required
              value={this.state.userName}
              valid={this.state.validate.emailState === 'has-success'}
              invalid={this.state.validate.emailState === 'has-danger'}
              onChange={e => {
                this.handleChange(e);
              }}
            />
            <FormFeedback valid></FormFeedback>
            <FormFeedback>Invalid Username/Email Address</FormFeedback>
            <FormText>{this.state.formText}</FormText>
          </FormGroup>
          <FormGroup>
            <Label htmlFor="loginFormPassword" className="font-weight-bold">
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
      </>
    );
  }
}
