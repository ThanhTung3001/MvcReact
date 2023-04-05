import React, { useEffect, useState } from 'react'
import './header.scss';
import { Link } from 'react-router-dom';


const arrayMenu = [
    {
        name:'Home',
        path:'/'
    },
    {
        name:'About',
        path:'/about'
    }, {
        name:'Campaing',
        path:'/campaing'
    },  {
        name:'Blog',
        path:'/blogs'
    },  {
        name:'Contact',
        path:'/contact'
    },
    
];



export const Header = () => {

    const [select,setSelected] = useState(0);
    const [headerScroll,setHeaderScroll] = useState(false);
    useEffect(()=>{
        window.addEventListener('scroll', handleScroll);
        return () => {
          window.removeEventListener('scroll', handleScroll);
        };
    },[]);
    const handleScroll = () => {
        if (window.scrollY >30) {
            setHeaderScroll(true);
        }else{
            setHeaderScroll(false);
        }
      };
  return (
        <header className={`flex justify-center fixed top-8 w-full h-[60px] z-50`}>
            <div className={`container top-header flex rounded-md w-full z-1 items-center ${headerScroll===true?"scroll-header":""}`}>
                    <div className="logo font-bold text-xl pl-4 cursor-pointer w-1/3">
                        BloodDeft
                    </div>
                    <div className="menu w-2/3">
                            <ul className="flex justify-end">
                               
                                {
                                    (arrayMenu).map((e,index)=>{
                                      return  <li className={`item ${index===select?'item-active':''}`} onClick={()=>{
                                         setSelected(index);
                                      }}><Link to={e.path}>{e.name}</Link></li>
                                    })
                                }
                            </ul>
                    </div>

            </div>
        </header>
  )
}
