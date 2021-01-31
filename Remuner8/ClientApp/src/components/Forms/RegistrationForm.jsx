import React, { Component } from 'react';
import BankDetailsForm from './BankDetailsForm';
import ContactDetailsForm from './ContactDetailsForm';
import PasswordSetup from './PasswordSetup';
import PersonalDetailsForm from './PersonalDetailsForm';
import UserDetailsForm from './UserDetailsForm';
import ConfirmationPage from "./ConfirmationPage";
import SuccessPage from './SuccessPage';

class RegistrationForm extends Component {
  constructor(props) {
    super(props);
    this.state = {
      step: 3,
      data: {
        email: '',
        firstName: '',
        otherName: '',
        lastName: '',
        dateOfBirth: '',
        maritalStatus: '',
        gender: '',
        state: '',
        country: '',
        phoneNumber: '',
        address: '',
        dateEmployed: '',
        bank: '',
        accountNumber: '',
        role: '',
        password: '',
        confirmPassword: '',
      },
      errors: {},
    };
    //   initialState = () => ({  });
  }

  // handle data fields state chan2ge
  handleChange = e => {
    console.log(e.target.value);
    this.setState({
      data: {
        ...this.state.data,
        [e.target.name]: e.target.value,
      },
      errors: {
        ...this.state.errors,
        [e.target.name]: '',
      },
    });
  };

  previousStep = () => {
    const { step } = this.state;
    this.setState({
      step: step - 1,
    });
  };

  nextStep = () => {
    const { step } = this.state;
    this.setState({
      step: step + 1,
    });
  };

  render() {
    const { data, errors, step } = this.state;
    const values = data;

    switch (step) {
      case 1:
        return (
          <UserDetailsForm
            nextStep={this.nextStep}
            handleChange={this.handleChange}
            data={values}
            errors={errors}
          />
        );

      case 2:
        return (
          <PersonalDetailsForm
            previousStep={this.previousStep}
            nextStep={this.nextStep}
            handleChange={this.handleChange}
            data={values}
            errors={errors}
          />
        );

      case 3:
        return (
          <ContactDetailsForm
            previousStep={this.previousStep}
            nextStep={this.nextStep}
            handleChange={this.handleChange}
            data={values}
            errors={errors}
          />
        );

      case 4:
        return (
          <BankDetailsForm
            previousStep={this.previousStep}
            nextStep={this.nextStep}
            handleChange={this.handleChange}
            data={values}
            errors={errors}
          />
        );

      case 5:
        return (
          <PasswordSetup
            previousStep={this.previousStep}
            nextStep={this.nextStep}
            handleChange={this.handleChange}
            data={values}
            errors={errors}
          />
        );

      case 6:
        return (
          <ConfirmationPage
            previousStep={this.previousStep}
            nextStep={this.nextStep}
            data={values}
          />
        );

      case 7:
        return (
          <SuccessPage
            handleChange={this.handleChange}
            data={values}
            errors={errors}
          />
        );
      default:
        break;
    }
  }
}

export default RegistrationForm;
