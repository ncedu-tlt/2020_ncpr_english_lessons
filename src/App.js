import React from 'react';
import './App.scss';
import TestComponent from "./components/test/test.component";

class App extends React.Component{
  render() {
    return (
        <div className="App">
          <TestComponent/>
        </div>
    );
  }
}

export default App;
