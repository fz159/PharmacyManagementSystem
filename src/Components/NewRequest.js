import React, { useEffect, useState } from "react";
import "./NewRequest.css";

const NewRequest = () => {
const [requests, setRequests] = useState([]);

useEffect(() => {
const fetchData = async () => {
try {
const response = await fetch("https://localhost:44381/api/Request");
const data = await response.json();
setRequests(data);
} catch (error) {
console.log(error);
}
};
fetchData();
}, []);

return (
<div className="request-list">
<h2>New Requests</h2>
{requests.length > 0 ? (
<table>
<thead>
<tr>
<th>Request ID</th>
<th>Medicine Name</th>
<th>Medicine Type</th>
<th>Quantity</th>

</tr>
</thead>
<tbody>
{requests.map((request) => (
<tr key={request.id}>
<td>{request.request_id}</td>
<td>{request.medicine_name}</td>
<td>{request.medicine_type}</td>
<td>{request.quantity}</td>

</tr>
))}
</tbody>
</table>
) : (
<p>No new requests found.</p>
)}
</div>
);
};



///////Add Medicine


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
        {successMessage && <p>{successMessage}</p>}
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

export default NewRequest;