
import axios from 'axios';
import {
  Base_Url,
  apiExtension,
  Get_All_Product,
  Update_Product,
  Create_Product,
  Get_Product_ById,
} from '../../Component/BaseUrl';

const api = axios.create({
  baseURL: Base_Url + apiExtension,
});

export const getAllProducts = async () => {
  try {
    const response = await api.get(Get_All_Product);
    return response.data;
  } catch (error) {
    throw error;
  }
};

export const getProductById = async (productId) => {
  try {
    const response = await api.get(`https://localhost:7279/api/Product/GetById?id=${productId}`);
    return response.data; 
  } catch (error) {
    console.error('Error fetching product by ID:', error);
    throw error; 
  }
};
export const createProduct = async (productData) => {
  try {
    const response = await api.post(Create_Product, productData);
    return response.data;
  } catch (error) {
    throw error;
  }
};

export const updateProduct = async (productId, updatedProductData) => {
  try {
    const response = await api.put(`${Update_Product}/${productId}`, updatedProductData);
    return response.data;
  } catch (error) {
    throw error;
  }
};

export const deleteProduct = async (productId) => {
  try {
    const response = await api.delete(`https://localhost:7279/api/Product/Delete?id=${productId}`);
    return response.data;
  } catch (error) {
    throw error;
  }
};


export const addToCart = async (productId, dispatch) => {
  try {
    const response = await api.post('https://localhost:7279/api/Cart/Insertcart', { productId });

    
    const updatedCartItems = await getAllCartItems();

    
    dispatch(updateCartItem(updatedCartItems));

    return response.data;
  } catch (error) {
    throw error;
  }
};

export const getAllCartItems = async () => {
  try {
    const response = await api.get('https://localhost:7279/api/Cart/GetAllCart');
    console.log('Request Payload:', response.data);
    return response.data;
  } catch (error) {
    throw error;
  }
};


export const updateCartItem = async (productId, cartItems) => {
  try {
    if (!Array.isArray(cartItems)) {
      
      console.error('Invalid cartItems format. Expected an array.');
      return; 
    }

    console.log(cartItems);
    const transformedCartItems = cartItems.map(item => ({
      Id: item.id,
      productId: item.productId,
      quantity: item.quantity,
    }));

    const response = await api.put(`https://localhost:7279/api/Cart/UpdateCart/${productId}`, transformedCartItems);
    console.log(response.data);
    return response.data;
  } catch (error) {
    throw error;
  }
};

export const removeCartItem = async (cartId) => {
  try {
    const response = await fetch(`https://localhost:7279/api/Cart/DeleteCart?Id=${cartId}`, {
      method: 'DELETE',
      headers: {
        'Content-Type': 'application/json',
      },
    });
  if (!response.ok) {
      throw new Error('Failed to remove item from cart');
    }
     const data = await response.json();
     return data;
  } catch (error) {
    console.error('Error removing item from cart:', error);
    throw error;
  }
};

export const getCategoryNameByCartId = async (cartId) => {
  try {
    const response = await api.get(`https://localhost:7279/api/Condition/GetCategoryNameByCartId/${cartId}`);

    if (!response.ok) {
      throw new Error('Failed to fetch category name');
    }

    const data = await response.json();
    return data.categoryName;
  } catch (error) {
    console.error('Error fetching category name:', error);
    throw error;
  }
};

export const getAllCategories = async () => {
  const response = await fetch('https://localhost:7279/api/Category/GetAllCategory');
  const data = await response.json();
  return data;
};
