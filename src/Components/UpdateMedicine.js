import React, { useState } from "react";
import './UpdateMedicine.css';

const UpdateMedicine = () => {

  const [medicine, setMedicine] = useState({
    medicine_id: "",
    medicine_name:"",
    medicine_type:"",
    price: "",
    quantity: "",
  });
  const [successMessage, setSuccessMessage] = useState("");
  const handleInputChange = (event) => {
    const { name, value } = event.target;
    setMedicine({ ...medicine, [name]: value });
  };

  const handleSubmit = async (event) => {
    event.preventDefault();
    try {
      const putresponse = await fetch(
        `https://localhost:44381/api/Medicine/${medicine.medicine_id}`,
        {
          method: "PUT",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify(medicine),
        }
      );
      
      
      if (putresponse.status === 200) {
        setSuccessMessage("Medicine added successfully!");
        
      } else {
        setSuccessMessage("Failed to add medicine. Please try again.");
      }
    } catch (error) {
      console.log(error);
      setSuccessMessage("An error occurred. Please try again.");
    }
  };

  return (
    <div className="UpdateMedicine">
      <h2>Update Medicine</h2>
      {successMessage && <p>{successMessage}</p>}
      <form onSubmit={handleSubmit}>
        <div className="form-field">
          <label htmlFor="medicine_id">Medicine ID:</label>
          <input
            type="text"
            id="medicine_id"
            name="medicine_id"
            value={medicine.medicine_id}
            onChange={handleInputChange}
          />
        </div>
        <div className="form-field">
          <label htmlFor="medicine_name">Medicine Name:</label>
          <input
            type="text"
            id="medicine_name"
            name="medicine_name"
            value={medicine.medicine_name}
            onChange={handleInputChange}
          />
        </div>
        <div className="form-field">
          <label htmlFor="medicine_type">Medicine Type:</label>
          <input
            type="text"
            id="medicine_type"
            name="medicine_type"
            value={medicine.medicine_type}
            onChange={handleInputChange}
          />
        </div>
        <div className="form-field">
          <label htmlFor="price">Price:</label>
          <input
            type="text"
            id="price"
            name="price"
            value={medicine.price}
            onChange={handleInputChange}
          />
        </div>
        <div className="form-field">
          <label htmlFor="quantity">Quantity:</label>
          <input
            type="text"
            id="quantity"
            name="quantity"
            value={medicine.quantity}
            onChange={handleInputChange}
          />
        </div>
        <button type="submit">Update</button>
      </form>
    </div>
  );
};

export default UpdateMedicine;