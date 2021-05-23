import React from "react";

interface BreedImageControlProps{

}

interface BreedImageState{

}

export default class BreedImageControl 
    extends React.Component<BreedImageControlProps
                            , BreedImageState>
{
    constructor(props: BreedImageControlProps)
    {
        super(props);
    }

    // componentDidMount() {

    //     debugger;
    //  }

    static getDerivedStateFromProps(props: BreedImageControlProps
                                    ,state: BreedImageState)
    {
        return state;
    }

    render(){
        return (
            <img src="https://images.dog.ceo/breeds/bulldog-boston/20200710_175933.jpg" alt="Dog-breed-Image" width="500" height="600"/>
        );
    }
}