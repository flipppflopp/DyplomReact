import React, { useEffect, useState } from 'react';
import '../Home/Home.css';
import { connect } from 'react-redux';
import "./DonationsPage.css"

function DonationsPage(props) {
  const [expenses, setExpenses] = useState(null);

  useEffect(() => {
    fetch("api/expenses/" + props.user.username)
      .then((response) => response.json())
      .then((data) => {
        let expenseList = data;

        expenseList.map((expense) => {
          const datetimeString = expense.date;
          const datetime = new Date(datetimeString);

          expense.date = datetime.toLocaleString("uk-UA", {
            year: "numeric",
            month: "long",
            day: "numeric",
            hour: "numeric",
            minute: "numeric",
          });
        })

        setExpenses(expenseList);
      });
  }, [props.user.username]);

  return (
    <div>
      <h1>Donations</h1>
      {expenses ? (
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
      ) : (
        <p>Зачекайте хвилинку...</p>
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

export default connect(mapStateToProps, mapDispatchToProps)(DonationsPage);
