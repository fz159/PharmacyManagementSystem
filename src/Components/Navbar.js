import React from 'react';
import './Navbar.css';

function App() {
      
  return (
    <div className="container">
      <marquee className="marquee-text">SALE!SALE!SALE!!!!   Hey there, currently 50% Discount sale is going sitewide!! Make sure to grab them before its too late! </marquee>
      <nav className="navbar">
        <div className="navbar-logo">
          <img src="tablet.jpg" alt="pharmacylogo" />
        </div>
        <ul className="navbar-links">
          <li className="navbar-link">
            <a href="HomePage">Home</a>
          </li>
          <li className="navbar-link">
            <a href="AdminPage">Admin</a>
          </li>
          <li className="navbar-link">
            <a href="UserPage">User</a>
          </li>
          <li className="navbar-link">
            <a href="About">About</a>
          </li>
          <li className="navbar-link">
            <a href="HomePage">Logout</a>
          </li>
        </ul>
      </nav>
    </div>
  );
}

export default App;