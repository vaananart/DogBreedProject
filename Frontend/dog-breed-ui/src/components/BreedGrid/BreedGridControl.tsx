import React from "react";
import './BreedGrid.css';
import { DogModel } from '../../DataModel/DogModel'
import BreedSelectionRowControl from '../BreedSelectionRow/BreedSelectionRowControl'
import BreedImagedisplayRowControl from '../BreedImageDisplayRow/BreedImageDisplayRowControl'

interface BreedGridControlProps{
}

interface BreedGridState{
    localbreeds?: string[];
}

export default class BreedGridControl 
    extends React.Component<BreedGridControlProps
                            , BreedGridState>
{
    private breedArray!: string[];
    constructor(props: BreedGridControlProps)
    {
        super(props);
    }

     async componentDidMount(){
        await fetch("https://localhost:5001/api/dogs")
            .then(x=>x.json())
            .then(y=>{
                debugger;
                let yResult = y as DogModel[];
                let breedList: string[];
                breedList = new Array();
                yResult.forEach(x =>{
                    if(!breedList.includes(x.breed))
                    {
                        breedList.push(x.breed);
                    }
                }) 
                this.breedArray = breedList
            } );
            this.setState({
                localbreeds : this.breedArray
            })
        debugger;

    }


    componentDidUpdate(){
        debugger;
    }

    render(){
        debugger;

        if( !this.state||!this.state.localbreeds)
        {
            return (
                <div className="grid-container">
                    <div className="grid-item">
                    <BreedSelectionRowControl/>
                    </div>
    
                    <div className="grid-item">
                        <BreedImagedisplayRowControl />
                    </div>
                </div>
            );
        }

        return (
            <div className="grid-container">
                <div className="grid-item">
                <BreedSelectionRowControl breeds={this.state.localbreeds}/>
                </div>

                <div className="grid-item">
                    <BreedImagedisplayRowControl />
                </div>
            </div>
        );
    }
}