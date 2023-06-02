import React, { useState, useEffect } from 'react';
import { connect } from 'react-redux'

function ManageUsers(props) {
  const [usersList, setUsersList] = useState(null);

  useEffect(() => {
    fetch('api/users')
      .then((response) => response.json())
      .then((data) => setUsersList(data));
  }, []);

  function handleDeleteButton(event, id) {
    const requestOptions = {
      method: 'DELETE',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify({
        Id: id,
        Name: '',
        Password: '',
        IsVolonteer: false,
        VolonteerInfoID: 0,
      }),
    };

    fetch('api/users', requestOptions)
      .then((response) => response.json())
      .then((data) => {
        // handle response data here if needed
      });
    setUsersList(null);
  }

  function renderUserList() {
    if (usersList !== null) {
      return usersList.map((el) =>
        el.name !== props.user.username ? (
          <tr key={el.id}>
            <td>
              <p>{el.id}</p>
            </td>
            <td>
              <p>{el.name}</p>
            </td>
            <td>
              <button
                className="btn btn-danger"
                onClick={(e) => {
                  handleDeleteButton(e, el.id);
                  window.location.reload(false);
                }}
              >
                Delete user
              </button>
            </td>
          </tr>
        ) : (
          <div key={el.id}></div>
        )
      );
    }
  }

  return (
    <div>
      <h1>Manage users:</h1>
      <table>
        <thead>
          <tr>
            <th>ID</th>
            <th>User name</th>
            <th></th>
          </tr>
        </thead>
        <tbody>{renderUserList()}</tbody>
      </table>
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

export default connect(mapStateToProps, mapDispatchToProps)(ManageUsers);
