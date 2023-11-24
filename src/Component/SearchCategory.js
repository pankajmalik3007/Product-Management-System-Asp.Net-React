
import React, { useState } from 'react';
import TextField from '@mui/material/TextField';

const SearchCategory = () => {
  const [cartId, setCartId] = useState('');
  const [categoryName, setCategoryName] = useState('');
  const [error, setError] = useState('');

  const handleCartIdChange = (e) => {
    setCartId(e.target.value);
    setCategoryName(''); 
    setError('');
  };

  const handleSearchCart = async () => {
  try {
    const response = await fetch(`https://localhost:7279/api/Condition/GetCategoryNameByCartId/${cartId}`);
    
    if (!response.ok) {
      throw new Error(`Failed to fetch category name. Status: ${response.status}`);
    }

    const contentType = response.headers.get('content-type');
    
    if (contentType && contentType.includes('application/json')) {
      const data = await response.json();
      console.log('Category Name API Response:', data);
      setCategoryName(JSON.stringify(data, null, 2)); 
      setError('');
    } else if (contentType && contentType.includes('text/plain')) {
      const textData = await response.text();
      console.log('Plain Text API Response:', textData);
      setCategoryName(textData);
      setError('');
    } else {
      setCategoryName('');
      setError(`Invalid response format. Content-Type: ${contentType}`);
    }
  } catch (error) {
    console.error('Error fetching category name:', error);
    setCategoryName('');
    setError(`Error fetching category name: ${error.message}`);
  }
};

  return (
    <div>
    
      <div>
        <TextField
          label="Search Cart ID"
          variant="outlined"
          fullWidth
          value={cartId}
          onChange={handleCartIdChange}
        />
        <button onClick={handleSearchCart}>Search Cart</button>
      </div>

      {error && <p style={{ color: 'red' }}>{error}</p>}

      {categoryName && (
        <div>
          <p>Category Name: </p>
          <pre>{categoryName}</pre>
        </div>
      )}
    </div>
  );
};

export default SearchCategory;
