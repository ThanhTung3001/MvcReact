import React, { Component, useState } from 'react';
import { Route, Routes,useRoutes } from 'react-router-dom';
import AppRoutes from './AppRoutes';
import './custom.css';
import { Header } from './components/layout/header';
import { motion, useScroll } from "framer-motion"
import { Footter } from './components/layout/footer';
import { IoIosArrowUp } from 'react-icons/io'
import { Layout } from './components/layout';
import { Home } from './pages/home';
import { Campaing } from './pages/campaings';
import { Blogs } from './pages/blogs';
import { Contact } from './pages/home/Contact';
import { About } from './pages/about';
import AdminLayout from './components/layout/dashboard';
import Dashboard from './pages/dashboard';



const App = () => {
  const { scrollYProgress } = useScroll();
  const [visible, setVisible] = useState(false);
  const scrollToTop = () => {
    window.scrollTo({
      top: 0,
      behavior: 'smooth'
    });
  };


  const handleScroll = () => {
    const scrollTop = window.pageYOffset || document.documentElement.scrollTop;
    setVisible(scrollTop > 0);
  };
  window.addEventListener('scroll', handleScroll);
  return (
    <>
      <motion.div
        className="progress-bar"
        style={{ scaleX: scrollYProgress }}
      />
  
     
      <Routes>
      <Route path="/" element={<Layout />}>
        <Route index element={<Home />} />
        <Route path="/campaing" element={<Campaing />} />
        <Route path="/blogs" element={<Blogs />} />
        <Route path="/contact" element={<Contact />} />
        <Route path="/about" element={<About />} />
      </Route>
      <Route path='/admin' element={<AdminLayout/>}>
          <Route index element={<About />} />
          <Route path='dashboard' element={<Dashboard />} />
      </Route>
    </Routes>

      <button
        className={`scroll-to-top ${visible ? 'visible' : ''}`}
        onClick={scrollToTop}
      >
        <IoIosArrowUp size={32} />
      </button>
     

    </>

  );

}

export default App;