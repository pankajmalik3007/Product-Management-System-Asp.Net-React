// orderItemSlice.js
import { createSlice } from '@reduxjs/toolkit';

const initialState = {
  orderItems: [],
  loading: false,
  error: null,
};

const orderItemSlice = createSlice({
  name: 'orderItem',
  initialState,
  reducers: {
    setLoading: (state, action) => {
      state.loading = action.payload;
    },
    setError: (state, action) => {
      state.error = action.payload;
    },
    setOrderItems: (state, action) => {
      state.orderItems = action.payload;
    },
    addOrderItem: (state, action) => {
      state.orderItems.push(action.payload);
    },
    updateOrderItem: (state, action) => {
      const { id, updatedOrderItemData } = action.payload;
      const existingOrderItemIndex = state.orderItems.findIndex(orderItem => orderItem.id === id);
      if (existingOrderItemIndex !== -1) {
        state.orderItems[existingOrderItemIndex] = { ...state.orderItems[existingOrderItemIndex], ...updatedOrderItemData };
      }
    },
    deleteOrderItem: (state, action) => {
      const orderItemId = action.payload;
      state.orderItems = state.orderItems.filter(orderItem => orderItem.id !== orderItemId);
    },
  },
});

export const { setLoading, setError, setOrderItems, addOrderItem, updateOrderItem, deleteOrderItem } = orderItemSlice.actions;
export const selectOrderItems = state => state.orderItem.orderItems;
export const selectLoading = state => state.orderItem.loading;
export const selectError = state => state.orderItem.error;
export default orderItemSlice.reducer;
