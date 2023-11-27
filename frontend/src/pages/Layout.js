import React, { useState, useEffect } from 'react';
import { Outlet, Link } from 'react-router-dom';
import Dropdown from 'react-bootstrap/Dropdown';
import './Layout.css';

export default function Layout() {
  const [dropdownVisible, setDropdownVisible] = useState(false);

  useEffect(() => {
    // Open the dropdown when the component mounts
    setDropdownVisible(true);
  }, []);

  const handleToggle = () => {
    setDropdownVisible(!dropdownVisible);
  };


  return (
    <div>
      <div className='navbar'>
        <Link to='/'>
          <button>Home</button>
        </Link>
        <Dropdown show={dropdownVisible} onToggle={handleToggle}>
          <Dropdown.Toggle variant="success" id="dropdown-basic">
            Properties
          </Dropdown.Toggle>

          <Dropdown.Menu>
            <Dropdown.Item>
              <Link to='/forsale'>
                <button>For Sale</button>
              </Link>
            </Dropdown.Item>
            <Dropdown.Item>
              <Link to='/torent'>
                <button>To Rent</button>
              </Link>
            </Dropdown.Item>
            <Dropdown.Item>
              <Link to='/newproperty'>
                <button>New Property</button>
              </Link>
            </Dropdown.Item>
            <Dropdown.Item>
              <Link to='/myproperties'>
                <button>My Properties</button>
              </Link>
            </Dropdown.Item>
          </Dropdown.Menu>
        </Dropdown>
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
