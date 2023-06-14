import React, { useState } from 'react';
import { Button, Modal, Form } from 'react-bootstrap';
import { connect } from 'react-redux';

function FillBalancePopup(props) {
  const [amount, setAmount] = useState(null);

  const handleAmountChange = (event) => {
    setAmount(event.target.value);
  };

  const handleSubmit = (event) => {
    event.preventDefault();
    
    if(amount <= 0){
      alert("Введіть коректну суму!")
      return
    }

    fetch('api/users/fill-balance', {
      method: 'put',
      headers: {
        'Content-type': 'application/json; charset=UTF-8'
      },
      body: JSON.stringify({
        Username: props.user.username,
        Amount: Number(amount)
      })
    })
    .then(response => {
      if (response.ok) {
        props.setBalance(Number(props.balance) + Number(amount))
      } else {
        alert("Щось сталось не так під час виконання запиту!")
      }
    })
    
    props.togglePopup();
  };

  return (
    <Modal show={props.isPopupOpen} onHide={props.togglePopup}>
      <Modal.Header>
        <Modal.Title>Fill Balance</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <Form style={{marginTop: "0px"}} onSubmit={handleSubmit}>
          <Form.Group controlId="amount">
            <Form.Label>Amount</Form.Label>
            <Form.Control
              type="number"
              placeholder="Enter amount"
              value={amount}
              onChange={handleAmountChange}
              required
            />
          </Form.Group>
          <Button variant="primary" type="submit">
            Submit
          </Button>
        </Form>
      </Modal.Body>
      <Modal.Footer>
        <Button variant="secondary" onClick={props.togglePopup}>
          Close
        </Button>
      </Modal.Footer>
    </Modal>
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

export default connect(mapStateToProps, mapDispatchToProps)(FillBalancePopup);