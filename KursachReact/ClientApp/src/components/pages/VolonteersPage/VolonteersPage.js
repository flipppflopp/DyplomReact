import React, { useEffect, useState } from 'react';
import '../Home/Home.css';
import { connect } from 'react-redux';

function VolonteersPage(props) {
  const [volonteers, setVolonteers] = useState([]);
  const [subscribed, setSubscribed] = useState(false);

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
          console.log(data)
          setVolonteers(data)
        });
  }, [subscribed]);

  const handleCheckboxChange = () => {
    setSubscribed(!subscribed);
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
          <li key={volonteer.id} className="expense-item">
            <div className="expense-details">
              <p className="expense-amount">Name: {volonteer.name}</p>
            </div>
          </li>
        ))}
      </ul>
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

