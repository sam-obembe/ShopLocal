import React,{useState} from 'react';
import Form from 'react-bootstrap/Form';
import InputGroup from 'react-bootstrap/InputGroup';
import Jumbotron from 'react-bootstrap/Jumbotron';
import PropTypes from 'prop-types';
import './SearchStyles.css';


const Search = (props) =>{

  const [distance,setDistance] = useState(5);
  const [searchValue,setSearchValue] = useState("");
  const [location,setLocation] = useState({latitude:0,longitude:0});
  
  let getLocation = () =>{
    //let position = 0
    window.navigator.geolocation.getCurrentPosition(pos=>setLocation({latitude:pos.coords.latitude,longitude:pos.coords.longitude}));
  }

  let handleSearchInput = (e) =>{
    if(e.key.toLowerCase()==="enter"){
      submit(e);
      setSearchValue("");
    }
  }

  let submit =(e)=>{
    e.preventDefault();
    let searchObject = {searchValue,distance,location};
    console.log(searchObject);
  }

  return (
    <Jumbotron id="searchCard">
      <Form onSubmit={submit}>
        {/*Search bar */}
        <Form.Group controlId="searchBar"className="searchBar">
          <Form.Control type="search" placeholder = "Search product" onKeyUp = {(e)=>{handleSearchInput(e)}}/>
        </Form.Group>

        {/* Location bar */}
        <InputGroup id="locationSearch">
          <Form.Control type="text" id="location" placeholder="location"/>
          <InputGroup.Append>
            <InputGroup.Text onClick={()=>getLocation()}>Use Current Location</InputGroup.Text>
          </InputGroup.Append>
        </InputGroup>

        {/* Distance Filter */}
        <Form.Group controlId="filters">
          <Form.Label>Distance: </Form.Label>
          <Form.Control 
            type="range" 
            className="distanceFilter" 
            name="distance" 
            min="5" max="50" 
            defaultValue={5}
            custom
           
            onChange={ (e)=> setDistance(+e.target.value) }
          />
           <span style={{marginLeft:"5%"}}>{distance}</span>
        </Form.Group>
        <Form.Control type="submit" id="formSubmit"/>
      </Form>

     
    </Jumbotron>
  )
}

Search.defaulProps ={
  triggerSearch: PropTypes.func
}

export default Search