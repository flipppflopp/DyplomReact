import React from 'react';
import './VolonteerPopup.css';


function VolonteerPopup(props) {
  return (
    <div>
      {props.isPopupOpen && (
        <div className="popup">
          <div className="popup-content">
            <h2>Popup Content</h2>
            <p>This is the content of the popup.</p>
            <button onClick={props.togglePopup}>Close</button>
          </div>
        </div>
      )}
    </div>
  );
}

export default VolonteerPopup;
