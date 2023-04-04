import React from 'react'
import './home.scss';
import { AiOutlineArrowRight } from 'react-icons/ai';
export const Home = () => {
  return (
    <>
    <div id="home">
        <div className="container h-[100%]">
           <div className="flex flex-wrap h-full">
                <div className="w-full  h-full flex flex-col justify-center items-center">
                        <h2 className='text-4xl sm:text-6xl font-bold text-gray-800 text-center md:text-left'>Donate blood, save life !</h2>
                        <p className="text-sm sm:text-md w-full sm:w-[80%] mt-4 text-gray-500 text-center md:text-left">
                            Lorem ipsum dolor sit amet consectetur adipisicing elit. Iure accusantium magni, laborum, ducimus, saepe officiis at odio possimus quibusdam deserunt perferendis molestiae id ab aliquam reprehenderit quas earum animi consectetur.
                        </p>
                        <button className='hover:bg-red-400 bg-white flex justify-center items-center btn btn-primary border-white text-black mt-6 '>Donate Now <div className="btn btn-primary ml-2 p-2 bg-green-500 border-green-500"><AiOutlineArrowRight/></div></button>
                </div>
               
           </div>
        </div>
    </div>
    <div id="hepping-history">
      
    </div>
    </>
  )
}
