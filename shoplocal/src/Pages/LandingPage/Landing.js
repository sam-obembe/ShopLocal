import React from 'react'
import Search from '../../Components/SearchComponent/Search'
import './LandingStyles.css'

const Landing = () =>{
  return (
    <section>
      <div className="landingMain">
        <h1>ShopLocal</h1>
        <Search />
      </div>
    </section>
  );
}

export default Landing