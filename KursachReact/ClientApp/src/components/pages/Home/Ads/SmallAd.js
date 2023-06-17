import React, { useEffect, useState } from 'react';
import ProgressScale from './ProgressScale';
import "./SmallAd.css"
import VolonteerPopup from "./../../../Popups/VolonteerPopup/VolonteerPopup"
import { Button } from 'react-bootstrap';
import AdPopup from "./../../../Popups/AdPopup/AdPopup"
import getPhotoes from "./../../../../requests/getPhotoes"

function SmallAd(props) {
  const [volonteerName, setVolonteerName] = useState(null);
  const [photoUrls, setPhotoUrls] = useState([]);

  const [volonteerPopupOpen, setVolonteerPopup] = useState(false);
  const [adPopupOpen, setAdPopup] = useState(false);



  useEffect(() => {
    getVolonteerName();
    getPhoto();
  }, []);

  const getVolonteerName = async () => {
    try {
      const response = await fetch("api/volonteer-infoes/check-status/" + props.ad.volonteerInfoID, {
        headers: {
          'Cache-Control': 'no-cache',
        },
      });

      if (!response.ok) {
        throw new Error('Request failed');
      }

      const data = await response.json();

      if (data !== null) {
        setVolonteerName(data.name);
      } else {
        setVolonteerName("error");
      }
    } catch (error) {
      setVolonteerName("error catch");
    }
  };

  const getPhoto = async () => {
    var photoes = await getPhotoes(props.ad.id) 
    setPhotoUrls(photoes);
  };
  
  const toggleVolonteerPopup = () => {
    setVolonteerPopup(!volonteerPopupOpen);
  };

  const toggleAdPopup = () => {
    setAdPopup(!adPopupOpen);
  };

  return (
    <div className="ad">
      <div className="ad-photo">
        <img 
              src={
                photoUrls.length != 0 ? (
                  photoUrls[0].url
                ) : (
                  <></>
                )
              }
             alt="Ad Photo" />
      </div>
      <div className="ad-content">
        <div>
          <h3 className="ad-title">
            {props.ad.header}
          </h3>
          <p>
            <span>{props.ad.category}</span>
          </p>
          <p className="ad-description">
            {props.ad.text}
          </p>
        </div>
        <div className="parent">
          <div>
            <p>{props.ad.collectedSum}$ / {props.ad.goalSum}$</p>
            <ProgressScale collectedSum={props.ad.collectedSum} goalSum={props.ad.goalSum} />
          </div>
          <div className="volonteerSection">
            {volonteerName !== null ? (
              <Button onClick={toggleAdPopup}>View advertisement</Button>
            ) : (
              <p>Loading...</p>
            )}

            {volonteerName !== null ? (
              <Button className="volonteerButton" onClick={toggleVolonteerPopup}>{volonteerName}</Button>
            ) : (
              <p>Loading...</p>
            )}
          </div>
        </div>
      </div>
      <AdPopup ad={props.ad} volonteerName={volonteerName} togglePopup={toggleAdPopup} isPopupOpen={adPopupOpen} />


      {volonteerName !== null ? (
              <VolonteerPopup volonteerName={volonteerName} 
                              togglePopup={toggleVolonteerPopup} 
                              isPopupOpen={volonteerPopupOpen} />
      ) : (
              <></>
      )}
    </div>
  );
}

export default SmallAd;
