import React, { useState } from 'react';
import { Outlet, Link } from 'react-router-dom';
import Dropdown from './Dropdown';

export default function Layout() {
  const [isDropdownVisible, setDropdownVisible] = useState(false);


  return (
    <div>
      <div className='navbar'>
        <Link to='/'>
          <button>Home</button>
        </Link>
        <button onClick={() => {setDropdownVisible(!isDropdownVisible)}}>Properties</button>
        {isDropdownVisible && <Dropdown></Dropdown>}
        <Link to='/faq'>
          <button>FAQ</button>
        </Link>
        <Link to='/about'>
          <button>About Us</button>
        </Link>
        <Link to='/login'>
          <button>Login</button>
        </Link>
      </div>
      <Outlet />
    </div>
  );
}
