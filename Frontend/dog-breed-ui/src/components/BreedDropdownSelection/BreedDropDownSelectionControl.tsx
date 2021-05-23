import React from "react";
import { DogModel } from "../../DataModel/DogModel";
import "./DropDown.css"
interface BreedDropDownSelectionControlProps{
    breeds?: string[]
    onDropDownChange: (breedName:string) => void
    selectedBreedOptionName: string
}

interface BreedDropDownSelectionState{

}

export default class BreedDropDownSelectionControl 
    extends React.Component<BreedDropDownSelectionControlProps
                            , BreedDropDownSelectionState>
{ 
    constructor(props: BreedDropDownSelectionControlProps)
    {
        super(props);
        this.onSelectChange = this.onSelectChange.bind(this);
    }

    static getDerivedStateFromProps(props: BreedDropDownSelectionControlProps
                                    ,state: BreedDropDownSelectionState)
    {
        return state;
    }

    onSelectChange(e: any)
    {
        var breedName = e.target.value;
        this.props.onDropDownChange(breedName);
    }

    render(){
        let finalList: undefined|any[];
        if(this.props.breeds)
        {
            var i:number;
            finalList = new Array();
            for(i  = 0; i < this.props.breeds.length; i++)
            {   

                var element :string = this.props.breeds[i];
                if( this.props.selectedBreedOptionName && this.props.selectedBreedOptionName == element)
                {
                    finalList.push( <option selected value={element}>{element}</option>);
                }
                else
                    finalList.push( <option value={element}>{element}</option>)

            }
            var result = this.props.breeds;
        }

        return (
            <select className="box" name="breed" id="breedSlection" onChange = {this.onSelectChange}>
                <option selected disabled>Choose here</option>
               {finalList}
            </select>
        );
    }
}