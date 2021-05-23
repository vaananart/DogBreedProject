import React from "react";
import "./BreedImage.css"

interface BreedImageControlProps{
    imageUrlList?: string[]
}

interface BreedImageState{

}

export default class BreedImageControl 
    extends React.Component<BreedImageControlProps
                            , BreedImageState>
{
    private localimageUrlList: string[]=[];
    constructor(props: BreedImageControlProps)
    {
        super(props);
    }

    static getDerivedStateFromProps(props: BreedImageControlProps
                                    ,state: BreedImageState)
    {
        return state;
    }

    render(){
        let imgList:any[] = new Array();

        if(this.props.imageUrlList && this.props.imageUrlList.length > 0)
        {
            return (
                this.props.imageUrlList.map(x=>
                    {  
                        return(
                            <div className="wrapper">
                                <img src={x}></img>
                            </div>
                        );
                    })
            );
        }
    }
}