import React from 'react';
import { Link } from 'react-router-dom/cjs/react-router-dom.min';
import ProgressScale from './ProgressScale';
import "./SmallAd.css"

function SmallAd(props) {

  const getVolonteerName = () =>
  {
    return ""
  }



  return (
    <div className="ad">
      <div className="ad-photo">
        <img src={""} alt="Ad Photo" />
      </div>
      <div className="ad-content">
        <div>  
          <h3 className="ad-title">
            {props.ad.header}
          </h3>
          <p className="ad-description">
            {props.ad.text}
          </p>
        </div>
        <div className="parent">
          <div className="child">
            <p>{props.ad.collectedSum}$ / {props.ad.goalSum}$</p>
            <ProgressScale collectedSum={props.ad.collectedSum} goalSum={props.ad.goalSum} />
          </div>
          <div className="child">
            <Link>Volonteer: {getVolonteerName(props.ad.volonteerInfoID)}</Link>
          </div>
        </div>
      </div>
    </div>
  );
};

export default SmallAd;
