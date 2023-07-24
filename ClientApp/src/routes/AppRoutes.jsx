import React from 'react';
import { Route, Routes } from 'react-router-dom';

//routes
import { Counter } from "../pages/Counter";
import { FetchData } from "../pages/FetchData";
import { Home } from "../pages/Home";
import { Login } from '../pages/Login';
import { TelaCadastro } from '../pages/TelaCadastro';
import { TelaEquipe } from '../pages/TelaEquipe';
import { TelaEvento } from '../pages/TelaEvento';
import TelaEquipes from '../pages/TelaEquipes';

const routes = [
  {
    index: true,
    element: <Login />
  },
  {
    path: '/home',
    element: <Home />
  },
  {
    path: '/cadastro',
    element: <TelaCadastro />
  },
  {
    path: '/counter',
    element: <Counter />
  },
  {
    path: '/fetch-data',
    element: <FetchData />
  },
  {
    path: '/tela-equipe',
    element: <TelaEquipe />
  },
  {
    path: '/tela-evento',
    element: <TelaEvento />
  },
  {
    path: '/tela-equipes',
    element: <TelaEquipes />
  }
];


export default function AppRoutes() {
  return (
    <Routes>
      {routes.map((route, index) => {
        const { element, ...rest } = route;
        return <Route key={index} {...rest} element={element} />;
      })}
    </Routes>
  )
}

