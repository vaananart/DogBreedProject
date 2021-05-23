import React from "react";

interface SubBreedDropDownSelectionControlProps{
    subbreeds?:string[]
    onDropDownChange: (breedName:string) => void
    selectedSubBreedOptionName: string
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
        this.onSelectChange = this.onSelectChange.bind(this);
    }

    static getDerivedStateFromProps(props: SubBreedDropDownSelectionControlProps
                                    ,state: SubBreedDropDownSelectionState)
    {
        return state;
    }
    
    onSelectChange(e: any)
    {
        debugger;
        var breedName = e.target.value;
        this.props.onDropDownChange(breedName);
    }

    render(){

        let finalList: any[] = new Array();
        if(this.props.subbreeds)
        {
            this.props.subbreeds.forEach(x=>{
                if( this.props.selectedSubBreedOptionName && this.props.selectedSubBreedOptionName == x)
                {
                    finalList.push( <option selected value={x}>{x}</option>);
                    debugger;
                }
                else
                {
                    finalList.push(<option value={x}>{x}</option>);
                }
            });
        }
        // debugger;
        return (
            <select name="subBreed" id="SubBreedSlection" onChange = {this.onSelectChange}>
                <option selected disabled>Choose here</option>
                {finalList}
            </select>
        );
    }
}