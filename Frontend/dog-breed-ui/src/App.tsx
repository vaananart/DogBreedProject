import React from 'react';
import './App.css';
// import BreedpGridControl from './BreedGrid'
import BreedDropDownSelectionControl from './components/BreedDropdownSelection/BreedDropDownSelectionControl'
import BreedGridControl from './components/BreedGrid/BreedGridControl'
export class  App extends React.Component{

  

  render(){

    return (
      <React.Fragment>
        <BreedGridControl/>
      </React.Fragment>
    );
  }

}

export default App;
