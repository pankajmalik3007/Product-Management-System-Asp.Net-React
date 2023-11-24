
// import './App.css';
// // import ProductList from './Features/Product/ProductList';
// // import CategoryList from './Features/Category/CategoryList';
// import {BrowserRouter as Router, Routes, Route} from 'react-router-dom';


// import { lazy , Suspense } from 'react';

// const Home = lazy(()=> import('./Component/Home'))
// const ProductList = lazy(()=> import('./Features/Product/ProductList'))
// const CategoryList = lazy(()=> import('./Features/Category/CategoryList'))

// function App() {
//   return (
//     <div className="App">
//       <Router>
//       <Suspense fallback = {<div>Loading....</div>}>
//       <Routes>
//       <Route path= "/" element = {<Home/>}/>
//       <Route path= "/Product" element = {<ProductList/>}/>
//       <Route path= "/Category" element = {<CategoryList/>}/>
//       </Routes>
//        </Suspense>
//       </Router>
//     </div>
//   );
// }

// export default App;
// App.js
import './App.css';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import { lazy, Suspense } from 'react';
import Navigation from './Component/Navigation';








const Home = lazy(() => import('./Component/Home'));
const ProductList = lazy(() => import('./Features/Product/ProductList'));
const CategoryList = lazy(() => import('./Features/Category/CategoryList'));

const OrderList = lazy(() => import('./Features/Order/OrderList'));
const OrderItemList = lazy(() => import ('./Features/OrderItem/orderItemList'))
const CartProduct = lazy(() => import('./Features/Product/CartProduct'));
const SearchCategory = lazy(() => import('./Component/SearchCategory'));
const OrderSearch = lazy(() => import('./Component/OrderSearch'));



function App() {
  return (
    <div className="App">
      <Router>
        <Navigation />
        <Suspense fallback={<div>Loading....</div>}>
          <Routes>
            <Route path="/" element={<Home />} />
            <Route path="/Product" element={<ProductList />} />
            <Route path="/Category" element={<CategoryList />} />
           
            <Route path="/Order" element={<OrderList/>} />
            <Route path="/OrderItem" element={<OrderItemList/>} />
            <Route path="/CartProduct" element={<CartProduct/>} />
            <Route path="/SearchCategory" element={<SearchCategory/>} />
            <Route path="/SearchOrder" element={<OrderSearch/>} />

          </Routes>
        </Suspense>
      </Router>
    </div>
  );
}

export default App;
