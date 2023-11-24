
import { createSlice } from '@reduxjs/toolkit';


const initialState = {
  products: [],
  loading: false,
  error: null,
};

const productSlice = createSlice({
  name: 'product',
  initialState,
  reducers: {
    setLoading: (state, action) => {
      state.loading = action.payload;
    },
    setError: (state, action) => {
      state.error = action.payload;
    },
    setProducts: (state, action) => {
      state.products = action.payload;
    },
    addProduct: (state, action) => {
      state.products.push(action.payload);
    },
    updateProduct: (state, action) => {
      const { id, updatedProductData } = action.payload;
      const existingProductIndex = state.products.findIndex((product) => product.id === id);
      if (existingProductIndex !== -1) {
        state.products[existingProductIndex] = { ...state.products[existingProductIndex], ...updatedProductData };
      }
    },
    deleteProduct: (state, action) => {
      const productId = action.payload;
      state.products = state.products.filter((product) => product.id !== productId);
    },
  },
});

export const { setLoading, setError, setProducts, addProduct, updateProduct, deleteProduct } = productSlice.actions;
export const selectProducts = (state) => state.product.products;
export const selectLoading = (state) => state.product.loading;
export const selectError = (state) => state.product.error;

export default productSlice.reducer;
