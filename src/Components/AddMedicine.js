import React, { useState } from "react";
import "./AddMedicine.css";

const AddMedicine = () => {
  const [medicine_name, setMedicineName] = useState("");
  const [medicine_type, setMedicineType] = useState("");
  const [price, setPrice] = useState("");
  const [quantity, setQuantity] = useState("");
  const [successMessage, setSuccessMessage] = useState("");

  const handleSubmit = async () => {
    const data = {
      medicine_name,
      medicine_type,
      price: parseInt(price),
      quantity: parseInt(quantity),
    };

    try {
      const postResponse = await fetch("https://localhost:44381/api/Medicine", {
        method: "POST",
        headers: {
          "Content-Type": "application/json"
        },
        body: JSON.stringify(data)
      });

      if (postResponse.status === 200) {
        setSuccessMessage("Medicine added successfully!");
        setMedicineName("");
        setMedicineType("");
        setPrice("");
        setQuantity("");
      } else {
        setSuccessMessage("Failed to add medicine. Please try again.");
      }
    } catch (error) {
      console.log(error);
      setSuccessMessage("An error occurred. Please try again.");
    }
  };

  return (
    <div>
      <h2>Add Medicine</h2>
      
      <div>
        <label htmlFor="MedicineName">Medicine Name:</label>
        <input
          type="text"
          id="MedicineName"
          value={medicine_name}
          onChange={(e) => setMedicineName(e.target.value)}
        />
      </div>
      <div>
        <label htmlFor="medicineType">Medicine Type:</label>
        <input
          type="text"
          id="medicineType"
          value={medicine_type}
          onChange={(e) => setMedicineType(e.target.value)}
        />
      </div>
      <div>
        <label htmlFor="price">Price:</label>
        <input
          type="text"
          id="price"
          value={price}
          onChange={(e) => setPrice(e.target.value)}
        />
      </div>
      <div>
        <label htmlFor="quantity">Quantity:</label>
        <input
          type="text"
          id="quantity"
          value={quantity}
          onChange={(e) => setQuantity(e.target.value)}
        />
      </div>
      <button onClick={handleSubmit}>Add Medicine</button>
      {successMessage && <p>{successMessage}</p>}
    </div>
  );
};

export default AddMedicine;