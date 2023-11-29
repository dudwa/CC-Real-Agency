import React, { useState, useEffect } from 'react';
import { Outlet, Link } from 'react-router-dom';
import './Layout.css';

export default function Layout() {
  const [dropdownVisible, setDropdownVisible] = useState(false);
  const [authenticated, setAuthenticated] = useState(false);

  useEffect(() => {
    
  }, [authenticated]);

  const handleToggle = () => {
    setDropdownVisible(!dropdownVisible);
  };

  function getUserFromCookie()
  {
    const tokenCookie = document.cookie
    .split('; ')
    .find(cookie => cookie.startsWith('token='));

    // Extract the value after the equal sign
    return tokenCookie ? tokenCookie.split('=')[1] : null;
  }

  const handleLogout = () =>
  {
    setAuthenticated(false);
    clearCookie('token');
    clearCookie('role');
    clearCookie('username');
  };

  function clearCookie(name) {
    document.cookie = `${name}=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/;`;
  };

  return (
    <div>
      <div className='navbar'>
        <Link to='/'>
          <button>Home</button>
        </Link>

        <div className={`dropdown ${dropdownVisible ? 'show' : ''}`}>
          <button onClick={handleToggle} className="dropdown-toggle" type="button" id="dropdown-basic">
            Properties
          </button>

          <div className="dropdown-menu">
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
        </div>

        <Link to='/faq'>
          <button>FAQ</button>
        </Link>
        <Link to='/about'>
          <button>About Us</button>
        </Link>
        {authenticated
          ? <button onClick={handleLogout}>Logout</button>
          : <Link to='/login'>
              <button>Login</button>
            </Link>}
      </div>
      <Outlet />
    </div>
  );
}
