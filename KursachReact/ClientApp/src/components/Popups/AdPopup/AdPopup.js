import React, { useEffect, useState } from 'react';
import ProgressScale from './../../pages/Home/Ads/ProgressScale';
import "./AdPopup.css"
import VolonteerPopup from "./../VolonteerPopup/VolonteerPopup"
import { Button } from 'react-bootstrap';
import MakeExpensePopup from "./MakeExpensePopup"

function AdPopup(props) {
  const [currentIndex, setCurrentIndex] = useState(0);
  const [volonteerPopupOpen, setVolonteerPopup] = useState(false);
  const [ExpensePopupOpen, setExpensePopupOpen] = useState(false);


  const toggleVolonteerPopup = () => {
    setVolonteerPopup(!volonteerPopupOpen);
  };

  const handleNext = () => {
    setCurrentIndex((prevIndex) => (prevIndex + 1) % props.images.length);
  };

  const handlePrev = () => {
    setCurrentIndex((prevIndex) => (prevIndex - 1 + props.images.length) % props.images.length);
  };

  useEffect(() => {
  }, [])

  const FillBalanceBtnClick = () => {
    setExpensePopupOpen(true);
  };

  const toggleExpensePopup = () => {
    setExpensePopupOpen(!ExpensePopupOpen);
  };

  return (
    <div>
      {props.isPopupOpen && (
        <div className="popup">
          <div className="popup-content generalAdPopup">
          <div className="gallery">
            <img src={props.images[currentIndex].url} alt={`Image ${currentIndex + 1}`} />

            <div className="gallery-buttons">
              <button className="gallery-btn" onClick={handlePrev}>&lt;</button>
              <button className="gallery-btn" onClick={handleNext}>&gt;</button>
            </div>
          </div>

            <h2>{props.ad.header}</h2>
            <h4>Category: {props.ad.category}</h4>
            <p>{props.ad.text}</p>

            <div className="moneyBar">
              <p>{props.ad.collectedSum}$ / {props.ad.goalSum}$</p>
              <ProgressScale collectedSum={props.ad.collectedSum} goalSum={props.ad.goalSum} />
              {props.volonteerName !== null ? (
                <Button className="volonteerButton" onClick={toggleVolonteerPopup}>Volonteer: {props.volonteerName}</Button>
              ) : (
                <p>Loading...</p>
              )}
            </div>

            <Button  onClick={FillBalanceBtnClick}>
              Make a expense
            </Button>

            <button className="adPopupBtn" onClick={props.togglePopup}>Close</button>
          </div>
        </div>
      )}

      <MakeExpensePopup ad={props.ad} isPopupOpen={ExpensePopupOpen} togglePopup={toggleExpensePopup} />

      <VolonteerPopup isPopupOpen={volonteerPopupOpen} togglePopup={toggleVolonteerPopup} />
    </div>
  );
}

export default AdPopup;
