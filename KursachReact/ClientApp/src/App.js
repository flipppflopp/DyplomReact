import React from 'react';
import { Route } from 'react-router-dom';

import Home  from './components/Home';
import Login from './components/auth/Login';
import Register from './components/auth/Register';
import Profile from './components/profile/Profile';
import ManageUsers from './components/manage/ManageUsers'
import DonationsPage from "./components/DonationsPage"
import VolonteersPage from "./components/VolonteersPage"

import './custom.css'
import Layout from './components/Layout';

function App() {
  return (
    <div>
      <Route exact path='/' component={Login} />
      <Route exact path='/register' component={Register} />

      <Route exact path='/home' render={(props) => (
        <Layout>
          <Home {...props} />
        </Layout>
      )} />
      <Route exact path='/profile' render={(props) => (
        <Layout>
          <Profile {...props} />
        </Layout>
      )} />
      <Route exact path='/manageUsers' render={(props) => (
        <Layout>
          <ManageUsers {...props} />
        </Layout>
      )} />
      <Route exact path='/donations' render={(props) => (
        <Layout>
          <DonationsPage {...props} />
        </Layout>
      )} />
      <Route exact path='/volonteers' render={(props) => (
        <Layout>
          <VolonteersPage {...props} />
        </Layout>
      )} />
    </div>
  );
}

export default App;
