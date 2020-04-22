import React from 'react';
import Form from 'react-bootstrap/Form';
import Jumbotron from 'react-bootstrap/Jumbotron';
import Button from 'react-bootstrap/Button'
const LoginPage = (props) =>{
  return(
    <Jumbotron>
      <h2>Login</h2>
      <Form>
        <Form.Group>
          <Form.Control type="email" placeholder="Email"/>
        </Form.Group>

        <Form.Group>
          <Form.Control type="password" placeholder="Password"/>
        </Form.Group>

        <Button>Submit</Button>
        
      </Form>
    </Jumbotron>
  )
}

export default LoginPage;