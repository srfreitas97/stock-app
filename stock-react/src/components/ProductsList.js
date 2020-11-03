import React from "react";
import Product from './Product'

class ProductsList extends React.Component{

    constructor(props){
        super(props);
        this.state = {
            value: null,
        };
    }

    render(){

        return(
            <div>
                {this.props.products.map(p => <Product data={p}/>)}
            </div>
        )
    }

}

export default ProductsList;
