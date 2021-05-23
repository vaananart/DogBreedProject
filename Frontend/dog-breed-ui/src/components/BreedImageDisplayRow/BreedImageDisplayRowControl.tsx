import React from "react";
import './BreedImageDisplayRow.css';
import BreedDropDownSelectionControl from '../BreedDropdownSelection/BreedDropDownSelectionControl'
import SubBreedDropDownSelectionControl from '../BreedDropdownSelection/SubBreedDropdownSelectionControl'
import BreedImageControl from '../BreedImage/BreedImageControl'
import { DogModel } from "../../DataModel/DogModel";

interface BreedImageDisplayRowControlProps{
    breedImages?: string[]
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

    render(){
        let firstHalfImages: string[] = [];
        let secondHalfImages : string[] = [];
        if(this.props.breedImages)
        {
            let toggle: boolean = false;
            this.props.breedImages.forEach(x=>{
                if(toggle)
                {
                    secondHalfImages.push(x)
                    toggle = false;
                }
                else
                {
                    firstHalfImages.push(x)
                    toggle = true;
                }
            });

        }
        else{
            return null;
        }
        return (
            <div className="row-image-grid-container">
                <div className="row-grid-item">
                    <BreedImageControl imageUrlList = {firstHalfImages}/>
                </div>
                <div className="row-image-grid-item">
                    <BreedImageControl imageUrlList = {secondHalfImages} />
                </div>
            </div>
        );
    }
}