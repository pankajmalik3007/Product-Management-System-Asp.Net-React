
import React, { useEffect, useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { selectCartItems, updateCartItem } from './cartSlice';
import { getAllCartItems, getProductById, removeCartItem } from './enrollProduct';
import './CartProduct.css';
const CartProduct = () => {
  const cartItems = useSelector(selectCartItems);
  const dispatch = useDispatch();
  const [cartWithDetails, setCartWithDetails] = useState([]);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const data = await getAllCartItems();
        console.log(cartWithDetails)
  
        const cartDetails = await Promise.all(
          data.map(async (item) => {
            const [productDetails] = await Promise.all([
              getProductDetails(item.productId),
            ]);
            return { ...item, ...productDetails };
          })
        );
        dispatch(updateCartItem(cartDetails));
        setCartWithDetails(cartDetails);
      } catch (error) {
     }
    };

    fetchData();
  }, [dispatch]);

  const getProductDetails = async (productId) => {
    try {
      const product = await getProductById(productId);

      
      const details = {
        productName: product.productName || 'Unknown',
        price: product.price || 0,
        stockQuantity: product.stockQuantity || 0,
      };

      return details;
    } catch (error) {
      console.error('Error fetching product details:', error);
      return {
        productName: 'Unknown',
        price: 0,
        stockQuantity: 0,
      };
    }
  };


  const handleRemoveItem = async (cartId) => {
    try {
      await removeCartItem(cartId);
      const updatedCartItems = cartWithDetails.filter(item => item.Id !== cartId);
      dispatch(updateCartItem(updatedCartItems));
      setCartWithDetails(updatedCartItems);
    } catch (error) {
    }
  };
  return (
    <div>
      <h2>Cart</h2>
       {cartWithDetails.length === 0 ? (
        <p>Your cart is empty.</p>
      ) : (
        <table>
          <thead>
            <tr>
              <th>Product ID</th>
              <th>Product Name</th>
              <th>Price</th>
              <th>Stock Quantity</th>
              <th>Action</th>
            </tr>
          </thead>
          <tbody>
            {cartWithDetails.map((item) => (
              <tr key={item.productId}>
                <td>{item.productId}</td>
                <td>{item.productName}</td>
                <td>{item.price}</td>
                <td>{item.stockQuantity}</td>
                <td>
                  <button onClick={() => handleRemoveItem(item.id)}>Remove</button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      )}
    </div>
  );
};

export default CartProduct;
