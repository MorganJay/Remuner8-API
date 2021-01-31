import React, { Component } from 'react';
import { Button, Row, Col } from 'reactstrap';

class ConfirmationPage extends Component {
  back = e => {
    e.preventDefault();
    this.props.previousStep();
  };
  continue = e => {
    e.preventDefault();
    this.props.nextStep();
  };

  render() {
    const {
      data,
      data: {
        firstName,
        lastName,
        otherName,
        email,
        address,
        phoneNumber,
        accountNumber,
        bank,
        gender,
        maritalStatus,
        role,
        dateEmployed,
        dateOfBirth,
        state,
        country,
      },
    } = this.props;
    return (
      <>
        <h5 className="text-center mb-4 text-muted">Confirm Your Details</h5>
        <ul className="list-unstyled mb-0">
          <li className="mb-2">First Name: {firstName}</li>
          <li className="mb-2">Last Name: {lastName}</li>
          <li className="mb-2">Other Name: {otherName}</li>
          <li className="mb-2">Email Address: {email}</li>
          <li className="mb-2">Phone Number: {phoneNumber}</li>
          <li className="mb-2">Address: {address}</li>
          <li className="mb-2">Gender: {gender}</li>
          <li className="mb-2">Marital Status: {maritalStatus}</li>
          <li className="mb-2">Date of Birth: {dateOfBirth}</li>
          <li className="mb-2">State: {state}</li>
          <li className="mb-2">Country: {country}</li>
          <li className="mb-2">Bank: {bank}</li>
          <li className="mb-2">Account Number: {accountNumber}</li>
          <li className="mb-2">Date Employed: {dateEmployed}</li>
          <li className="mb-2">Role: {role}</li>
        </ul>
        {/* <Row>
          <Col>
            <li>
              First Name <p>{firstName}</p>
            </li>
          </Col>
          <Col>
            <li>
              Last Name <p>{lastName}</p>
            </li>
          </Col>
          <Col>
            <li>
              Other Name <p>{otherName}</p>
            </li>
          </Col>
        </Row>
        <Row>
          <Col>
            <li>
              Email Address <p>{email}</p>
            </li>
          </Col>
          <Col>
            <li>
              Phone Number <p>{phoneNumber}</p>
            </li>
          </Col>
          <Col>
            <li>
              Address <p>{address}</p>
            </li>
          </Col>
        </Row>
        <Row>
          <Col>
            <li>
              Gender <p>{gender}</p>
            </li>
          </Col>
          <Col>
            <li>
              Marital Status <p>{maritalStatus}</p>
            </li>
          </Col>
          <Col>
            <li>
              Date of Birth <p>{dateOfBirth}</p>
            </li>
          </Col>
        </Row>
        <Row>
          <Col>
            <li>
              State <p>{state}</p>
            </li>
          </Col>
          <Col>
            <li>
              Country <p>{country}</p>
            </li>
          </Col>
          <Col>
            <li>
              Bank <p>{bank}</p>
            </li>
          </Col>
        </Row>
        <Row>
          <Col>
            <li>
              Account Number <p>{accountNumber}</p>
            </li>
          </Col>
          <Col>
            <li>
              Date Employed <p>{dateEmployed}</p>
            </li>
          </Col>
          <Col>
            <li>
              Role <p>{role}</p>
            </li>
          </Col>
        </Row> */}
        {console.log(data)}

        <Button className="btn-gray" onClick={this.back}>
          BACK
        </Button>

        <Button
          color="primary"
          className="btn-continue text-center"
          onClick={this.continue}
        >
          CONFIRM AND CONTINUE
        </Button>
      </>
    );
  }
}

export default ConfirmationPage;
