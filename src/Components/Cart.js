
import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import './Cart.css';

const Cart = () => {
  const { medicineId } = useParams();
  const [medicine, setMedicine] = useState(null);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await fetch(`https://localhost:44381/api/Medicine/${medicineId}`);
        const data = await response.json();
        setMedicine(data);
      } catch (error) {
        console.log(error);
      }
    };

    fetchData();
  }, [medicineId]);

  return (
    <div className="medicine-details">
      {medicine ? (
        <div>
          <h2>{medicine.medicine_name}</h2>
          <p>Medicine Type: {medicine.medicine_type}</p>
          <p>Price: {medicine.price}</p>
          <p>Quantity: {medicine.quantity}</p>
        </div>
      ) : (
        <p>Loading...</p>
      )}
    </div>
  );
};

export default Cart;