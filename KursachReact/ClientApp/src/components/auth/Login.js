import React, { useState } from 'react';
import './auth.css';
import { Link, NavLink, useHistory } from "react-router-dom";
import API_URL from '../../variables';
import { connect } from 'react-redux'

function Login(props) {
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const history = useHistory();

  const handleUsername = (event) => {
    setUsername(event.target.value);
  };

  const handlePassword = (event) => {
    setPassword(event.target.value);
  };

  const handleSubmit = (event) => {
    event.preventDefault();

    fetch('api/users/validate', {
      method: 'post',
      body: JSON.stringify({
        Id: 0,
        Name: username,
        Password: password,
        IsVolonteer: false,
        VolonteerInfoID: 0,
        Token: ''
      }),
      headers: {
        "Content-type": "application/json; charset=UTF-8"
      }
    })
      .then((response) => {
        return response.json();
      })
      .then((data) => {
        if (data.result === "") {
          alert("Wrong password or username")
          setPassword('');
          return;
        } else {

          let user = {
            username: username,
            token: data.result
          }

          props.setCredentials(user)

          history.push("/home");
        }
      });
  };

  return (
    <div>
      <form onSubmit={handleSubmit}>
        <div className="container">
          <h3>Login Form</h3>
          <label htmlFor="uname"><b>Username</b></label>
          <input value={username} onChange={handleUsername} type="text" placeholder="Enter Username" name="uname" required />
          <label htmlFor="psw"><b>Password</b></label>
          <input value={password} onChange={handlePassword} type="password" placeholder="Enter Password" name="psw" required />
          <button type="submit">Login</button>
          <NavLink tag={Link} className="text-dark" to="/register">Create account</NavLink>
        </div>
      </form>
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

export default connect(mapStateToProps, mapDispatchToProps)(Login);
