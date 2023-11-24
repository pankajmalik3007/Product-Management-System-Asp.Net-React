// orderSlice.js
import { createSlice } from '@reduxjs/toolkit';

const initialState = {
  orders: [],
  loading: false,
  error: null,
};

const orderSlice = createSlice({
  name: 'order',
  initialState,
  reducers: {
    setLoading: (state, action) => {
      state.loading = action.payload;
    },
    setError: (state, action) => {
      state.error = action.payload;
    },
    setOrders: (state, action) => {
      state.orders = action.payload;
    },
    addOrder: (state, action) => {
      state.orders.push(action.payload);
    },
    updateOrder: (state, action) => {
      const { id, updatedOrderData } = action.payload;
      const existingOrderIndex = state.orders.findIndex(order => order.id === id);
      if (existingOrderIndex !== -1) {
        state.orders[existingOrderIndex] = { ...state.orders[existingOrderIndex], ...updatedOrderData };
      }
    },
    deleteOrder: (state, action) => {
      const orderId = action.payload;
      state.orders = state.orders.filter(order => order.id !== orderId);
    },
  },
});

export const { setLoading, setError, setOrders, addOrder, updateOrder, deleteOrder } = orderSlice.actions;
export const selectOrders = state => state.order.orders;
export const selectLoading = state => state.order.loading;
export const selectError = state => state.order.error;
export default orderSlice.reducer;
