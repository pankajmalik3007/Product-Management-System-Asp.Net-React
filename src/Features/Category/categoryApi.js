
import axios from 'axios';
import { Base_Url, apiExtension, Get_All_Category, Get_Category_ById, Create_Category, Update_Category, Delete_Category } from '../../Component/BaseUrl';

const api = axios.create({
  baseURL: Base_Url + apiExtension,
});

export const getAllCategories = async () => {
  try {
    const response = await api.get(Get_All_Category);
    return response.data;
  } catch (error) {
    throw error;
  }
};

export const getCategoryById = async (categoryId) => {
  try {
    const response = await api.get(`${Get_Category_ById}/${categoryId}`);
    return response.data;
  } catch (error) {
    throw error;
  }
};

export const createCategory = async (categoryData) => {
  try {
    const response = await api.post(Create_Category, categoryData);
    return response.data;
  } catch (error) {
    throw error;
  }
};


export const updateCategory = async (categoryId, updatedCategoryData) => {
    try {
      const response = await api.put(Update_Category, { id: categoryId, ...updatedCategoryData });
      return response.data;
    } catch (error) {
      throw error;
    }
  };
  export const deleteCategory = async (productId) => {
    try {
      const response = await api.delete(`https://localhost:7279/api/Category/DeleteCategory?Id=${productId}`);
      console.log(response); 
      return response.data;
    } catch (error) {
      throw error;
    }
  };

