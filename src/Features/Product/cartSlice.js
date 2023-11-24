
import { createSlice } from '@reduxjs/toolkit';

const initialState = {
  cartItems: [],
};

const cartSlice = createSlice({
  name: 'cart',
  initialState,
  reducers: {
    setCartItems: (state, action) => {
      state.cartItems = action.payload;
    },
    updateCartItem: (state, action) => {
      state.cartItems = action.payload;
    },
  },
});

export const { setCartItems, updateCartItem } = cartSlice.actions;
export const selectCartItems = (state) => state.cart.cartItems;

export default cartSlice.reducer;
