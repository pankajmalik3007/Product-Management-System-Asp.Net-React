// Navigation.js
import React from 'react';
import { Link } from 'react-router-dom';
import { AppBar, Toolbar, Typography, Button } from '@mui/material';

const Navigation = () => {
  return (
    <AppBar position="sticky" sx={{ top: 0, zIndex: 1000 }}>
      <Toolbar>
        <Typography variant="h6" component="div" sx={{ flexGrow: 1 }}>
          Your App Name
        </Typography>
        <Button color="inherit" component={Link} to="/" sx={{ marginRight: 2 }}>
          Home
        </Button>
        <Button color="inherit" component={Link} to="/Product" sx={{ marginRight: 2 }}>
          Product
        </Button>
        <Button color="inherit" component={Link} to="/Category">
          Category
        </Button>
       
        <Button color="inherit" component={Link} to="/Order">
           Order
        </Button>

        <Button color="inherit" component={Link} to="/OrderItem">
         OrderItem
        </Button>
          <Button color="inherit" component={Link} to="/CartProduct">
          CartList
        </Button>
        <Button color="inherit" component={Link} to="/SearchCategory">
          categorySearch
        </Button>
        <Button color="inherit" component={Link} to="/SearchOrder">
          OrderSearch
        </Button>
      </Toolbar>
    </AppBar>
  );
};

export default Navigation;
