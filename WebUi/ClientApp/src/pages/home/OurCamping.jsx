import React from 'react';
import { AiOutlineArrowRight, AiFillCalendar } from "react-icons/ai";
import { BsMapFill } from "react-icons/bs";
import Carousel from 'react-multi-carousel';
import 'react-multi-carousel/lib/styles.css';
const responsive = {
    superLargeDesktop: {
        // the naming can be any, depends on you.
        breakpoint: { max: 4000, min: 3000 },
        items: 5
    },
    desktop: {
        breakpoint: { max: 3000, min: 1024 },
        items: 3
    },
    tablet: {
        breakpoint: { max: 1024, min: 464 },
        items: 2
    },
    mobile: {
        breakpoint: { max: 464, min: 0 },
        items: 1
    }
};
export const OurCamping = () => {
    return (
        <div id='our-camping'>
            <div className="container ">
                <div className="camping-header flex justify-between items-center">
                    <h3 className='text-4xl '> Our campaings</h3>
                    <div className="see-all">
                        <p className="text-xl flex items-center hover:text-green-500">See all <AiOutlineArrowRight className='ml-2' /></p>
                    </div>
                </div>
                <div className="camping-description w-full sm:w-1/2 mt-4">
                    <p className='text-gray-600 text-md'>Encourage new donors toblood. We have total donor centers and visit
                        thousands of other venues on various occasions.</p>
                </div>
                <div className="camping-caroul">
                    <Carousel  infinite responsive={responsive} className=''>
                        {
                            (new Array(10).fill().map(e => (<div class="max-w-md mx-auto bg-white rounded-xl shadow-md overflow-hidden m-8">
                                <div class="md:flex flex-col">
                                    <div class="md:flex-shrink-0">
                                        <img class="h-56 w-full object-cover card-image" src="https://picsum.photos/200/300" alt="Card image" />
                                    </div>
                                    <div class="p-4">
                                        <div className="date flex items-center mb-3">
                                            <AiFillCalendar color='#2db853' />
                                            <p className='text-gray-500 ml-2 text-sm timer'>April 4, 2020</p>
                                        </div>
                                        <div class="uppercase tracking-wide text-xl text-black font-semibold">World blood donors day</div>
                                        <p class="mt-2 text-gray-500">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque sed ex et mi sagittis posuere.</p>
                                        <div className="location flex items-center mt-2">
                                            <BsMapFill className='mr-2 text-[#ffb408]' /> <p>Hue</p>
                                        </div>
                                    </div>
                                </div>
                            </div>)))
                        }



                    </Carousel>

                </div>
            </div>
        </div>
    )
}
