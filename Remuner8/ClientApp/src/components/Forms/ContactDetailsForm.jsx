import React, { Component, useState } from 'react';
import {
  Button,
  Form,
  FormGroup,
  FormFeedback,
  Input,
  InputGroup,
  InputGroupAddon,
  InputGroupButtonDropdown,
  DropdownToggle,
  DropdownMenu,
  DropdownItem,
} from 'reactstrap';

class ContactDetailsForm extends Component {
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
        <h5 className="text-center text-muted mb-4">
          Enter Contact Information
        </h5>
        <Form>
          <FormGroup>
            <Input
              id="phoneNumber"
              name="phoneNumber"
              type="text"
              title="phoneNumber"
              required
              value={data.phoneNumber}
              onChange={handleChange}
            />
          </FormGroup>

          <FormGroup>
            <Input
              id="address"
              name="address"
              type="textarea"
              title="Address"
              placeholder="Residential Address"
              value={data.address}
              required
              invalid={errors.address ? true : false}
              onChange={handleChange}
            />
            <FormFeedback>{errors.address}</FormFeedback>
          </FormGroup>

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
        </Form>
      </>
    );
  }
}

export default ContactDetailsForm;
