import React from 'react';
import { Counter } from "../pages/Counter";
import { FetchData } from "../pages/FetchData";
import { Home } from "../pages/Home";
import Login from '../pages/Login';

const AppRoutes = [
  {
    index: true,
    element: <Login />
  },
  {
    path: '/home',
    element: <Home />
  },
  {
    path: '/counter',
    element: <Counter />
  },
  {
    path: '/fetch-data',
    element: <FetchData />
  }
];

export default AppRoutes;
