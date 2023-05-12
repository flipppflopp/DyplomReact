import React,{ useState } from 'react';
import { Link, NavLink } from 'react-router-dom';
import { API_URL } from '../../variables';
import { connect } from 'react-redux'

function Register(props) {
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const [submitPassword, setSubmitPassword] = useState('');

    function handleUsername(event) {
        setUsername(event.target.value);
    }

    function handlePassword(event) {
        setPassword(event.target.value);
    }

    function handleSubmitPassword(event) {
        setSubmitPassword(event.target.value);
    }

    function handleSubmit(event) {
        if (password !== submitPassword) {
            alert('Incorrect password');
            setPassword('');
            setSubmitPassword('');
        } else {
            fetch(`/api/users`, {
                method: 'POST',
                body: JSON.stringify({
                    Id: 0,
                    Name: username,
                    Password: password,
                    IsVolonteer: false,
                    VolonteerInfoID: 0,
                    Token: ''
                }),
                headers: {
                    'Content-Type': 'application/json',
                    'Accept': 'application/json'
                },
            })
                .then((response) => response.json())
                .then((data) => {
                    if (data.result === "") {
                        alert('This user already exists');
                        setUsername('');
                        setPassword('');
                        setSubmitPassword('');
                    } else {
                        const user = {
                            username: username,
                            token: data,
                        };
    
                        props.setCredentials(user)
    
                        props.history.push('/home');
                    }
                })
                .catch((error) => {
                    console.error(error);
                });
        }
        event.preventDefault();
    }
    

    return (
        <div>
            <form onSubmit={handleSubmit}>
                <div className="container">
                    <h3>Register Form</h3>

                    <label htmlFor="uname">
                        <b>Username</b>
                    </label>
                    <input
                        value={username}
                        onChange={handleUsername}
                        type="text"
                        placeholder="Enter Username"
                        name="uname"
                        required
                    />

                    <label htmlFor="psw">
                        <b>Password</b>
                    </label>
                    <input
                        value={password}
                        onChange={handlePassword}
                        type="password"
                        placeholder="Enter Password"
                        name="psw"
                        required
                    />

                    <label htmlFor="psw">
                        <b>Confirm password</b>
                    </label>
                    <input
                        value={submitPassword}
                        onChange={handleSubmitPassword}
                        type="password"
                        placeholder="Enter Password"
                        name="psw"
                        required
                    />

                    <button type="submit">Create account</button>
                    <NavLink tag={Link} className="text-dark" to="/">
                        Already have account?
                    </NavLink>
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

export default connect(mapStateToProps, mapDispatchToProps)(Register);
