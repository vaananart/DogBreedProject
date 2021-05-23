import React from 'react';
import './App.css';
// import BreedpGridControl from './BreedGrid'
import BreedDropDownSelectionControl from './components/BreedDropdownSelection/BreedDropDownSelectionControl'
import BreedGridControl from './components/BreedGrid/BreedGridControl'
export class  App extends React.Component{

  render(){
    // var result =undefined;
    // var xhttp = new XMLHttpRequest();
    // xhttp.onreadystatechange = function(){
  
    //   if(this.readyState === 4)
    //   {
    //     debugger;
    //     result = this.responseText;
    //   }
    // }
  
    // xhttp.open("GET", "https://localhost:5001/api/dogs", true);
    // xhttp.setRequestHeader("Content-type", "application/json");
    // xhttp.setRequestHeader("Access-Control-Allow-Origin","*");
    // xhttp.send();
    return (
      // <div className="App">
      //   <body>
      //     <table className="">
      //       <tr>
      //         <td>
      //           <label >Choose a breed</label><br/>
      //           <select name="breed">
      //           </select>
      //         </td>
      //         <td>
      //           <label >Choose a subbreed</label><br/>
      //           <select name="subbreed">
      //           </select>
      //         </td>
      //       </tr>
      //       <tr>
      //         {/* <td><img src={logo} className="App-logo" alt="logo" /></td>
      //         <td><img src={logo} className="App-logo" alt="logo" /></td> */}
      //       </tr>
      //     </table>
      //   </body>
      // </div>
      <React.Fragment>
        <BreedGridControl/>
      </React.Fragment>
    );
  }

}

export default App;
