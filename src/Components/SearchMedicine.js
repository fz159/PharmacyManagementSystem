import React, { useState, useEffect } from 'react';
import './SearchMedicine.css';

const SearchMedicine = () => {
  const [medicines, setMedicines] = useState([]);
  const [searchTerm, setSearchTerm] = useState('');

  useEffect(() => {
    async function fetchData() {
      const response = await fetch('https://localhost:44381/api/Medicine');
      const data = await response.json();
      setMedicines(data);
    }

    fetchData();
  }, []);

  const filteredMedicines = medicines.filter((medicine) => {
    if (medicine.medicine_name && medicine.medicine_name.toLowerCase().includes(searchTerm.toLowerCase())) {
      return true;
    }
    return false;
  });

  const handleSearch = () => {
    // do something when the user clicks the search button
    console.log('search clicked');
  };

  return (
    <div className='Design'>
      <h2>Medicine List</h2>
      <div className="search-bar">
        <input
          type="text"
          placeholder="Search by Name"
          value={searchTerm}
          onChange={(event) => setSearchTerm(event.target.value)}
        />
        <button type="button" onClick={handleSearch}>Search</button>
      </div>
      <table className="medicine-list">
        <thead>
          <tr>
            <th>Name</th>
            <th>Type</th>
            <th>Price</th>
            <th>Quantity</th>
          </tr>
        </thead>
        <tbody>
          {filteredMedicines.map((medicine) => (
            <tr key={medicine.id}>
              <td>{medicine.medicine_name}</td>
              <td>{medicine.medicine_type}</td>
              <td>{medicine.price}</td>
              <td>{medicine.quantity}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default SearchMedicine;