import React from 'react';
import Form from 'react-bootstrap/Form';
import Jumbotron from 'react-bootstrap/Jumbotron';
import Button from 'react-bootstrap/Button';

const SignupPage = (props)=>{
  return(
    <Jumbotron>
      <Form>
        <Form.Group>
          <Form.Control type="email" placeholder="email"/>
        </Form.Group>

        <Form.Group>
          <Form.Control type="password" placeholder="password"/>
        </Form.Group>

        <Form.Group>
          <Form.Control type="text" placeholder="Shop Name"/>
        </Form.Group>

        <Button>Submit</Button>

      </Form>

    </Jumbotron>
  )
}

export default SignupPage;