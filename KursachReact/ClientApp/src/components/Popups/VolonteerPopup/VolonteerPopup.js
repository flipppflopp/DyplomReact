import React, { useEffect, useState } from 'react';
import './VolonteerPopup.css';
import { connect } from 'react-redux';
import { Button } from "react-bootstrap";

function VolonteerPopup(props) {
  const [desc, setDesc] = useState('');
  const [ads, setAds] = useState([]);
  const [isSub, setIsSub] = useState(true);


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
    
  }, []);

  const viewAd = () => {
    props.toggleAdPopup();
    props.togglePopup();
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

            <div className="ads-list">
              <h4>Оголошення цього волонтера:</h4>
              {ads.map((ad, index) => (
                <div key={index}>
                  <Button className="ad-btn" onClick={viewAd}>{ad.header}</Button>
                </div>
              ))}
            </div>

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
