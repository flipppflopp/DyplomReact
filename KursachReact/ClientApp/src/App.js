import React from 'react';
import { Route } from 'react-router-dom';

import Home  from './components/pages/Home/Home';
import Login from './components/auth/Login';
import Register from './components/auth/Register';
import Profile from './components/profile/Profile';
import ManageUsers from './components/manage/ManageUsers'
import DonationsPage from "./components/pages/DonationsPage/DonationsPage"
import VolonteersPage from "./components/pages/VolonteersPage/VolonteersPage"

import './custom.css'
import Layout from './components/Navigation/Layout';

function App() {
  return (
    <div>
      <Route exact path='/' component={Login} />
      <Route exact path='/register' component={Register} />

      <Route exact path='/home' render={() => (
        <Layout>
          <Home />
        </Layout>
      )} />
      <Route exact path='/profile' render={() => (
        <Layout>
          <Profile  />
        </Layout>
      )} />
      <Route exact path='/manageUsers' render={() => (
        <Layout>
          <ManageUsers  />
        </Layout>
      )} />
      <Route exact path='/donations' render={() => (
        <Layout>
          <DonationsPage  />
        </Layout>
      )} />
      <Route exact path='/volonteers' render={() => (
        <Layout>
          <VolonteersPage  />
        </Layout>
      )} />
    </div>
  );
}

export default App;
