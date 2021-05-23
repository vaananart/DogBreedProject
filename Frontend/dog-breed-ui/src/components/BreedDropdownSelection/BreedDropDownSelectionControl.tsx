import React from "react";
import { DogModel } from "../../DataModel/DogModel";

interface BreedDropDownSelectionControlProps{
    breeds?: string[]
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
    }

    static getDerivedStateFromProps(props: BreedDropDownSelectionControlProps
                                    ,state: BreedDropDownSelectionState)
    {
        debugger;
        return state;
    }

    render(){
        let finalList: undefined|any[];
        if(this.props.breeds)
        {
            debugger;
            var i:number;
            finalList = new Array();
            for(i  = 0; i < this.props.breeds.length; i++)
            {   

                var element :string = this.props.breeds[i];
                finalList.push( <option value={element}>{element}</option>)

            }
            var result = this.props.breeds;
        }

        return (
            <select name="breed" id="breedSlection">
                <option selected disabled>Choose here</option>
               {finalList}
            </select>
        );
    }
}