import React, { useState } from 'react';
import axios from 'axios';
import './RemoveMedicine.css';

const RemoveMedicine = () => {
  const [id, setMedicineId] = useState('');
  const [error, setError] = useState(null);
  const [success, setSuccess] = useState(false);

  const handleInputChange = e => {
    setMedicineId(e.target.value);
  };

  const handleFormSubmit = async e => {
    e.preventDefault();

    try {
      await axios.delete(`https://localhost:44381/api/Medicine/${id}`);
      setSuccess(true);
      setMedicineId('');
    } catch (error) {
      console.error('Error deleting medicine:', error);
      setError('Error deleting medicine. Please try again later.');
    }
  };

  return (
    <form onSubmit={handleFormSubmit}>
      <div>
        <label htmlFor="medicineId">Medicine ID:</label>
        <input type="text" id="id" value={id} onChange={handleInputChange} />
      </div>
      <button type="submit">Delete Medicine</button>
      {error && <p>{error}</p>}
      {success && <p>Medicine deleted successfully!</p>}
    </form>
  );
};

export default RemoveMedicine;