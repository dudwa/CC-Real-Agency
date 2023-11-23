import React, { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
//import './Newproperty.css';

export default function NewProperty() {
  const [formData, setFormData] = useState({
    type: '',
    city: '',
    address: '',
    value: '',
    groundSpace: '',
    buildYear: '',
    about: '',
  });

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData((prevData) => ({
      ...prevData,
      [name]: value,
    }));
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    // Handle form submission logic here
    console.log('Form Data:', formData);
    // You can send the form data to your backend or perform any other action
  };

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
    </div>
  );
};

