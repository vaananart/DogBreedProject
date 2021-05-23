import React from "react";
import './BreedSelectionRow.css';
import BreedDropDownSelectionControl from '../BreedDropdownSelection/BreedDropDownSelectionControl'
import SubBreedDropDownSelectionControl from '../BreedDropdownSelection/SubBreedDropdownSelectionControl'
import { DogModel } from "../../DataModel/DogModel";
import { isThisTypeNode } from "typescript";
import { threadId } from "worker_threads";


interface BreedSelectionRowControlProps{
    breeds?: string[]
    subbreeds?:string[]
    onSelectionEvent? : (breedName: string) => void
    selectedBreedOptionName: string
    OnSubBreedSelectionChange?:(subBreedName: string) => void
    selectedSubBreedOptionName:string
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
        this.OnActionChange = this.OnActionChange.bind(this);
        this.OnSubBreedSelectionChange = this.OnSubBreedSelectionChange.bind(this);
    }

    static getDerivedStateFromProps(props: BreedSelectionRowControlProps
                                    ,state: BreedSelectionRowState)
    {
        return state;
    }

    OnActionChange(e:any)
    {
        if(this.props.onSelectionEvent)
        {
            this.props.onSelectionEvent(e);
        }
    }

    OnSubBreedSelectionChange(e:any)
    {
        if(this.props.OnSubBreedSelectionChange)
        {
            this.props.OnSubBreedSelectionChange(e);
        }
    }

    render(){

        debugger;
        if(this.props.subbreeds == null || this.props.subbreeds.length == 0)
        {
            return (
                <div className="row-grid-container">
                    <div className="row-grid-item">
                        <BreedDropDownSelectionControl
                            selectedBreedOptionName = {this.props.selectedBreedOptionName}
                             breeds = {this.props.breeds} 
                             onDropDownChange={this.OnActionChange}/>
                    </div>
                </div>
            );
        }
        return (
            <div className="row-grid-container">
                <div className="row-grid-item">
                    <BreedDropDownSelectionControl
                        selectedBreedOptionName = {this.props.selectedBreedOptionName}
                         breeds = {this.props.breeds} 
                         onDropDownChange={this.OnActionChange}/>
                </div>
                <div className="row-grid-item">
                    <SubBreedDropDownSelectionControl
                    onDropDownChange = {this.OnSubBreedSelectionChange}
                    selectedSubBreedOptionName = {this.props.selectedSubBreedOptionName}
                    subbreeds = {this.props.subbreeds}/>
                </div>
            </div>
        );
    }
}