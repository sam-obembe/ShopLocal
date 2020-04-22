import React from 'react';
import BSNavbar from 'react-bootstrap/Navbar';
import BSNav from 'react-bootstrap/Nav';
import {Link} from 'react-router-dom';
import './Navbar.css';

const Navbar = () =>{
  return (
    <div>
      <BSNavbar>
      <Link to="/"><BSNavbar.Brand className = "dark-brand">ShopLocal</BSNavbar.Brand></Link>
        <BSNavbar.Collapse className="justify-content-end">
          <BSNav>
            <Link to="/login" className="nav-link dark-nav-link " role="button">ShopLogin</Link>
            <Link to="/signup" className="nav-link dark-nav-link" role="button">Shop Signup</Link>
          </BSNav>
        </BSNavbar.Collapse>
      </BSNavbar>
    </div>
  );
}

export default Navbar