
import axios from 'axios';
import { Base_Url, apiExtension, Get_All_Order, Update_Order, Create_Order} from '../../Component/BaseUrl';

const api = axios.create({
  baseURL: Base_Url + apiExtension,
});

export const getAllOrders = async () => {
  try {
    const response = await api.get(Get_All_Order);
    console.log(response);
    return response.data;
  } catch (error) {
    throw error;
  }
};

export const createOrder = async (orderData) => {
  try {
    const response = await api.post(Create_Order, orderData);
    return response.data;
  } catch (error) {
    throw error;
  }
};

export const updateOrder = async (orderId, updatedOrderData) => {
  try {
    const response = await api.put(Update_Order, { id: orderId, ...updatedOrderData });
    return response.data;
  } catch (error) {
    throw error;
  }
};
export const deleteOrder = async (productId) => {
  try {
    const response = await api.delete(`https://localhost:7279/api/Order/DeleteOrder?Id=${productId}`);
    console.log(response); // Log the response
    return response.data;
  } catch (error) {
    throw error;
  }
};

