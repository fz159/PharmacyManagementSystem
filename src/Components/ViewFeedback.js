import React, { useEffect, useState } from "react";
import "./ViewFeedback.css";

const ViewFeedback = () => {
  const [feedbacks, setFeedbacks] = useState([]);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await fetch("https://localhost:44381/api/Feedback");
        const data = await response.json();
        setFeedbacks(data);
      } catch (error) {
        console.log(error);
      }
    };

    fetchData();
  }, []);

  return (
    <div className="feedback-list">
      <h2>Feedback List</h2>
      {feedbacks.length > 0 ? (
        <table>
          <thead>
            <tr>
              <th>Service Rating</th>
              <th>Feedback</th>
            </tr>
          </thead>
          <tbody>
            {feedbacks.map((feedback) => (
              <tr key={feedback.id}>
                <td>{feedback.service_rating}</td>
                <td>{feedback.feedbacks}</td>
              </tr>
            ))}
          </tbody>
        </table>
      ) : (
        <p>No feedbacks found.</p>
      )}
    </div>
  );
};

export default ViewFeedback;