import React from 'react'
import CartDashboard from '../../components/cart/CartDashboard'

export default function Dashboard() {
  return (
      <div className="w-full grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-4">
            
           
            <CartDashboard type={'Today user'} value={'5'} description={'Number of user today'} />
            <CartDashboard type={'Today register'} value={'100'} description={'Number of register today'} />
            <CartDashboard type={'Today access to site'} value={'52'} description={'Number of access today'} />
            <CartDashboard type={'Today blogs'} value={'5'} description={'Number of write blogs today'} />
            

      </div>
  )
}
