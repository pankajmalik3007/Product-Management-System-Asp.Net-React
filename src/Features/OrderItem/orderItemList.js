
import React, { useEffect, useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { Button, TextField, Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Paper, Modal } from '@mui/material';
import {
  getAllOrderItems,
  createOrderItem as createOrderItemAPI,
  updateOrderItem as updateOrderItemAPI,
  deleteOrderItem as deleteOrderItemAPI,
 
} from './orderItemApi';

import {
  selectOrderItems,
  setOrderItems,
  addOrderItem,
  updateOrderItem,
  deleteOrderItem,
} from './orderItemSlice';
import { getAllProducts } from '../Product/enrollProduct';
import { getAllOrders } from '../Order/orderApi';

const OrderItemList = () => {
  const dispatch = useDispatch();
  const orderItems = useSelector(selectOrderItems);
  const [modalData, setModalData] = useState({
    id: null,
    orderId: '',
    productId: '',
    quantity: '',
    unitPrice: '',
  });
  const [openModal, setOpenModal] = useState(false);
  const [orders, setOrders] = useState([]);
  const [products, setProducts] = useState([]);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const data = await getAllOrderItems();
        const orderData = await getAllOrders();
        const productData = await getAllProducts();
        dispatch(setOrderItems(data));
        setOrders(orderData);
        setProducts(productData);
      } catch (error) {
        console.error('Error fetching order items:', error);
      }
    };

    fetchData();
  }, [dispatch]);

  const getOrderDate = (orderId) => {
    const order = orders.find((order) => order.id === orderId);
    return order ? order.orderDate : 'N/A';
  };

  const getTotalAmount = (orderId) => {
    const order = orders.find((order) => order.id === orderId);
    return order ? order.totalAmount : 'N/A';
  };

  const getProductName = (productId) => {
    const product = products.find((product) => product.id === productId);
    return product ? product.productName : 'N/A';
  };

  const handleCreateOrderItem = async () => {
    try {
      const newOrderItem = await createOrderItemAPI(modalData);
      dispatch(addOrderItem(newOrderItem));
      handleCloseModal();
    } catch (error) {
      console.error('Error creating order item:', error);
    }
  };

  const handleUpdateOrderItem = async () => {
    try {
      await updateOrderItemAPI(modalData.id, modalData);
      dispatch(updateOrderItem({ id: modalData.id, updatedOrderItemData: modalData }));
      handleCloseModal();
    } catch (error) {
      console.error('Error updating order item:', error);
    }
  };

  const handleDeleteOrderItem = async (orderItemId) => {
    try {
      await deleteOrderItemAPI(orderItemId);
      dispatch(deleteOrderItem(orderItemId));
      handleCloseModal();
    } catch (error) {
      console.error('Error deleting order item:', error);
    }
  };

  const handleOpenModal = (orderItemId) => {
    const orderItemToUpdate = orderItems.find(item => item.id === orderItemId);
    setModalData({ ...orderItemToUpdate });
    setOpenModal(true);
  };

  const handleCloseModal = () => {
    setModalData({
      id: null,
      orderId: '',
      productId: '',
      quantity: '',
      unitPrice: '',
    });
    setOpenModal(false);
  };

  return (
    <div className="order-item-list-container">
      <TableContainer component={Paper}>
        <Table>
          <TableHead>
            <TableRow>
              <TableCell>ID</TableCell>
              <TableCell>Order ID</TableCell>
              <TableCell>Order Date</TableCell>
              <TableCell>Total Amount</TableCell>
              <TableCell>Product ID</TableCell>
              <TableCell>Product Name</TableCell>
              <TableCell>Quantity</TableCell>
              <TableCell>Unit Price</TableCell>
              <TableCell>Actions</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {orderItems.map(orderItem => (
              <TableRow key={orderItem.id}>
                <TableCell>{orderItem.id}</TableCell>
                <TableCell>{orderItem.orderId}</TableCell>
                <TableCell>{getOrderDate(orderItem.orderId)}</TableCell>
                <TableCell>{getTotalAmount(orderItem.orderId)}</TableCell>
                <TableCell>{orderItem.productId}</TableCell>
                <TableCell>{getProductName(orderItem.productId)}</TableCell>
                <TableCell>{orderItem.quantity}</TableCell>
                <TableCell>{orderItem.unitPrice}</TableCell>
                <TableCell>
                  <Button variant="contained" onClick={() => handleOpenModal(orderItem.id)}>Update</Button>
                  <Button variant="contained" onClick={() => handleDeleteOrderItem(orderItem.id)}>Delete</Button>
                </TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>

     
      <Button variant="contained" onClick={() => handleOpenModal(null)}>Create Order Item</Button>

      
      <Modal open={openModal} onClose={handleCloseModal}>
        <div className="modal-content">
          <h2>{modalData.id ? 'Update Order Item' : 'Create Order Item'}</h2>
          <TextField
            label="Order ID"
            value={modalData.orderId}
            onChange={(e) => setModalData({ ...modalData, orderId: e.target.value })}
          />
          <TextField
            label="Product ID"
            value={modalData.productId}
            onChange={(e) => setModalData({ ...modalData, productId: e.target.value })}
          />
          <TextField
            label="Quantity"
            value={modalData.quantity}
            onChange={(e) => setModalData({ ...modalData, quantity: e.target.value })}
          />
          <TextField
            label="Unit Price"
            value={modalData.unitPrice}
            onChange={(e) => setModalData({ ...modalData, unitPrice: e.target.value })}
          />
          <Button variant="contained" onClick={modalData.id ? handleUpdateOrderItem : handleCreateOrderItem}>
            {modalData.id ? 'Update Order Item' : 'Create Order Item'}
          </Button>
          <Button variant="contained" onClick={handleCloseModal}>Cancel</Button>
        </div>
      </Modal>
    </div>
  );
};

export default OrderItemList;
