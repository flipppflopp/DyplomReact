import React, { useEffect, useState } from 'react';
import SmallAd from './SmallAd';
import './AdsList.css';
import { connect } from 'react-redux'
import { Form, FormControl, Button } from 'react-bootstrap';

function AdsList(props) {
  const [ads, setAds] = useState([]);

  const [searchPreQuery, setSearchPreQuery] = useState('');
  const [searchQuery, setSearchQuery] = useState('');


  useEffect(() => {
    fetch('/api/advertisements', {
      headers: {
        'Cache-Control': 'no-cache',
      },
    })
      .then((response) => {
        if (!response.ok) {
          throw new Error('Failed to fetch advertisements');
        }
        return response.json();
      })
      .then((data) => {
        setAds(data);
      })
      .catch((error) => {
        console.error(error);
      });
  }, []);


  
  const handleSearch = (event) => {
    event.preventDefault();
    setSearchQuery(searchPreQuery)
  };

  const handleInputChange = (event) => {
    setSearchPreQuery(event.target.value);
  };


  return (
    <div className='ads'>
    <Form style={{
      marginTop: "0px",
      marginLeft: "40px",
      width: "100%"
    }} onSubmit={handleSearch}>
          <FormControl
            type="text"
            placeholder="Search"
            className=""
            value={searchPreQuery}
            onChange={handleInputChange}
          />
          <Button variant="outline-success" type="submit">Search</Button>
    </Form>

      <ul>
        {ads.map((ad, index) => {

          if( (props.categories.categories.includes(ad.category) || props.categories.categories.length === 0) &&
              (searchQuery === ad.header || searchQuery === '')){
            return (
              <li key={index}>
                <SmallAd index={index} ad={ad} />
              </li>
            )
          }
          else{
            return <></> 
          }
          
})}
      </ul>
    </div>
  );
}

const mapStateToProps = (state) => {
  return {
    categories: state.categories
  };
};

const mapDispatchToProps = (dispatch) => {
  return {
    CategoriesToReducer: (categories) => dispatch({ type: 'SET_CATEGORIES', payload: categories }),
  };
};

export default connect(mapStateToProps, mapDispatchToProps)(AdsList);
