import { useState } from 'react';
import './Feedback.css';

function RatingSystem() {
  const [Service_rating, setService_rating] = useState(0);
  const [feedbacks, setFeedbacks] = useState('');
  const [feedbackSubmitted, setFeedbackSubmitted] = useState(false);

  const handleRatingChange = (event) => {
    setService_rating(parseInt(event.target.value));
  };

  const handleFeedbackChange = (event) => {
    setFeedbacks(event.target.value);
  };

  const handleSubmit = () => {
    const data = { Service_rating, feedbacks };
    fetch('https://localhost:44381/api/Feedback', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(data)
    })
      .then(response => response.json())
      .then(result => {
        console.log('Rating submitted:', result);
        setFeedbackSubmitted(true);
      })
      .catch(error => console.error('Error submitting rating:', error));
  };

  return (
    <div className="rating">
      <h2>Please give your valuable Feedback:</h2>
      <select value={Service_rating} onChange={handleRatingChange}>
        <option value="1">1</option>
        <option value="2">2</option>
        <option value="3">3</option>
        <option value="4">4</option>
        <option value="5">5</option>
      </select>
      <p>Service Rating: {Service_rating}</p>
      <textarea id="feedback" placeholder="Please leave your feedback here" rows="3" value={feedbacks} onChange={handleFeedbackChange}></textarea>
      {feedbackSubmitted ? <p>The feedback has been successfully submitted.</p> : null}
      <button id="submit" onClick={handleSubmit}>{feedbackSubmitted ? 'Submitted' : 'Submit'}</button>
    </div>
  );
}

export default RatingSystem;