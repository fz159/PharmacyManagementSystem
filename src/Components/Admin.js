import React from 'react';

import { Link } from 'react-router-dom';

import './Admin.css';




function Admin() {

  return (

    <div className="admin-container">

      <h1 className="admin-title">Admin Dashboard</h1>

      <div className="admin-buttons">

        <Link to="/MedicineList" className="admin-button">View Medicine</Link>

        <Link to="/AddMedicine" className="admin-button">Add Medicine</Link>

        <Link to="/UpdateMedicine" className="admin-button">Update Medicine</Link>

        <Link to="/RemoveMedicine" className="admin-button">Remove Medicine</Link>

        <Link to="/NewRequest" className="admin-button">New Requests</Link>

        <Link to="/ViewFeedback" className="admin-button">View Feedbacks</Link>

      </div>

    </div>

  );

}




export default Admin;