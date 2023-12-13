import React, { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import Cookies from 'js-cookie';

export default function Forsale() {

  const fetchData = async () => {
    try 
    {
      const baseUrl = import.meta.env.VITE_BASE_URL;
      const response = await fetch(`${baseUrl}/RealEstate/ForSale`, {
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
