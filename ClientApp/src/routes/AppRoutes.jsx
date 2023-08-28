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
import { TelaCadastrarEvento } from '../pages/TelaCadastroEvento';
import { TelaTDP } from '../pages/TelaTDP';
import { TelaInscricaoEvento } from '../pages/TelaInscricaoEvento';

const routes = [
  {
    index: true,
    element: <TelaCadastro />
  },
  {
    path: '/login',
    element: <Login />
  },
  // {
  //   path: '/home',
  //   element: <Home />
  // },
  // {
  //   path: '/counter',
  //   element: <Counter />
  // },
  // {
  //   path: '/fetch-data',
  //   element: <FetchData />
  // },
  {
    path: '/tela-equipe',
    element: <TelaEquipe />
  },
  {
    path: '/tela-evento',
    element: <TelaEvento />
  },
  {
    path: '/tela-evento/:id',
    element: <TelaInscricaoEvento />
  },
  // {
  //   path: '/tela-organizacao-evento',
  //   element: <TelaInscricaoEvento />
  // },
  {
    path: '/tela-equipes',
    element: <TelaEquipes />
  },
  {
    path: '/tela-cadastro-evento',
    element: <TelaCadastrarEvento />
  },
  {
    path: '/tela-TDP',
    element: <TelaTDP />
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

