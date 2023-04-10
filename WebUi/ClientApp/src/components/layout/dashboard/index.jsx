import React from 'react';
import Sidebar from './sidebar';
import { Outlet } from 'react-router-dom';

function AdminLayout() {
  return (
    <div className="flex h-screen">
      <Sidebar children={ <Outlet/>} />
     
    </div>
  );
}

export default AdminLayout;
