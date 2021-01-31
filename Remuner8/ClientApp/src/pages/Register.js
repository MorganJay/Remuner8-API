import React from 'react';
import { Link } from 'react-router-dom';
import { Container, Row, Col } from 'reactstrap';
import RegistrationForm from '../components/Forms/RegistrationForm';
import Styles from './login.module.css';

const RegistrationPage = () => {
  return (
    <div className={Styles.background}>
      <Container className="d-flex flex-column justify-content-center h-100 py-3">
        <Row className={`justify-content-center  ${Styles.formBody}`}>
          <Col sm={8} md={7} lg={5} xl={5} className="col-8">
            <div className={Styles.rounded}>
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
                  <Row className="justify-content-center">
                    <Col sm={11} md={11} lg={11}className="col-11">
                      <RegistrationForm />
                    </Col>
                  </Row>
                </div>
              </div>
            </div>
          </Col>
        </Row>
      </Container>
    </div>
  );
};

export default RegistrationPage;
