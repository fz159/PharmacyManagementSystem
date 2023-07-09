import React, { useState, useEffect } from 'react';

const App = () => {
  const [showPopup, setShowPopup] = useState(false);

  useEffect(() => {
    setShowPopup(true);
  }, []);

  const handleClosePopup = () => {
    setShowPopup(false);
  };

  return (
    <div>
      {showPopup && (
        <div className="popup">
          <div className="popup-content">
            <h2>Welcome to our website!</h2>
            <p>Thanks for visiting us. We hope you enjoy your stay.</p>
            <button onClick={handleClosePopup}>Close</button>
          </div>
        </div>
      )}
      {/* rest of the app */}
    </div>
  );
};

export default App;