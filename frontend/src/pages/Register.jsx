import React, { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';


export default function Register(){
  const [formData, setFormData] = useState({
    email: '',
    username: '',
    password: '',
    phonenumber: '',
    firstname: '',
    lastname: ''
  });

  const [successfulRegistration, SetSuccessfulRegistration] = useState(false);

  const navigate = useNavigate();

  useEffect(() => {
    if (successfulRegistration) {
      navigate('/login');
    }
  }, [successfulRegistration, navigate]);

  const fetchData = async () => {
    try 
    {
      const response = await fetch(`http://localhost:5227/Auth/register`, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(formData),
      });
    
      if (!response.ok) {
        throw new Error('Network response was not ok');
      }
      SetSuccessfulRegistration(true);
    } catch (error) {
      console.error(error);
    }
  }

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData({
      ...formData,
      [name]: value,
    });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    fetchData();
    //console.log('Form submitted with data:', JSON.stringify(formData));
  };

  return (
    <div>
      <h2>Registration</h2>
      <form onSubmit={handleSubmit}>
      <div>
          <label htmlFor="email">Email:</label>
          <input
            type="email"
            id="email"
            name="email"
            value={formData.email}
            onChange={handleChange}
            required
          />
        </div>
        <div>
          <label htmlFor="username">Username:</label>
          <input
            type="text"
            id="username"
            name="username"
            value={formData.username}
            onChange={handleChange}
            required
          />
        </div>
        <div>
          <label htmlFor="password">Password:</label>
          <input
            type="password"
            id="password"
            name="password"
            value={formData.password}
            onChange={handleChange}
            required
          />
        </div>
        <div>
          <label htmlFor="phonenumber">Phone number:</label>
          <input
            type="text"
            id="phonenumber"
            name="phonenumber"
            value={formData.phonenumber}
            onChange={handleChange}
            required
          />
        </div>
        <div>
          <label htmlFor="firstname">First name:</label>
          <input
            type="text"
            id="firstname"
            name="firstname"
            value={formData.firstname}
            onChange={handleChange}
            required
          />
        </div>
        <div>
          <label htmlFor="lastname">Last name:</label>
          <input
            type="text"
            id="lastname"
            name="lastname"
            value={formData.lastname}
            onChange={handleChange}
            required
          />
        </div>
          <button type="submit">Register</button>
      </form>
    </div>
  );
};
