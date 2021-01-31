import React, { Component } from 'react';
import {
  Button,
  Form,
  FormGroup,
  FormFeedback,
  Input,
} from 'reactstrap';
class BankDetailsForm extends Component {
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
        <h5 className="text-center mb-4 text-muted">Enter Bank Information</h5>
        <Form>
          <FormGroup>
            <Input
              id="bank"
              name="bank"
              type="text"
              placeholder="Bank Name"
              required
              value={data.bank}
              onChange={handleChange}
            />
          </FormGroup>

          <FormGroup>
            <Input
              id="accountNumber"
              name="accountNumber"
              type="text"
              placeholder="Account Number"
              value={data.accountNumber}
              required
              invalid={errors.accountNumber ? true : false}
              onChange={handleChange}
            />
            <FormFeedback>{errors.firstName}</FormFeedback>
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
 
export default BankDetailsForm;
