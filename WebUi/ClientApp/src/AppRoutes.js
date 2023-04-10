import React from 'react'
import { Home } from './pages/home';
import { Campaing } from './pages/campaings';
import { Blogs } from './pages/blogs';
import { Contact } from './pages/home/Contact';
import { About } from './pages/about';

const AppRoutes = [
  {
    privateRoute:false,
    index: true,
    element: <Home />
  },
  {
    privateRoute:false,
    index: false,
    path:'/campaing',
    element: <Campaing />
  },
  {
    privateRoute:false,
    index: false,
    path:'/blogs',
    element: <Blogs />
  },
  {
    privateRoute:false,
    index: false,
    path:'/contact',
    element: <Contact />
  },
  {
    privateRoute:false,
    index: false,
    path:'/about',
    element: <About />
  }, {
    privateRoute:true,
    index: false,
    path:'/admin',
    element: <About />
  }
];

export default AppRoutes;
