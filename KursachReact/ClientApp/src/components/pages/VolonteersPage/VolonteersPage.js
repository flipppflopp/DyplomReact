import React, { useEffect, useState } from 'react';
import '../Home/Home.css';
import { connect } from 'react-redux';
import { Button } from 'react-bootstrap';
import VolonteerPopup from "./../../Popups/VolonteerPopup/VolonteerPopup"

function VolonteersPage(props) {
  const [volonteers, setVolonteers] = useState([]);
  const [subscribed, setSubscribed] = useState(false);

  const [volonteerPopupOpen, setVolonteerPopup] = useState(false);
  const [volonteerName, setVolonteerName] = useState('')

  useEffect(() => {
    var username = 'null'

    if(subscribed === true)
    {
      username = props.user.username
    }


    fetch("api/volonteer-infoes/volonteers/" + username)
      .then((response) => response.json())
      .then((data) => 
        {
          setVolonteers(data)
        });
  }, [subscribed]);

  const handleCheckboxChange = () => {
    setSubscribed(!subscribed);
  };
  
  const toggleVolonteerPopup = () => {
    setVolonteerPopup(!volonteerPopupOpen);
  };
  
  const toggleVolonteerPopupBtn = (event) => {
    setVolonteerName(event.target.textContent)
    toggleVolonteerPopup();
  };


  return (
    <div>
      <h1>Volonteers</h1>

      <div>
        <label>
          <input
            type="checkbox"
            checked={subscribed}
            onChange={handleCheckboxChange}
          />
          Підписки
        </label>
      </div>

      <ul className="expense-list">
        {volonteers.map((volonteer) => (
          <div>
          <li key={volonteer.id} className="expense-item">
            <div className="expense-details">
            <Button className="volonteerButton" onClick={toggleVolonteerPopupBtn}>{volonteer.name}</Button>
            </div>
          </li>
          </div>
        ))}
      </ul>

          {volonteerName !== '' ? (
              <VolonteerPopup volonteerName={volonteerName} 
                              togglePopup={toggleVolonteerPopup} 
                              isPopupOpen={volonteerPopupOpen} />
          ) : (
              <></>
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

export default connect(mapStateToProps, mapDispatchToProps)(VolonteersPage);

