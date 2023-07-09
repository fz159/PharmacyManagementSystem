import React, { useState } from "react";
import './CreateAccount.css';

const CreateAccount = () => {

  const [admin, setAdmin] = useState({
    admin_name: "",
    admin_mailid: "",
    admin_password: "",
    add_medicine: "",
  });

  const handleInputChange = (event) => {
    const { name, value } = event.target;
    setAdmin({ ...admin, [name]: value });
  };

  const handleSubmit = async (event) => {
    event.preventDefault();
    try {
      const response = await fetch(
        `https://localhost:44381/api/Admin`,
        {
          method: "POST",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify(admin),
        }
      );
      if (response.ok) {
        console.log("Account created successfully");
      } else {
        console.error("Account creation failed");
      }
    } catch (error) {
      console.error(error);
    }
  };

  return (
    <div className="CreateAccount">
      <h2>Create Account</h2>
      <form onSubmit={handleSubmit}>
        <div className="form-field">
          <label htmlFor="admin_name">Name:</label>
          <input
            type="text"
            id="admin_name"
            name="admin_name"
            value={admin.admin_name}
            onChange={handleInputChange}
          />
        </div>
        <div className="form-field">
          <label htmlFor="admin_mailid">Email:</label>
          <input
            type="text"
            id="admin_mailid"
            name="admin_mailid"
            value={admin.admin_mailid}
            onChange={handleInputChange}
          />
        </div>
        <div className="form-field">
          <label htmlFor="admin_password">Password:</label>
          <input
            type="password"
            id="admin_password"
            name="admin_password"
            value={admin.admin_password}
            onChange={handleInputChange}
          />
        </div>
        <div className="form-field">
          <label htmlFor="add_medicine">Add Medicine:</label>
          <input
            type="text"
            id="add_medicine"
            name="add_medicine"
            value={admin.add_medicine}
            onChange={handleInputChange}
          />
        </div>
        <button type="submit">Create Account</button>
      </form>
    </div>
  );
};

export default CreateAccount;