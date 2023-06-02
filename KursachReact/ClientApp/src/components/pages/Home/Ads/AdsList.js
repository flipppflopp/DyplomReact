import React, { useEffect, useState } from 'react';
import SmallAd from './SmallAd';
import './AdsList.css';

function AdsList(props) {
  const [ads, setAds] = useState([]);

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

  return (
    <div className='ads'>
      <ul>
        {ads.map((ad, index) => (
          <li key={index}>
            <SmallAd ad={ad} />
          </li>
        ))}
      </ul>
    </div>
  );
}

export default AdsList;
