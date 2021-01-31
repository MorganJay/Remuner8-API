import React, { Component } from 'react';
import { Button, Form, FormGroup, FormFeedback, Input } from 'reactstrap';
export default class PasswordSetup extends Component {
  back = e => {
    e.preventDefault();
    this.props.previousStep();
  };
  continue = e => {
    e.preventDefault();
    this.props.nextStep();
  };
  render() {
    const { data, errors, handleChange } = this.props;
    return (
      <>
        <h5 className="text-center mb-4 text-muted">Setup Password and Role</h5>
        <Form>
          <FormGroup>
            <Input
              id="password"
              name="password"
              type="password"
              value={data.password}
              min={8}
              max={32}
              invalid={errors.password ? true : false}
              required
              onChange={handleChange}
            />
            <FormFeedback>{errors.password}</FormFeedback>
          </FormGroup>

          <FormGroup>
            <Input
              id="confirmPassword"
              name="confirmPassword"
              type="password"
              value={data.confirmPassword}
              min={8}
              max={32}
              required
              invalid={errors.confirmPassword ? true : false}
              onChange={handleChange}
            />
            <FormFeedback>{errors.confirmPassword}</FormFeedback>
          </FormGroup>
          <FormGroup>
            <Button className="mt-5 btn-gray mx-2 ml-5" onClick={this.back}>
              BACK
            </Button>

            <Button
              color="primary"
              className="mt-5 btn-continue mx-2 text-center"
              onClick={this.continue}
            >
              CONTINUE
            </Button>
          </FormGroup>
        </Form>
      </>
    );
  }
}
