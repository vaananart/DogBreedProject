import React from "react";
import './BreedImageDisplayRow.css';
import BreedDropDownSelectionControl from '../BreedDropdownSelection/BreedDropDownSelectionControl'
import SubBreedDropDownSelectionControl from '../BreedDropdownSelection/SubBreedDropdownSelectionControl'
import BreedImageControl from '../BreedImage/BreedImageControl'
import { DogModel } from "../../DataModel/DogModel";

interface BreedImageDisplayRowControlProps{
}

interface BreedImageDisplayRowState{

}

export default class BreedImageDisplayRowControl 
    extends React.Component<BreedImageDisplayRowControlProps
                            , BreedImageDisplayRowState>
{
    constructor(props: BreedImageDisplayRowControlProps)
    {
        super(props);
    }

    // componentDidMount() {

    //     debugger;
    //  }

    static getDerivedStateFromProps(props: BreedImageDisplayRowControlProps
                                    , state: BreedImageDisplayRowState)
    {
        return state;
    }

    render(){
        return (
            <div className="row-image-grid-container">
                <div className="row-grid-item">
                    <BreedImageControl/>
                </div>
                <div className="row-image-grid-item">
                    <BreedImageControl/>
                </div>
            </div>
        );
    }
}