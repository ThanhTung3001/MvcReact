import React from 'react'
import { Header } from './header';
import { Footter } from './footer';
import { Outlet } from 'react-router-dom';

export const Layout = ({ children })=> {
    return (
      <div>
        <Header />
        <Outlet/>
        <Footter />
      </div>
    );
  }
