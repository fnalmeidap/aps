import React, { Component } from 'react';
import { Collapse, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link, useLocation } from 'react-router-dom';
import './NavMenu.css';
import { useLogin } from '../hooks/Login';

export function NavMenu()  {
  const { user } = useLogin()
  const location = useLocation();

  // console.log("Localização atual:", location);

    return (
      <header>
        <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3" container light>
          <NavbarBrand tag={Link} to={!user ? "/" : '/tela-evento'}>SistemaOlimpo</NavbarBrand>
          <div>
            <ul className="navbar-nav flex-grow gap-2">
              <Collapse isOpen={['/'].includes(location.pathname)} horizontal>
                <NavItem>
                  <NavLink tag={Link} className="text-dark" to="/login">Login</NavLink>
                </NavItem>
              </Collapse>
              <Collapse isOpen={['/login'].includes(location.pathname)} horizontal>
                <NavItem>
                  <NavLink tag={Link} className="text-dark" to="/">Cadastro</NavLink>
                </NavItem>
              </Collapse>
              <Collapse isOpen={user && ['/tela-equipes'].includes(location.pathname)} horizontal>
                <NavItem>
                  <NavLink tag={Link} className="text-dark" to="/tela-equipe">Cadastrar Equipe</NavLink>
                </NavItem>
              </Collapse>
              <Collapse isOpen={user && ['/tela-evento', '/tela-equipe'].includes(location.pathname)} horizontal>
                <NavItem>
                  <NavLink tag={Link} className="text-dark" to="/tela-equipes">Equipes</NavLink>
                </NavItem>
              </Collapse>
              <Collapse isOpen={user && ['/tela-equipes', '/tela-evento/:id'].includes(location.pathname)} horizontal>
                <NavItem>
                  <NavLink tag={Link} className="text-dark" to="/tela-evento">Eventos</NavLink>
                </NavItem>
              </Collapse>
              <Collapse isOpen={user && ['/tela-evento'].includes(location.pathname)} horizontal>
                <NavItem>
                  <NavLink tag={Link} className="text-dark" to="/tela-cadastro-evento">Cadastrar evento</NavLink>
                </NavItem>
              </Collapse>
            </ul>
          </div>
        </Navbar>
      </header>
    );

}
