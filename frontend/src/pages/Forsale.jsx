import React, { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';

export default function Forsale() {

  const fetchData = async () => {
    try 
    {
      const response = await fetch(`http://localhost:5227/RealEstate/ForSale`, {
        method: 'GET',
        headers: {
          'Content-Type': 'application/json',
          Authorization: `Bearer ${getTokenFromCookie()}`
        },
      });
      if (!response.ok) {
        throw new Error('Network response was not ok');
      }
    } catch (error) {
      console.error(error);
    }
  }

  function getTokenFromCookie()
  {
    const tokenCookie = document.cookie
    .split('; ')
    .find(cookie => cookie.startsWith('token='));

    // Extract the value after the equal sign
    return tokenCookie ? tokenCookie.split('=')[1] : null;

  }

  return (
    <div>
        <button type="button" onClick={fetchData}>ListAll</button>
    </div>
  );
}
