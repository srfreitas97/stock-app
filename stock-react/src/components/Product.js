import React from 'react';

class Product extends React.Component {

    constructor(props) {
        super(props);
        this.state = {
            value: null,
        };
    }

    render() {

        return (
            <div>
                {this.props.data.id} {this.props.data.name} {this.props.data.amount} {this.props.data.unitPrice}
            </div>
        )
    }

}

export default Product;