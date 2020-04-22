import React from 'react';
import {Switch,Route} from 'react-router-dom';
import Landing from './Pages/LandingPage/Landing';
import LoginPage from './Pages/LoginPage/LoginPage';
import SignupPage from './Pages/SignupPage/SignupPage';


const Routes = () =>{
  return(
    <Switch>
      <Route exact path="/" component = {Landing}/>
      <Route exact path="/login" component={LoginPage}/>
      <Route exact path="/signup" component={SignupPage}/>
      
    </Switch>
  )
}

export default Routes();