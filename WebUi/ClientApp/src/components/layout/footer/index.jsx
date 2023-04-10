import React from 'react';
import './footer.scss';
import { Link } from 'react-router-dom';
import { AiOutlineArrowRight,AiOutlineTwitter,AiFillInstagram } from 'react-icons/ai';
import { SiZalo } from "react-icons/si";
//SiZalo
import {BsBrowserSafari} from 'react-icons/bs';
import { Logo } from '../../Logo';
export const Footter = () => (
    <div id="footer" >
        <div className="container flex justify-between">
            <div className="w-1/2 sm:w-1/4 p-2">
                <div className="flex flex-col">
                    <p className="title text-2xl font-bold text-white">
                        About Us
                    </p>
                    <p className="pt-2 text-gray-200">
                        An award winning agency based
                        in London. difference. An award
                        winning agency based in
                    </p>
                    <div className="flex flex-row mt-3">
                         <Link className='bg-[#2754fe] btn btn-primary btn-social mr-3'><BsBrowserSafari color='white' size={18}/></Link>
                         <Link className='bg-[#20a1f2] btn btn-primary btn-social mr-3'><AiOutlineTwitter color='white' size={18}/></Link>
                         <Link className=' btn btn-primary btn-social zalo mr-3'><AiFillInstagram color='white' size={18}/></Link>
                    </div>
                </div>
            </div>
            <div className="w-1/2 sm:w-1/5 p-2">
                <div className="flex flex-col">
                    <p className="title text-2xl font-bold text-white">
                        Links
                    </p>
                    <Link to={'/'}>
                        <p className="pt-2 text-gray-200 hover:text-red-400">
                            Home
                        </p>
                    </Link>
                    <Link to={'/'}>
                        <p className="pt-2 text-gray-200 hover:text-red-400">
                            About
                        </p>
                    </Link>
                    <Link to={'/'}>
                        <p className="pt-2 text-gray-200 hover:text-red-400">
                            Services
                        </p>
                    </Link>
                    <Link to={'/'}>
                        <p className="pt-2 text-gray-200 hover:text-red-400">
                            Blog
                        </p>
                    </Link>
                    <Link to={'/'}>
                        <p className="pt-2 text-gray-200 hover:text-red-400">
                            Contact
                        </p>
                    </Link>
                    <Link to={'/'}>
                        <p className="pt-2 text-gray-200 hover:text-red-400">
                            Event
                        </p>
                    </Link>
                    <Link to={'/'}>
                        <p className="pt-2 text-gray-200 hover:text-red-400">
                            Appointment
                        </p>
                    </Link>
                </div>
            </div>   <div className="w-1/2 sm:w-1/4 p-2">
                <div className="flex flex-col">
                    <p className="title text-2xl font-bold text-white">
                        Contact
                    </p>
                    <p className="pt-2 text-gray-200">
                        Contact@bloodbank.vn
                    </p>
                    <p className="pt-2 text-gray-200">
                        Info@bloodbank.vn
                    </p>
                    <p className="title text-2xl font-bold text-white mt-4">
                        Phone
                    </p>
                    <p className="pt-2 text-gray-200">
                        +84359254498
                    </p>
                </div>
            </div>   <div className="w-1/2 sm:w-2/5 p-2">
                <div className="flex flex-col">
                    <p className="title text-2xl font-bold text-white">
                        Subcribe Now
                    </p>
                    <p className="pt-2 text-gray-200">
                        An award winning agency based in London.
                        Wedesign beautiful products make a
                        difference.
                    </p>
                        <div className="mt-8 bg-white p-3 rounded-md">
                            <Logo />

                        </div>
                </div>
            </div>
        </div>
    </div>
)
