import React from 'react';

import { Link } from 'react-router-dom';

import './User.css';


function User() {

  return (

    <div className="user-container">

      <h1 className="user-title">User Dashboard</h1>

      <div className="user-buttons">

        <Link to="/MedicineList" className="admin-button">View Medicine</Link>

        <Link to="/SearchMedicine" className="admin-button">Search Medicine</Link>

        <Link to="/RequestMedicine" className="admin-button">Request Medicine</Link>
        
        <Link to="/Feedback" className="admin-button">Feedback</Link>

        

      </div>

    </div>

  );

}

export default User;