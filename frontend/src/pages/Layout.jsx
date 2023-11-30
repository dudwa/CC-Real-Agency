import React, { useState, useEffect } from 'react';
import { Outlet, Link, Navigate, useNavigate } from 'react-router-dom';
import '../App.css';
import Cookies from 'js-cookie';

export default function Layout({authenticated, setAuthenticated}) {

  const [dropdownVisible, setDropdownVisible] = useState(false);
  const navigate = useNavigate;

  const handleToggle = () => {
    setDropdownVisible(!dropdownVisible);
  };

  const handleLogout = () =>
  {
    Cookies.remove('token');
    Cookies.remove('role');
    Cookies.remove('username');
    setAuthenticated(false);
    //navigate('/');
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
