
import axios from 'axios';
import { Base_Url, apiExtension, Get_All_OrderItem, Create_OrderItem, Update_OrderItem, Delete_OrderItem } from '../../Component/BaseUrl';

const api = axios.create({
  baseURL: Base_Url + apiExtension,
});

export const getAllOrderItems = async () => {
  try {
    const response = await api.get(Get_All_OrderItem);
    return response.data;
  } catch (error) {
    throw error;
  }
};

export const createOrderItem = async (orderItemData) => {
  try {
    const response = await api.post(Create_OrderItem, orderItemData);
    return response.data;
  } catch (error) {
    throw error;
  }
};

export const updateOrderItem = async (orderItemId, updatedOrderItemData) => {
  try {
    const response = await api.put(Update_OrderItem, { id: orderItemId, ...updatedOrderItemData });
    return response.data;
  } catch (error) {
    throw error;
  }
};
export const deleteOrderItem = async (productId) => {
  try {
    const response = await api.delete(`https://localhost:7279/api/OrderItem/DeleteOrderItem?Id=${productId}`);
    console.log(response); 
    return response.data;
  } catch (error) {
    throw error;
  }
};

