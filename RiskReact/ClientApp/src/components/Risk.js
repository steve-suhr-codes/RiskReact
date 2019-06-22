import React, { useState, useEffect } from 'react';
import RiskMapImg from '../Media/RiskMap.png'
import './Risk.css';

export function Risk() {

  const [loading, setLoading] = useState(true);
  const [boardCountires, setBoardCountries] = useState([]);

  function refreshBoard(apiCall) {
    setLoading(true);

    fetch(apiCall)
        .then(response => response.json())
        .then(data => {
            console.log(data);
            setBoardCountries(data);
            setLoading(false);
        });
  }

  useEffect(() => {
    refreshBoard('api/Risk/StartGame');
  }, []);

  function play() {
      refreshBoard('api/Risk/Play');
  }

  function renderBoard(countries) {
    //console.log('renderBoard');
    //console.log(countries);
    return (
      <div>
      <button className="btn btn-primary" onClick={play}>Play</button>

      <div>
        <img src={RiskMapImg} alt="Risk Map" />
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
                {countries.map(c =>
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

  let contents = loading
    ? <p><em>Loading...</em></p>
      : renderBoard(boardCountires);

  return (
    <div>
          <h1>Risk</h1>
          {contents}
    </div>
  );
}
