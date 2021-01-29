import React from 'react';
import LoginStyles from './login.module.css';
import { Container } from 'reactstrap';
import LoginForm from '../components/LoginForm';
import { Link } from 'react-router-dom';

const Login = () => {
  return (
    <div className={LoginStyles.background}>
      <Container className="d-flex flex-column justify-content-center h-100">
        <div className={`row justify-content-center  ${LoginStyles.formBody}`}>
          <div className="col-9 col-sm-10 col-md-7 col-lg-5 col-xl-4">
            <div className={`${LoginStyles.rounded} card-bordered`}>
              <div className="card-body">
                <div className="mb-4">
                  <div className="text-center">
                    <Link to="/">
                      <img
                        src="/images/default.png"
                        alt="Remuner8"
                        className="img-fluid"
                        width="130"
                      />
                    </Link>
                  </div>
                  <div className="row justify-content-center">
                    <div className="col-11 col-sm-10 col-md-10 col-lg-10">
                      <LoginForm />
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
};

export default Login;
