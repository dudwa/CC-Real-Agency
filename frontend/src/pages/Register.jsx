import React, { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import '../App.css';

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
      const baseUrl = import.meta.env.VITE_BASE_URL;
      const response = await fetch(`${baseUrl}/Auth/register`, {
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
    <div className="register-container">
      <h2 className="register-header">Registration</h2>
      <form className="register-form" onSubmit={handleSubmit}>
        <input
          type="email"
          id="email"
          name="email"
          placeholder="Email"
          value={formData.email}
          onChange={handleChange}
          required
        />
        <input
          type="text"
          id="username"
          name="username"
          placeholder="Username"
          value={formData.username}
          onChange={handleChange}
          required
        />
        <input
          type="password"
          id="password"
          name="password"
          placeholder="Password"
          value={formData.password}
          onChange={handleChange}
          required
        />
        <input
          type="text"
          id="phonenumber"
          name="phonenumber"
          placeholder="Phone number"
          value={formData.phonenumber}
          onChange={handleChange}
          required
        />
        <input
          type="text"
          id="firstname"
          name="firstname"
          placeholder="First name"
          value={formData.firstname}
          onChange={handleChange}
          required
        />
        <input
          type="text"
          id="lastname"
          name="lastname"
          placeholder="Last name"
          value={formData.lastname}
          onChange={handleChange}
          required
        />
        <button type="submit">Register</button>
      </form>
    </div>
  );
}