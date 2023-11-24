
import React, { useState } from 'react';
import TextField from '@mui/material/TextField';

const OrderSearch = () => {
  const [orderId, setOrderId] = useState('');
  const [productDetails, setProductDetails] = useState('');
  const [error, setError] = useState('');

  const handleOrderIdChange = (e) => {
    setOrderId(e.target.value);
    setProductDetails('');
    setError('');
  };

  const handleSearchOrder = async () => {
    try {
      const response = await fetch(`https://localhost:7279/api/Condition/GetProductByOrderId/${orderId}`);
      
      if (!response.ok) {
        throw new Error(`Failed to fetch product details. Status: ${response.status}`);
      }

      const contentType = response.headers.get('content-type');
      
      if (contentType && contentType.includes('application/json')) {
        const data = await response.json();
        console.log('Product Details API Response:', data);
        setProductDetails(JSON.stringify(data, null, 2)); 
        setError('');
      } else if (contentType && contentType.includes('text/plain')) {
        const textData = await response.text();
        console.log('Plain Text API Response:', textData);
        setProductDetails(textData);
        setError('');
      } else {
        setProductDetails('');
        setError(`Invalid response format. Content-Type: ${contentType}`);
      }
    } catch (error) {
      console.error('Error fetching product details:', error);
      setProductDetails('');
      setError(`Error fetching product details: ${error.message}`);
    }
  };

  return (
    <div>
      <div>
        <TextField
          label="Search Order ID"
          variant="outlined"
          fullWidth
          value={orderId}
          onChange={handleOrderIdChange}
        />
        <button onClick={handleSearchOrder}>Search Order</button>
      </div>

      {error && <p style={{ color: 'red' }}>{error}</p>}

      {productDetails && (
        <div>
          <p>Product Details: </p>
          <pre>{productDetails}</pre>
        </div>
      )}
    </div>
  );
};

export default OrderSearch;
