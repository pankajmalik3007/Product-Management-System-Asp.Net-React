
import React, { useEffect, useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { Modal, Button, TextField } from '@mui/material';
import {
  getAllOrders,
  createOrder as createOrderAPI,
  updateOrder as updateOrderAPI,
  deleteOrder as deleteOrderAPI,
} from './orderApi';
import {
  selectOrders,
  setOrders,
  addOrder,
  updateOrder,
  deleteOrder,
} from './orderSlice';
import './OrderList.css';

const OrderList = () => {
  const dispatch = useDispatch();
  const orders = useSelector(selectOrders);
  const [openModal, setOpenModal] = useState(false);
  const [modalData, setModalData] = useState({
    id: null,
    orderDate: '',
    totalAmount: '',
    orderItems: [], // Include orderItems in modalData
  });

  useEffect(() => {
    const fetchData = async () => {
      try {
        const data = await getAllOrders();
        dispatch(setOrders(data));
      } catch (error) {
        console.error('Error fetching orders:', error);
        // Handle error (you might want to dispatch an action to set an error state in Redux)
      }
    };

    fetchData();
  }, [dispatch]);

  const handleOpenModal = (order) => {
    // Ensure that orderItems is initialized as an array
    const initializedOrder = {
      ...order,
      orderItems: order.orderItems || [],
    };
  
    setModalData(initializedOrder);
    setOpenModal(true);
  };
  

  const handleCloseModal = () => {
    setModalData({
      id: null,
      orderDate: '',
      totalAmount: '',
      orderItems: [],
    });
    setOpenModal(false);
  };

  const handleFetchData = async () => {
    try {
      const data = await getAllOrders();
      dispatch(setOrders(data));
    } catch (error) {
      // Handle error
    }
  };

  const handleCreateOrder = async () => {
    try {
      const newOrder = await createOrderAPI(modalData);
      dispatch(addOrder(newOrder));
      handleCloseModal();
    } catch (error) {
      // Handle error
    }
  };

  const handleUpdateOrder = async () => {
    try {
      await updateOrderAPI(modalData.id, {
        orderDate: modalData.orderDate,
        totalAmount: modalData.totalAmount,
        orderItems: modalData.orderItems,
      });
      dispatch(updateOrder({ id: modalData.id, updatedOrderData: modalData }));
      handleCloseModal();
    } catch (error) {
      // Handle error
    }
  };

  const handleDeleteOrder = async () => {
    try {
      await deleteOrderAPI(modalData.id);
      dispatch(deleteOrder(modalData.id));
      handleCloseModal();
    } catch (error) {
      // Handle error
    }
  };

  return (
    <div className="order-list-container">
      <Button variant="contained" onClick={() => handleOpenModal({})}>
        Add Order
      </Button>
      <Button variant="contained" onClick={handleFetchData}>
        Fetch Data
      </Button>

      {/* Order Table */}
      <table>
        <thead>
          <tr>
            <th>ID</th>
            <th>Order Date</th>
            <th>Total Amount</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {orders.map((order) => (
            <tr key={order.id}>
              <td>{order.id}</td>
              <td>{order.orderDate}</td>
              <td>{order.totalAmount}</td>
              <td>
                <Button
                  variant="contained"
                  onClick={() => handleOpenModal(order)}
                >
                  View Details
                </Button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>

      {/* Modal for Adding/Updating Orders */}
      <Modal open={openModal} onClose={handleCloseModal}>
        <div className="modal-content">
          <h2>{modalData.id ? 'Update Order' : 'Add New Order'}</h2>
          <TextField
            label="Order Date"
            type="date"
            value={modalData.orderDate}
            onChange={(e) =>
              setModalData({ ...modalData, orderDate: e.target.value })
            }
          />
          <TextField
            label="Total Amount"
            type="number"
            value={modalData.totalAmount}
            onChange={(e) =>
              setModalData({ ...modalData, totalAmount: e.target.value })
            }
          />

          {/* Display orderItems in the modal */}
          <h3>Order Items</h3>
          <ul>
            {modalData.orderItems.map((item) => (
              <li key={item.id}>
                {item.productName} - Quantity: {item.quantity}
              </li>
            ))}
          </ul>

          {modalData.id ? (
            <Button variant="contained" onClick={handleUpdateOrder}>
              Update Order
            </Button>
          ) : (
            <Button variant="contained" onClick={handleCreateOrder}>
              Add Order
            </Button>
          )}
          <Button variant="contained" onClick={handleCloseModal}>
            Cancel
          </Button>
          <Button variant="contained" onClick={handleDeleteOrder}>
            Delete Order
          </Button>
        </div>
      </Modal>
    </div>
  );
};

export default OrderList;
