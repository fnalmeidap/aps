import React, { Component } from 'react';

import AppRoutes from './AppRoutes';
import { Layout } from './Layout';
import './custom.css';
import { gapi } from 'gapi-script';
import { LoginProvider } from '../hooks/Login';



export default class App extends Component {
  static displayName = App.name;
  componentDidMount(){
    function start() {
      gapi.client.init({
        client_id: process.env.REACT_APP_GOOGLE_CLIENT_ID,
        scope: ''
      })
    }

    gapi.load('client:auth2', start)
  }

  render() {
    return (
      <LoginProvider>
        <Layout>
          <AppRoutes/>
        </Layout>
      </LoginProvider>
    );
  }
}
