import React from 'react';
import './App.scss';
import TestComponent from "./components/test/test.component";
import RegistrationComponent from "./components/Registration/registration.component";
import AuthorizationComponent from "./components/Authorization/authorization.component";

class App extends React.Component{
  render() {
    return (
        <div className="App">
          <TestComponent/>
          <RegistrationComponent/>
          <AuthorizationComponent/>
        </div>
    );
  }
}

export default App;
