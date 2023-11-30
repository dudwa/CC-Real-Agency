import React, { useEffect, useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import { jwtDecode } from 'jwt-decode';
import Cookies from 'js-cookie';

export default function Login({setAuthenticated}){
  
  const [formData, setFormData] = useState({
    username: '',
    password: '',
  });

  const navigate = useNavigate();

  const fetchData = async () => {
    try 
    {
      const response = await fetch(`http://localhost:5227/Auth/login`, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(formData),
      });
    
      if (!response.ok) {
        throw new Error('Network response was not ok');
      }
      const data = await response.json();
      const token =  data["token"];
      setCookie(token);
      setAuthenticated(true);
      navigate('/');
    } catch (error) {
      console.error(error);
    }
  }

  function setCookie(token) {
    // Decode the token
    const decodedToken = jwtDecode(token);
    const role = decodedToken["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
    const username = decodedToken["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"];

    // Get the expiration time from the decoded token
    const expirationTime = new Date(decodedToken.exp * 1000);

    document.cookie = `token=${token}; expires=${expirationTime.toUTCString()} path=/`;
    document.cookie = `role=${role}; expires=${expirationTime.toUTCString()} path=/`;
    document.cookie = `username=${username}; expires=${expirationTime.toUTCString()} path=/`;
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
    //console.log('Form submitted with data:', formData);
  };

  return (
    <div>
      <h2>Login</h2>
      <form onSubmit={handleSubmit}>
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
        <Link to='/register'>
          <button>Registration</button>
        </Link>
        <button type="submit">Login</button>
      </form>
    </div>
  );
};