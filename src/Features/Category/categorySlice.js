// categorySlice.js
import { createSlice } from '@reduxjs/toolkit';

const initialState = {
  categories: [],
  loading: false,
  error: null,
};

const categorySlice = createSlice({
  name: 'category',
  initialState,
  reducers: {
    setLoading: (state, action) => {
      state.loading = action.payload;
    },
    setError: (state, action) => {
      state.error = action.payload;
    },
    setCategories: (state, action) => {
      state.categories = action.payload;
    },
  },
});

export const { setLoading, setError, setCategories } = categorySlice.actions;
export const selectCategories = state => state.category.categories;
export const selectLoading = state => state.category.loading;
export const selectError = state => state.category.error;
export default categorySlice.reducer;
