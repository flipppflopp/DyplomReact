import React from 'react';
import '../Home/Home.css';
import Categories from "./categories/Categories"
import AdsList from './Ads/AdsList';

function Home(props) {

  return (
    <div>
      <h1>Advertisement</h1>
      <Categories/>
      <AdsList/>
    </div>
  );
}

export default Home;
