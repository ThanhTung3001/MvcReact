import React, { Component } from 'react';
import { Route, Routes } from 'react-router-dom';
import AppRoutes from './AppRoutes';
import './custom.css';
import { Header } from './components/layout/header';
import { motion, useScroll } from "framer-motion"


const App = ()=> {
  const { scrollYProgress } = useScroll();
    return (
      <>
         <motion.div
        className="progress-bar"
        style={{ scaleX: scrollYProgress }}
      />
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