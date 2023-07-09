import React, { useState } from "react";
import "./RequestMedicine.css";

const RequestMedicine = () => {
  const [medicineName, setMedicineName] = useState("");
  const [medicineType, setMedicineType] = useState("");
  const [quantity, setQuantity] = useState("");
  const [successMessage, setSuccessMessage] = useState("");

  const handleSubmit = async () => {
    const data = {
      Medicine_name: medicineName,
      Medicine_type: medicineType,
      Quantity: parseInt(quantity),
    };
    try {
      const postResponse = await fetch(
        "https://localhost:44381/api/Request",
        {
          method: "POST",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify(data),
        }
      );

      if (postResponse.status === 200) {
        setSuccessMessage("Medicine requested successfully!");
        setMedicineName("");
        setMedicineType("");
        setQuantity("");
      } else {
        setSuccessMessage("Failed to request medicine. Please try again.");
      }
    } catch (error) {
      console.log(error);
      setSuccessMessage("An error occurred. Please try again.");
    }
  };

  return (
    <div className="request-medicine-container">
      <h2 className="request-medicine-heading">Request Medicine</h2>
      {successMessage && <p className="request-medicine-message">{successMessage}</p>}
      <form className="request-medicine-form" onSubmit={handleSubmit}>
        <div className="request-medicine-input-container">
          <label className="request-medicine-label" htmlFor="medicineName">Medicine Name:</label>
          <input
            className="request-medicine-input"
            type="text"
            id="medicineName"
            value={medicineName}
            onChange={(e) => setMedicineName(e.target.value)}
            required
          />
        </div>
        <div className="request-medicine-input-container">
          <label className="request-medicine-label" htmlFor="medicineType">Medicine Type:</label>
          <input
            className="request-medicine-input"
            type="text"
            id="medicineType"
            value={medicineType}
            onChange={(e) => setMedicineType(e.target.value)}
            required
          />
        </div>
        <div className="request-medicine-input-container">
          <label className="request-medicine-label" htmlFor="quantity">Quantity:</label>
          <input
            className="request-medicine-input"
            type="text"
            id="quantity"
            value={quantity}
            onChange={(e) => setQuantity(e.target.value)}
            required
          />
        </div>
        <button className="request-medicine-button" type="submit">Request Medicine</button>
      </form>
      {successMessage && <p className="request-medicine-message">{successMessage}</p>}
    </div>
  );
};

export default RequestMedicine;