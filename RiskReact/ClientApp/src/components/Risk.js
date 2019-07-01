import React, { useState, useEffect } from 'react';
import RiskMapImg from '../Media/RiskMap.jpg'
import './Risk.css';
import { RiskCountrySvg } from './RiskCountrySvg';

export function Risk() {

  const [loading, setLoading] = useState(true);
  const [boardCountires, setBoardCountries] = useState([]);

  function refreshBoard(apiCall) {
    setLoading(true);

    fetch(apiCall)
        .then(response => response.json())
        .then(data => {
            data = data.filter(c => c.x !== 0);
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

  var testCountry = {
    name : 'test',
    continent : 'North America',
    occupyingArmyCount : 0,
    occupyingPlayerColor : 'red',
    x : 325,
    y : 132
  }

  //console.log(boardCountires[0]);
  //console.log(testCountry);

  function renderBoard(countries) {
    return (
      <div>
        <svg version="1.1"
            baseProfile="full"
            xmlns="http://www.w3.org/2000/svg"
            width="100%"
            viewBox="0 0 707 397">

          <image xlinkHref={RiskMapImg} x="0" y="0" height="100%" width="100%"/>

          {boardCountires.map(c => <RiskCountrySvg key={c.name} country={c} />)}
          <RiskCountrySvg key="dev" country={testCountry} />

        </svg>

        <button className="btn btn-primary" onClick={play}>Play</button>
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

  let navBar = document.getElementsByTagName("header")[0];
  if (navBar !== undefined) {
    navBar.style.display = 'none';
  }

  let contents = loading
    ? <p><em>Loading...</em></p>
      : renderBoard(boardCountires);

  return (
    <div>
      {contents}
    </div>
  );
}
