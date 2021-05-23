import React from "react";
import { DogModel } from "../../DataModel/DogModel";

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
        //debugger;
        return state;
    }

    onSelectChange(e: any)
    {
        debugger;
        var breedName = e.target.value;
        this.props.onDropDownChange(breedName);
    }

    render(){
        let finalList: undefined|any[];
        if(this.props.breeds)
        {
            //debugger;
            var i:number;
            finalList = new Array();
            for(i  = 0; i < this.props.breeds.length; i++)
            {   

                var element :string = this.props.breeds[i];
                //debugger;
                if( this.props.selectedBreedOptionName && this.props.selectedBreedOptionName == element)
                {
                    finalList.push( <option selected value={element}>{element}</option>);
                    debugger;
                }
                else
                    finalList.push( <option value={element}>{element}</option>)

            }
            var result = this.props.breeds;
        }

        return (
            <select name="breed" id="breedSlection" onChange = {this.onSelectChange}>
                <option selected disabled>Choose here</option>
               {finalList}
            </select>
        );
    }
}