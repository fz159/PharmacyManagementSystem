import React, { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import "./MedicineList.css";

const MedicineList = () => {
const [medicines, setMedicines] = useState([]);

useEffect(() => {
const fetchData = async () => {
try {
const response = await fetch("https://localhost:44381/api/Medicine");
const data = await response.json();
setMedicines(data);
} catch (error) {
console.log(error);
}
};

fetchData();
}, []);

return (
<div className="medicine-list">
<h2>Medicine List</h2>
{medicines.length > 0 ? (
<table>
<thead>
<tr>
<th>Medicine Name</th>
<th>Medicine Type</th>
<th>Price</th>
<th>Quantity</th>
</tr>
</thead>
<tbody>
{medicines.map((medicine) => (
<tr key={medicine.id}>
<td>{medicine.medicine_name}</td>
<td>{medicine.medicine_type}</td>
<td>{medicine.price}</td>
<td>{medicine.quantity}</td>
</tr>
))}
</tbody>
</table>
) : (
<p>No medicines found.</p>
)}
</div>
);
};
export default MedicineList;