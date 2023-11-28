import React, { useState } from 'react';
import { Outlet, Link } from 'react-router-dom';
import './Layout.css';

export default function Layout() {
  const [dropdownVisible, setDropdownVisible] = useState(false);

  const handleToggle = () => {
    setDropdownVisible(!dropdownVisible);
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
        <Link to='/login'>
          <button>Login</button>
        </Link>
      </div>
      <Outlet />
    </div>
  );
}
