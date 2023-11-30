import React, { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import Cookies from 'js-cookie';

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
    return Cookies.get("token");
  }

  return (
    <div>
        <button type="button" onClick={fetchData}>ListAll</button>
    </div>
  );
}
