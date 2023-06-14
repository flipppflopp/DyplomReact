import React, { useEffect, useState } from 'react';
import '../Home/Home.css';
import { connect } from 'react-redux';
import "./DonationsPage.css"

function DonationsPage(props) {
  const [expenses, setExpenses] = useState([]);

  useEffect(() => {
    fetch("api/expenses/" + props.user.username)
      .then((response) => response.json())
      .then((data) => setExpenses(data));
  }, []);

  return (
    <div>
      <h1>Donations</h1>
      <ul className="expense-list">
        {expenses.map((expense) => (
          <li key={expense.id} className="expense-item">
            <div className="expense-details">
              <p className="expense-amount">Amount: {expense.amount}</p>
              <p className="expense-date">Date: {expense.date}</p>
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

export default connect(mapStateToProps, mapDispatchToProps)(DonationsPage);
