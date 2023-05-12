import React, { useState, useEffect } from 'react';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import './NavMenu.css';
import { connect } from 'react-redux'

function NavMenu(props) {
  const [collapsed, setCollapsed] = useState(true);

  function toggleNavbar() {
    setCollapsed(!collapsed);
  }

  useEffect(() => {
    console.log(props.user)
  }, [])

  return (
    <header>
      <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3" light>
        <Container>
          <NavbarBrand tag={Link} to={{
              pathname: "/home",
              state: { user: props.user }
          }}>
              Volonteers Platform
          </NavbarBrand>
          <NavbarToggler onClick={toggleNavbar} className="mr-2" />
          <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!collapsed} navbar>
            <ul className="navbar-nav flex-grow">
              <NavItem>
                <NavLink tag={Link} className="text-dark"
                         to={{
                           pathname: "/home"
                         }}>
                  Advertisements
                </NavLink>
              </NavItem>
              <NavItem>
                <NavLink tag={Link} className="text-dark"
                         to={{
                           pathname: "/donations"
                         }}>
                  Donations
                </NavLink>
              </NavItem>
              <NavItem>
                <NavLink tag={Link} className="text-dark"
                         to={{
                           pathname: "/volonteers"
                         }}>
                  Volonteers
                </NavLink>
              </NavItem>
              <NavItem>
                <NavLink tag={Link} className="text-dark"
                         to={{
                           pathname: "/profile"
                         }}>Profile: {props.user.username} </NavLink>
              </NavItem>
            </ul>
          </Collapse>
        </Container>
      </Navbar>
    </header>
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

export default connect(mapStateToProps, mapDispatchToProps)(NavMenu);
