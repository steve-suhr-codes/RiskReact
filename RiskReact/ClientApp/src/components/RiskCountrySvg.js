import React from 'react';

export function RiskCountrySvg(props) {

  //console.log(props);

  function countryClick(event) {
    // console.log('countryClick');
    // console.log(event.target.tagName);
    var circle = event.target;
    if (event.target.tagName === 'text') {
      circle = event.target.previousElementSibling;
    }

    var countryName = circle.querySelector('title').innerHTML;
    //console.log(countryName);
    //console.log(event.target.querySelector('title').innerHTML);
  }

  // return (
  //   <svg x="115" y="47">
  //     <circle cx="10" cy="10" r="10" fill="red" id="AlaskaCircle">
  //       <title>Alaska</title>
  //     </circle>
  //   </svg>
  // );

  // return (
  //   <svg x="750" y="390">
  //     <circle cx="10" cy="10" r="10" fill="white" id="AlaskaCircle">
  //       <title>Alaska</title>
  //     </circle>
  //     <text x="10" y="10" fontSize="12" textAnchor="middle" alignmentBaseline="middle" fill="white">
  //       3
  //     </text>
  //   </svg>
  // );

  return (
    <svg x={props.country.x} y={props.country.y} onClick={countryClick.bind(this)}>
      <circle cx="10" cy="10" r="10" fill={props.country.occupyingPlayerColor} id="AlaskaCircle">
        <title>{props.country.name}</title>
      </circle>
      <text x="10" y="10" fontSize="12" textAnchor="middle" alignmentBaseline="middle" fill="white">
        {props.country.occupyingArmyCount}
      </text>
    </svg>
  );
}
