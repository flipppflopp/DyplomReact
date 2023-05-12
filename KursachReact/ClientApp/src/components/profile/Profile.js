import React, { useEffect, useState } from 'react';
import './Profile.css';
import { Link, NavLink } from 'react-router-dom';
import { connect } from 'react-redux'

function Profile(props){
  const [newPassword, setNewPassword] = useState('');
  const [isAdmin, setIsAdmin] = useState(null);

  useEffect(() => {
    fetch(`api/admins/status/${props.user.username}`)
      .then((response) => response.json())
      .then((data) => setIsAdmin(data));
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
      }),
      headers: {
        'Content-type': 'application/json; charset=UTF-8',
      },
    }).then((response) => {
      return response;
    }).then((data) => {});

    event.preventDefault();
  };

  const renderAdminButtons = () => {
    if (isAdmin === true) {
      return (
        <div>
          <NavLink
            tag={Link}
            className="btn btn-secondary"
            to={{
              pathname: '/manageUsers'
            }}
          >
            Manage users
          </NavLink>
        </div>
      );
    } else {
      return <div></div>;
    }
  };

  return (
    <div>
      <h1>Your profile:</h1>
      <p>Username: {props.user.username}</p>

      {renderAdminButtons()}

      <NavLink
        onClick={props.setCredentials({
          username: '',
          token: ''
      })}
        tag={Link}
        className="btn btn-secondary"
        to={{
          pathname: '/',
        }}

        
      >
        Log out
      </NavLink>

      <form className="changeProfileForm" onSubmit={handleSubmit}>
        <label><b>Password</b></label>
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
    </div>
  );
};

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
