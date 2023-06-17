import React, { useEffect, useState } from 'react';
import './VolonteerPopup.css';
import { connect } from 'react-redux';
import { Button } from "react-bootstrap";
import AdPopup from "./../../Popups/AdPopup/AdPopup"

function VolonteerPopup(props) {
  const [desc, setDesc] = useState('');
  const [ads, setAds] = useState([]);
  const [isSub, setIsSub] = useState(true);
  const [adPopupOpen, setAdPopup] = useState(false);

  useEffect(() => {

    fetch("api/advertisements/creator/" + props.volonteerName)
      .then((response) => response.json())
      .then((data) => {
        setAds(data)
      });

    fetch("api/volonteer-infoes/single-volonteer/" + props.volonteerName)
      .then((response) => response.json())
      .then((data) => {
        setDesc(data.description)
      });

    fetch("api/volonteer-infoes/subs/" + props.volonteerName + "/" + props.user.username)
      .then((response) => response.json())
      .then((data) => {
        setIsSub(data)
      });
    
  }, [props.volonteerName]);

  const viewAd = () => {
    toggleAdPopup();
  }

  const addSub = () => {
    fetch("api/volonteer-infoes/sub", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({
        sub: props.user.username,
        volonteer: props.volonteerName
      }),
    })
      .then((response) => response.json())
      .then((data) => {
        if(data){
          alert("Ви успішно підписані!")
          setIsSub(data)
        }
        else{
          alert("Сталася помилка при оформленні підписки.")
        }
      })    
  }
  
  const toggleAdPopup = () => {
    setAdPopup(!adPopupOpen);
  };

  return (
    <div>
      {props.isPopupOpen && (
        <div className="popup">
          <div className="popup-content">
            <h2>{props.volonteerName}</h2>
            <p>{desc}</p>

            { isSub ?
              <></>
                :
              <Button onClick={addSub} className="ad-btn">Підписатись +</Button>
            }
            
            
            { props.fromAd == undefined ?
            <div className="ads-list">
              <h4>Оголошення цього волонтера:</h4>
              {ads.map((ad, index) => (
                <div key={index}>
                  <Button className="ad-btn" onClick={viewAd}>{ad.header}</Button>
      
                  <AdPopup ad={ad} volonteerName={props.volonteerName} togglePopup={toggleAdPopup} isPopupOpen={adPopupOpen} />
                </div>
              ))}
            </div>
            :
            <></>
            }
            <button onClick={props.togglePopup}>Закрити</button>
          </div>
        </div>
      )}
    </div>
  );
}

const mapStateToProps = (state) => {
  return {
    user: state.user,
  };
};

const mapDispatchToProps = (dispatch) => {
  return {
    setCredentials: (user) => dispatch({ type: 'SET_CREDENTIALS', payload: user }),
  };
};

export default connect(mapStateToProps, mapDispatchToProps)(VolonteerPopup);
