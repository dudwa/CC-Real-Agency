import React, { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';

export default function Newproperty() {

  /*const inputFields = [
    {className: "type", type: "text", label: "Type"},
    {className: "cit", type: "text", label: "City"},
    {className: "address", type: "text", label: "Address"},
    {className: "value", type: "text", label: "Value"},
    {className: "groundspace", type: "text", label: "Ground Space"},
    {className: "buildyear", type: "text", label: "Build Year"},
    {className: "about", type: "textarea", label: "About"}
  ];
  
  const formObject = inputFields.reduce((acc, cur) => {
    acc[cur.className] = "";
    return acc;
  }, {});

  const [submit, setSubmit] = useState(false);

  const formSubmit = (event) => {
    event.preventDefault();
    setSubmit(true);

    let filledFormObject = {};
    for(const key in formObject){
      filledFormObject[key] = event.target[key].value;
    }

    console.log(filledFormObject);
  }*/
/*
  <label for="dog-names">Choose a dog name:</label> 
    <select name="dog-names" id="dog-names"> 
        <option value="rigatoni">Rigatoni</option> 
        <option value="dave">Dave</option> 
        <option value="pumpernickel">Pumpernickel</option> 
        <option value="reeses">Reeses</option> 
    </select>*/

  return (
    <div>Yeah</div>
    /*submit ? <div>done</div> :
    <div className="App">
      <form onSubmit={formSubmit}>
        {inputFields.map((inputfield, index) => (
          <InputField
            key={index}
            className={inputfield.className}
            type={inputfield.type}
            label={inputfield.label}
          />
        ))}
        <button type="submit">Add Property</button>
      </form>
    </div>*/
  );
}
