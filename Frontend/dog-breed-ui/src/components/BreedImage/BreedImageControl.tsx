import React from "react";

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

    // componentDidMount() {

    //     debugger;
    //     if(this.props.imageUrlList)
    //         this.localimageUrlList = this.props.imageUrlList;
    //  }

    // componentDidUpdate(){
    //     debugger;
    //     if(this.props.imageUrlList)
    //         this.localimageUrlList = this.props.imageUrlList;
    // }

    static getDerivedStateFromProps(props: BreedImageControlProps
                                    ,state: BreedImageState)
    {
        return state;
    }

    render(){
        let imgList:any[] = new Array();

        if(this.props.imageUrlList && this.props.imageUrlList.length > 0)
        {
            //debugger;
            return (
                this.props.imageUrlList.map(x=>
                    {  
                        return(
                            <div>
                                <img src={x} width="500" height="600"></img>
                            </div>
                        );
                    })
            );
        }
    }
}