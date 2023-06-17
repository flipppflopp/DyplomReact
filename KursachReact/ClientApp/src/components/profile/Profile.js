import React, { useEffect, useState } from 'react';
import './Profile.css';
import { Link, NavLink } from 'react-router-dom';
import { connect } from 'react-redux';
import { Button } from 'react-bootstrap';
import FillBalancePopup from "./FillBalancePopup"

function Profile(props) {
  const [newPassword, setNewPassword] = useState('');
  const [isAdmin, setIsAdmin] = useState(null);
  const [balance, setBalance] = useState(null);
  const [isPopupOpen, setIsPopupOpen] = useState(false);

  useEffect(() => {

    fetch(`api/admins/status/${props.user.username}`)
      .then((response) => response.json())
      .then((data) => setIsAdmin(data));

    fetch(`api/users/get-balance/${props.user.username}`)
      .then((response) => response.json())
      .then((data) => {
          setBalance(data)
        });
    
  }, [props.user.username]);

  const handlePassword = (event) => {
    setNewPassword(event.target.value);
  };

  const handleSubmit = (event) => {
    fetch('api/users', {
      method: 'put',
      body: JSON.stringify({
        Id: 0,
        Name: props.user.username,
        Password: newPassword,
        IsVolonteer: false,
        VolonteerInfoID: 0,
        Token: props.user.token,
      }),
      headers: {
        'Content-type': 'application/json; charset=UTF-8',
      },
    })
      .then((response) => {
        return response;
      })
      .then((data) => {
        alert("Ваш пароль успішно змінено!")
      });

    event.preventDefault();
  };

  const renderAdminButtons = () => {
    if (isAdmin === true) {
      return (
        <div>
          <NavLink tag={Link} className="btn btn-secondary" to={{ pathname: '/manageUsers' }}>
            Manage users
          </NavLink>
        </div>
      );
    } else {
      return <div></div>;
    }
  };

  const FillBalanceBtnClick = () => {
    setIsPopupOpen(true);
  };

  const togglePopup = () => {
    setIsPopupOpen(!isPopupOpen);
  };

  return (
    <div>
      <h1>Your profile:</h1>
      <p>Username: {props.user.username}</p>

      <div className='subsBtn'></div>

      <div className="changeProfileForm">
        <p>
          <b>Your balance: {balance}</b>
        </p>
        <Button  onClick={FillBalanceBtnClick}>
          Fill balance
        </Button>
      </div>

      {renderAdminButtons()}

      <NavLink tag={Link} className="btn btn-secondary" to={{ pathname: '/' }}>
        Log out
      </NavLink>


      <form className="changeProfileForm" onSubmit={handleSubmit}>
        <label>
          <b>Change Password</b>
        </label>
        <input
          value={newPassword}
          onChange={handlePassword}
          type="password"
          placeholder="Enter new Password"
          name="psw"
          required
        />

        <button type="submit">Change password</button>
      </form>

      <FillBalancePopup isPopupOpen={isPopupOpen} togglePopup={togglePopup} setBalance={setBalance} balance={balance}/>

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

export default connect(mapStateToProps, mapDispatchToProps)(Profile);
