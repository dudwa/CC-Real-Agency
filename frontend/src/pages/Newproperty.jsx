import React, { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';

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
    <div className="form-container">
      <form onSubmit={handleSubmit}>
        <label>
          Type:
          <select name="type" value={formData.type} onChange={handleChange}>
            <option value="">Select Type</option>
            <option value="sale">Sale</option>
            <option value="rent">Rent</option>
          </select>
        </label>

        <label>
          City:
          <input type="text" name="city" value={formData.city} onChange={handleChange} />
        </label>

        <label>
          Address:
          <input type="text" name="address" value={formData.address} onChange={handleChange} />
        </label>

        <label>
          Value (HUF):
          <input type="text" name="value" value={formData.value} onChange={handleChange} />
        </label>

        <label>
          Ground Space (m²):
          <input type="text" name="groundSpace" value={formData.groundSpace} onChange={handleChange} />
        </label>

        <label>
          Build Year:
          <input type="text" name="buildYear" value={formData.buildYear} onChange={handleChange} />
        </label>

        <label>
          About:
          <textarea name="about" value={formData.about} onChange={handleChange} />
        </label>

        <button type="submit">Submit</button>
      </form>
    </div>
  );
};

