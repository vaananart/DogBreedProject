import React from "react";
import './BreedSelectionRow.css';
import BreedDropDownSelectionControl from '../BreedDropdownSelection/BreedDropDownSelectionControl'
import SubBreedDropDownSelectionControl from '../BreedDropdownSelection/SubBreedDropdownSelectionControl'
import { DogModel } from "../../DataModel/DogModel";


interface BreedSelectionRowControlProps{
    breeds?: string[]
}

interface BreedSelectionRowState{
    breeds?: DogModel[]
}

export default class BreedSelectionRowControl 
    extends React.Component<BreedSelectionRowControlProps
                            , BreedSelectionRowState>
{
    constructor(props: BreedSelectionRowControlProps)
    {
        super(props);
    }

    componentDidMount() {

        debugger;
     }

     componentDidUpdate(){
         debugger;
         
     }

    static getDerivedStateFromProps(props: BreedSelectionRowControlProps
                                    ,state: BreedSelectionRowState)
    {
        return state;
    }

    render(){
        return (
            <div className="row-grid-container">
                <div className="row-grid-item">
                    <BreedDropDownSelectionControl breeds = {this.props.breeds}/>
                </div>
                <div className="row-grid-item">
                    <SubBreedDropDownSelectionControl/>
                </div>
            </div>
        );
    }
}