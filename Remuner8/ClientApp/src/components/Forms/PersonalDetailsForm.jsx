import React, { Component } from 'react';
import {
  Button,
  Form,
  FormGroup,
  FormFeedback,
  Input,
  Label,
  Col,
  Row,
} from 'reactstrap';

export default class PersonalDetailsForm extends Component {
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
        <h5 className="text-center text-muted mb-4">Enter Personal Details</h5>
        <Form>
          <FormGroup row className="align-items-center">
            <Col sm={4} className="pr-0 text-center">
              <Label for="dateOfBirth" className="mb-0">
                Date of Birth
              </Label>
            </Col>
            <Col sm={8} className="">
              <Input
                id="dateOfBirth"
                name="dateOfBirth"
                type="date"
                required
                value={data.dateOfBirth}
                onChange={handleChange}
              />
            </Col>
          </FormGroup>

          <FormGroup row>
            <Col sm={5}>
              <Input
                id="gender"
                name="gender"
                type="select"
                value={data.gender}
                required
                invalid={errors.gender ? true : false}
                onChange={handleChange}
              >
                <option value="">Gender</option>
                <option value="Male">Male</option>
                <option value="Female">Female</option>
              </Input>
              <FormFeedback>{errors.gender}</FormFeedback>
            </Col>
            <Col sm={7}>
              <Input
                id="country"
                name="country"
                type="select"
                value={data.country}
                required
                invalid={errors.country ? true : false}
                onChange={handleChange}
              >
                <option value="">Nationality</option>
              </Input>
              <FormFeedback>{errors.country}</FormFeedback>
            </Col>
          </FormGroup>

          <FormGroup row>
            <Col sm={5}>
              <Input
                id="state"
                name="state"
                type="select"
                value={data.state}
                required
                invalid={errors.state ? true : false}
                onChange={handleChange}
              >
                <option value="">State</option>
              </Input>
              <FormFeedback>{errors.state}</FormFeedback>
            </Col>
            <Col sm={7}>
              <Input
                id="maritalStatus"
                name="maritalStatus"
                type="select"
                value={data.maritalStatus}
                required
                invalid={errors.maritalStatus ? true : false}
                onChange={handleChange}
              >
                <option value="">Marital Status</option>
                <option>Single</option>
                <option>Married</option>
                <option>Divorced</option>
              </Input>
              <FormFeedback>{errors.maritalStatus}</FormFeedback>
            </Col>
          </FormGroup>
          <Row className="justify-content-around">
            <Button className="mt-3 btn-gray mx-2 ml-10" onClick={this.back}>
              BACK
            </Button>

            <Button
              color="primary"
              className="mt-3 btn-continue mx-2 text-center"
              onClick={this.continue}
            >
              CONTINUE
            </Button>
          </Row>
        </Form>
      </>
    );
  }
}
