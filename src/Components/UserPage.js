import React, { useState } from 'react';

import './UserPage.css';

import { FaEnvelope, FaLock } from 'react-icons/fa';

import { Link, useNavigate } from 'react-router-dom';




function UserPage() {

  const [email, setEmail] = useState('');

  const [password, setPassword] = useState('');

  const [isLoggedIn, setIsLoggedIn] = useState(false);

  const [errorMessage, setErrorMessage] = useState('');

  const navigate = useNavigate();




  const handleEmailChange = (e) => {

    setEmail(e.target.value);

  }




  const handlePasswordChange = (e) => {

    setPassword(e.target.value);

  }




  const handleLogin = (e) => {

    e.preventDefault();

    // Simulate login

    if (email === 'user@123.com' && password === 'user') {

      setIsLoggedIn(true);

      setErrorMessage('');

      // Navigate to the home page after successful login

      navigate('/User');

    } else {

      setIsLoggedIn(false);

      setErrorMessage('Invalid email or password');

    }

  }




  return (

    <div className="login-page">

      <div className="login-card">

        <h1 className="login-title">User Login</h1>

        <form onSubmit={handleLogin}>

          <div className="login-input-container">

            <FaEnvelope className="login-icon" />

            <input type="email" value={email} onChange={handleEmailChange} placeholder="Email" required />

          </div>

          <div className="login-input-container">

            <FaLock className="login-icon" />

            <input type="password" value={password} onChange={handlePasswordChange} placeholder="Password" required />

          </div>

          {errorMessage && <p className="error-message">{errorMessage}</p>}

          <button type="submit" className="login-button">Log in</button>

        </form>

        {!isLoggedIn &&

          <div className="login-links">

            <a href="#forgot-password">Forgot password?</a>

            <span> || </span>

            <Link to="/register">Register</Link>

          </div>

        }

        {isLoggedIn &&

          <div className="login-links">

            <p>You are now logged in!</p>

          </div>

        }

      </div>

    </div>

  );

}




export default UserPage;