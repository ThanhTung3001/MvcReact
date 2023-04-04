import React, { Component } from 'react';
import { Route, Routes } from 'react-router-dom';
import AppRoutes from './AppRoutes';
import './custom.css';
import { Header } from './components/layout/header';

const App = ()=> {

    return (
      <>
      <Header/>
       <Routes>
      {AppRoutes.map((route, index) => {
        const { element, ...rest } = route;
        return <Route key={index} {...rest} element={element} />;
      })}
     </Routes>
      </>
     
    );
  
}

export default App;