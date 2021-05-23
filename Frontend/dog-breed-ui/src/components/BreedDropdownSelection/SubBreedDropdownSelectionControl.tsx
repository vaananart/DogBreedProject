import React from "react";

interface SubBreedDropDownSelectionControlProps{

}

interface SubBreedDropDownSelectionState{

}

export default class SubBreedDropDownSelectionControl 
    extends React.Component<SubBreedDropDownSelectionControlProps
                            , SubBreedDropDownSelectionState>
{
    constructor(props: SubBreedDropDownSelectionControlProps)
    {
        super(props);
    }

    static getDerivedStateFromProps(props: SubBreedDropDownSelectionControlProps
                                    ,state: SubBreedDropDownSelectionState)
    {
        return state;
    }

    render(){
        return (
            <select name="subBreed" id="SubBreedSlection">
                <option selected disabled>Choose here</option>
                <option value="test1">SubBreedSelection</option>
                <option value="test2">Test2</option>
                <option value="test3">Test3</option>
            </select>
        );
    }
}