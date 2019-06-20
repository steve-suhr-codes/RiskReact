import React, { Component } from 'react';
import RiskMapImg from '../Media/RiskMap.png'
import './Risk.css';

export class Risk extends Component {
    static displayName = Risk.name;

    refreshBoard(apiCall) {
        this.state = { loading: true };

        fetch(apiCall)
            .then(response => response.json())
            .then(data => {
                console.log(data);
                this.setState({ boardCountires: data, loading: false });
            });
    }

    constructor (props) {
        super(props);
        this.state = { boardCountires: [], loading: true };

        this.refreshBoard('api/Risk/StartGame');
    }


    play() {
        this.refreshBoard('api/Risk/Play');
    }

    static renderboard(boardCountires) {
    return (
      <div>
      <button className="btn btn-primary" onClick={this.play}>Play</button>

      <div>
        <img src= { RiskMapImg } />
      </div>

      <div className='risk-map'>

      </div>

      <table className='table table-striped'>
        <thead>
          <tr>
            <th>Continent</th>
            <th>Country</th>
            <th>Occupied By</th>
            <th>Armies</th>
          </tr>
        </thead>
        <tbody>
                {boardCountires.map(c =>
                    <tr key={c.name}>
                        <td>{c.continent}</td>
                        <td>{c.name}</td>
                        <td>{c.occupyingPlayerName}</td>
                        <td>{c.occupyingArmyCount}</td>
                    </tr>
                )}
        </tbody>
      </table>
      </div>
    );
  }

  render () {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
        : Risk.renderboard(this.state.boardCountires);

    return (
      <div>
            <h1>Risk</h1>
            {contents}
      </div>
    );
  }
}
