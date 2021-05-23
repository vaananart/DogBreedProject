import React from "react";
import './BreedGrid.css';
import { DogModel } from '../../DataModel/DogModel'
import BreedSelectionRowControl from '../BreedSelectionRow/BreedSelectionRowControl'
import BreedImagedisplayRowControl from '../BreedImageDisplayRow/BreedImageDisplayRowControl'

interface BreedGridControlProps{
}

interface BreedGridState{
    localbreeds?: string[];
    breedImageUrls?: string[];
    dogs: DogModel[];
    subBreeds?: string[]
    loading : boolean
    selectedBreedOptionName: string
    selectedSubBreedOptionName: string
    isError: boolean
}

export default class BreedGridControl 
    extends React.Component<BreedGridControlProps
                            , BreedGridState>
{
    private breedArray: string[] = new Array();

    constructor(props: BreedGridControlProps)
    {
        super(props);
        this.setState({
            localbreeds:new Array(),
            breedImageUrls: new Array(),
            dogs: new Array(),
            subBreeds: new Array(),
            loading: false,
            selectedBreedOptionName: '',
            isError: false
        });
        this.onBreedSelectionEvent = this.onBreedSelectionEvent.bind(this);
        this.OnSubBreedSelectionEvent = this.OnSubBreedSelectionEvent.bind(this);
    }

     async componentDidMount()
     {
         this.setState({
             loading: true
         })
        this.breedArray = new Array();
        await fetch("https://localhost:5001/api/dogs")
            .then(x=>x.json())
            .then(y=>{
                let yResult = y as DogModel[];
                this.setState({
                    dogs : yResult
                })
                let breedList: string[];
                breedList = new Array();
                yResult.forEach(x =>{
                    if(!breedList.includes(x.breed))
                    {
                        breedList.push(x.breed);
                    }
                }) 
                this.breedArray = breedList
            } )
            .catch((error)=>{
                this.setState({
                    isError:true
                });
            });
        this.setState({
            localbreeds : this.breedArray
        });
        this.setState({
            loading: false
        });
    }

    async OnSubBreedSelectionEvent(e:any)
    {
        this.setState({
            loading: true,
            selectedSubBreedOptionName: e
        });

        this.breedArray = new Array();
        await fetch(`https://localhost:5001/api/dogs/${this.state.selectedBreedOptionName}/${e}/subbreed`)
        .then(x=>x.json())
        .then(y=>{
            let yResult = y as string[];
            let breedList: string[];
            breedList = new Array();
            yResult.forEach(x =>{
                breedList.push(x);
            }) 
            this.breedArray = breedList
        } ).catch((error)=>{
            this.setState({
                isError:true
            });
        });
        this.setState({
            breedImageUrls : this.breedArray
        });

        this.setState({
            loading: false
        });
    }
    async onBreedSelectionEvent(e:any)
    {
        this.setState({
            loading: true,
            selectedBreedOptionName: e
        });
        this.breedArray = new Array();
        await fetch(`https://localhost:5001/api/dogs/${e}/subbreed`)
        .then(x=>x.json())
        .then(y=>{
            let yResult = y as string[];
            let breedList: string[];
            breedList = new Array();
            yResult.forEach(x =>{
                breedList.push(x);
            }) 
            this.breedArray = breedList
        } )
        .catch((error)=>{
            this.setState({
                isError:true
            });
        });
    
        this.setState({
            breedImageUrls : this.breedArray
        })
        let matchedSubBreeds:string[];
        matchedSubBreeds = new Array();

        this.state.dogs.forEach(x=>{
            if(x.breed == e && x.subbreed != null)
            {
                matchedSubBreeds.push(x.subbreed);
            }
        });

        this.setState({
            subBreeds : matchedSubBreeds    
        });
        this.setState({
            loading: false
        });
    }

    render(){
        if(this.state== undefined)
        {
            return (
                <div className="loader">
                </div>
            );
        }
        if(this.state.isError){
            return( 
                <div className="error-alert">
                    <a className="alert-heading">Opss.. Something went wrong :(</a>
                </div>
            );
        }
        if((this.state.loading== null)||this.state.loading === true)
        {
            return (
                <div className="grid-container">
                    <div className="loader"> 
                    </div>
                    <h2 className="">Loading</h2>
                </div>
               
            );
        }

        if( !this.state||!this.state.localbreeds)
        {
            return (
                <div className="grid-container">
                    <div className="grid-item">
                    <BreedSelectionRowControl selectedBreedOptionName = ''
                                                 selectedSubBreedOptionName = '' />
                    </div>
                </div>
            );
        }

        var returnResult: any;
        if(!this.state.breedImageUrls)
        {
            return(
                <div className="grid-container">
                    <div className="grid-item">
                    <BreedSelectionRowControl breeds={this.state.localbreeds} 
                                                selectedBreedOptionName = {this.state.selectedBreedOptionName}
                                                subbreeds={this.state.subBreeds}
                                                OnSubBreedSelectionChange = {this.OnSubBreedSelectionEvent}
                                                selectedSubBreedOptionName = {this.state.selectedSubBreedOptionName}
                                                onSelectionEvent = {this.onBreedSelectionEvent}/>
                    </div>
                </div>
            );
        }

        returnResult = this.state.breedImageUrls;
        return (
            <div className="grid-container">
                <div className="grid-item">
                <BreedSelectionRowControl breeds={this.state.localbreeds} 
                                            selectedBreedOptionName = {this.state.selectedBreedOptionName}
                                            subbreeds={this.state.subBreeds}
                                            OnSubBreedSelectionChange = {this.OnSubBreedSelectionEvent}
                                            selectedSubBreedOptionName = {this.state.selectedSubBreedOptionName}

                                            onSelectionEvent = {this.onBreedSelectionEvent}/>
                </div>

                <div className="grid-item">
                    <BreedImagedisplayRowControl breedImages = {returnResult}/>
                </div>
            </div>
        );
    }
}