// CategoryList.js
import React, { useEffect, useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { Modal, Button, TextField } from '@mui/material';
import {
  getAllCategories,
  createCategory,
  updateCategory as updateCategoryAPI,
  deleteCategory as deleteCategoryAPI,
} from './categoryApi';
import {
  selectLoading,
  selectError,
  selectCategories,
  setCategories,
  setLoading,
  setError,
} from './categorySlice';
import './CategoryList.css';

const CategoryList = () => {
  const dispatch = useDispatch();
  const categories = useSelector(selectCategories);
  const loading = useSelector(selectLoading);
  const error = useSelector(selectError);
  const [isModalOpen, setIsModalOpen] = useState(false);
  const [modalMode, setModalMode] = useState('insert');
  const [selectedCategory, setSelectedCategory] = useState(null);
  const [categoryData, setCategoryData] = useState({
    id: null,
    categoryName: '',
  });

  useEffect(() => {
    const fetchData = async () => {
      try {
        dispatch(setLoading(true));
        const data = await getAllCategories();
        dispatch(setCategories(data));
      } catch (error) {
        dispatch(setError(error.message));
      } finally {
        dispatch(setLoading(false));
      }
    };

    fetchData();
  }, [dispatch]);

  const handleInsert = async () => {
    try {
      const savedCategory = await createCategory(categoryData);
      dispatch(setCategories([...categories, savedCategory]));
      handleCloseModal();
    } catch (error) {
      dispatch(setError(error.message));
    }
  };

  const handleUpdate = async () => {
    try {
      if (selectedCategory) {
        await updateCategoryAPI(selectedCategory.id, categoryData);
        dispatch(
          setCategories(
            categories.map((category) =>
              category.id === selectedCategory.id ? { ...category, ...categoryData } : category
            )
          )
        );
        handleCloseModal();
      }
    } catch (error) {
      dispatch(setError(error.message));
    }
  };

  const handleDelete = async () => {
    try {
      if (selectedCategory) {
        await deleteCategoryAPI(selectedCategory.id);
        dispatch(setCategories(categories.filter((category) => category.id !== selectedCategory.id)));
        handleCloseModal();
      }
    } catch (error) {
      dispatch(setError(error.message));
    }
  };

  const handleOpenModal = (mode, category) => {
    setIsModalOpen(true);
    setModalMode(mode);
    setSelectedCategory(category);
    if (category) {
      setCategoryData({ ...category });
    } else {
      setCategoryData({ id: null, categoryName: '' });
    }
  };

  const handleCloseModal = () => {
    setIsModalOpen(false);
    setModalMode('insert');
    setSelectedCategory(null);
    setCategoryData({ id: null, categoryName: '' });
  };

  return (
    <div className="category-list-container">
      <h2>Category List</h2>
      <Button variant="contained" color="primary" onClick={() => handleOpenModal('insert', null)}>
        Add Category
      </Button>
      {loading && <p>Loading...</p>}
      {error && <p className="error-message">Error: {error}</p>}
      {!loading && !error && categories.length > 0 && (
        <table className="category-table">
          <thead>
            <tr>
              <th>ID</th>
              <th>Category Name</th>
              <th>Actions</th>
            </tr>
          </thead>
          <tbody>
            {categories.map((category) => (
              <tr key={category.id}>
                <td>{category.id}</td>
                <td>{category.categoryName}</td>
                <td>
                  <Button
                    className="edit-button"
                    variant="contained"
                    color="primary"
                    onClick={() => handleOpenModal('update', category)}
                  >
                    Edit
                  </Button>
                  <Button
                    className="delete-button"
                    variant="contained"
                    color="secondary"
                    onClick={() => handleOpenModal('delete', category)}
                  >
                    Delete
                  </Button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      )}

      <Modal open={isModalOpen} onClose={handleCloseModal} className="modal">
        <div className="modal-content">
          <h2>
            {modalMode === 'insert'
              ? 'Add Category'
              : modalMode === 'update'
              ? 'Edit Category'
              : 'Delete Category'}
          </h2>
          <TextField
            label="Category Name"
            variant="outlined"
            fullWidth
            value={categoryData.categoryName}
            onChange={(e) => setCategoryData({ ...categoryData, categoryName: e.target.value })}
          />
          <div className="modal-buttons">
            {modalMode === 'insert' && (
              <Button className="save-button" onClick={handleInsert}>
                Save
              </Button>
            )}
            {modalMode === 'update' && (
              <Button className="update-button" onClick={handleUpdate}>
                Update
              </Button>
            )}
            {modalMode === 'delete' && (
              <Button className="delete-button" onClick={handleDelete}>
                Delete
              </Button>
            )}
            <Button variant="contained" onClick={handleCloseModal}>
              Cancel
            </Button>
          </div>
        </div>
      </Modal>
    </div>
  );
};

export default CategoryList;
