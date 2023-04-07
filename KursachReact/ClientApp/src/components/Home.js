import React, { Component } from 'react';
import { Layout } from './Layout';
import API_URL from '../variables'
import './Home.css';
import {Link, NavLink} from "react-router-dom";

export class Home extends Component {
  static displayName = Home.name;
    constructor(props) {
        super(props);
        this.state = {

        };
    }
  
    componentDidMount() {

    }

  
  render () {
    return (
        <Layout user={this.props.location.state.user}>
            
        </Layout>
    );
  }
}
