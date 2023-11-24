
import { configureStore } from '@reduxjs/toolkit';
import productReducer from '../Features/Product/ProductSlice';
import categoryReducer from '../Features/Category/categorySlice';
import orderReducer from '../Features/Order/orderSlice';
import orderItemReducer from '../Features/OrderItem/orderItemSlice';
import cartReducer from '../Features/Product/cartSlice' 

const store = configureStore({
  reducer: {
    product: productReducer,
    category: categoryReducer,
    order: orderReducer,
    orderItem: orderItemReducer,
    cart: cartReducer, 
  },
});

export default store;
