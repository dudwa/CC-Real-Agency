import React, { useEffect, useState } from 'react';
import { Outlet, Link } from 'react-router-dom';

export default function Dropdown() {

  return (
    <div>
        <Link to='/forsale'>
          <button>For Sale</button>
        </Link>
        <Link to='/torent'>
          <button>To Rent</button>
        </Link>
        <Link to='/newproperty'>
          <button>New Property</button>
        </Link>
        <Link to='/myproperties'>
          <button>My Properties</button>
        </Link>
    </div>
  );
}
