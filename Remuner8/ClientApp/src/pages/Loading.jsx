import React from 'react';

const Loading = () => {
  return (
    <div className="loading text-center cover-page">
      <div className="spinner">
        <span
          role="img"
          aria-label="loading"
          style={{ fontSize: '35px' }}
        ></span>
      </div>
    </div>
  );
};

export default Loading;
