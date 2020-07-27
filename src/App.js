import React from 'react';
import './App.scss';
import TestComponent from "./components/test/test.component";
import { Switch, Route, BrowserRouter } from 'react-router-dom';
import AccountPage from './components/test/test.newpage';

class App extends React.Component{
  render() {
    return (
        <div className="App">
          <BrowserRouter>
            <Switch>
              <Route path = '/languagePick' component = {TestComponent}/>
              <Route path='/account' component = {AccountPage}/>
            </Switch>
          </BrowserRouter>
        </div>
    );
  }
}

export default App;
