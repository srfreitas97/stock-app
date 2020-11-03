import logo from './logo.svg';
import './App.css';
import React from 'react';
import ProductsList from './components/ProductsList'

class App extends React.Component {

  constructor(props) {
    super(props);
    this.state = {
      products: PRODUCTS
    }
  }

  render() {
    return (
      <div className="App" >
        <header className="App-header">
          <p>Stock App</p>
        </header>
        <ProductsList products={this.state.products}/>
      </div>
    );
  }

}

const PRODUCTS = [
  {
    "id": 2,
    "name": "Mouse",
    "amount": 12,
    "unitPrice": 199.9
  },
  {
    "id": 3,
    "name": "Headset",
    "amount": 25,
    "unitPrice": 249.99
  },
  {
    "id": 4,
    "name": "Mousepad",
    "amount": 100,
    "unitPrice": 89.9
  },
  {
    "id": 5,
    "name": "HDMI Cable",
    "amount": 250,
    "unitPrice": 39.9
  },
  {
    "id": 6,
    "name": "USB cable",
    "amount": 100,
    "unitPrice": 9.9
  },
  {
    "id": 7,
    "name": "Charger",
    "amount": 10,
    "unitPrice": 19.9
  }
]

export default App;
