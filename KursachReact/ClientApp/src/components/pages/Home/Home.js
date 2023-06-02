import React, { useEffect } from 'react';
import API_URL from '../../../variables';
import '../Home/Home.css';
import { Link, NavLink } from 'react-router-dom';
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
