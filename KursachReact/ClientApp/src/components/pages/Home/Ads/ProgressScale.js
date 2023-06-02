import React, { useState } from 'react';
import Slider from 'rc-slider';
import 'rc-slider/assets/index.css';

function ProgressScale(props) {
    const [currentValue, setCurrentValue] = useState(props.collectedSum);
    
    const handleCurrentValueChange = (value) => {
      setCurrentValue(value);
    };
  
  
    return (
      <div>
        <Slider
          min={0}
          max={props.goalSum}
          disabled={true}
          value={currentValue}
          onChange={handleCurrentValueChange}
        />
      </div>
    );
  }
  
  export default ProgressScale;
  