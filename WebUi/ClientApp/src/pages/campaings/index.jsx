import React,{useState} from 'react';
import ReactPaginate from 'react-paginate';
import { AiOutlineArrowRight, AiFillCalendar } from "react-icons/ai";
import { BsMapFill } from "react-icons/bs";
import './campaing.scss';
import Pagination from '../../components/pagination';

export const Campaing = () => {
  const [currentPage, setCurrentPage] = useState(1);
  const totalPages = 20;

  const handlePageChange = (page) => {
    setCurrentPage(page);
  };
 return  <div id='camping' >
    <div className="container content mt-32 grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-4">
    {
         (
            (new Array(12).fill().map((e,index) => (
            <div class="bg-white rounded-xl shadow-md overflow-hidden item-blog" key={index}>
            <div class="md:flex flex-col">
                <div class="md:flex-shrink-0">
                    <img class="h-40 w-full object-cover" src={`https://picsum.photos/200/${Math.floor(Math.random() * 10 + 1) * 100}`} alt="Card image" />
                </div>
                <div class="p-4">
                    <div className="date flex items-center mb-3">
                        <AiFillCalendar color='#2db853' />
                        <p className='text-gray-500 ml-2 text-sm timer'>April 4, 2020</p>
                    </div>
                    <div class="uppercase tracking-wide text-sm text-black font-semibold">World blood donors day</div>
                    <p class="mt-2 text-gray-500 description truncate overflow-y-clip line-clamp-3">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque sed ex et mi sagittis posuere.</p>
                    <div className="location flex items-center mt-2">
                        <BsMapFill className='mr-2 text-[#ffb408]' /> <p>Hue</p>
                    </div>
                </div>
            </div>
        </div>
        ))))
    }
    </div>
    {/* <div className="flex justify-center">
      <Pagination currentPage={currentPage} onPageChange={handlePageChange} totalPages={totalPages} />
      </div> */}
   </div>
}
