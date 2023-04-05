import React from 'react'
import { AiOutlineArrowRight } from 'react-icons/ai';
export const Contact = () => {
    return (
        <div id="contact">
            <div className="container h-full flex flex-col justify-center">
                <p className="appointment text-md text-gray-600">Appointment</p>
                <h3 className="text-4xl">Good to know
                    helpful information</h3>
                    <div className="appointment-commmit mt-4">
                        <div className="appointment-item flex items-center mt-3">
                            <div className="arrow-icon h-6 w-8 bg-green-600 flex items-center">
                                    <AiOutlineArrowRight color='white'/>
                            </div>
                            <p className='ml-2 text-gray-600'>Maintain a healthy iron level by eating iron rich foods.</p>
                        </div>
                        <div className="appointment-item flex items-center mt-3">
                            <div className="arrow-icon h-6 w-8 bg-green-600 flex items-center">
                                    <AiOutlineArrowRight color='white'/>
                            </div>
                            <p className='ml-2 text-gray-600'>Drink an extra 16 oz. of water prior to your donation.</p>
                        </div>
                        <div className="appointment-item flex items-center mt-3">
                            <div className="arrow-icon h-6 w-8 bg-green-600 flex items-center">
                                    <AiOutlineArrowRight color='white'/>
                            </div>
                            <p className='ml-2 text-gray-600'>Avoid alcohol consumption before your blood donation.</p>
                        </div>
                        <div className="appointment-item flex items-center mt-3">
                            <div className="arrow-icon h-6 w-8 bg-green-600 flex items-center">
                                    <AiOutlineArrowRight color='white'/>
                            </div>
                            <p className='ml-2 text-gray-600'>Finally, Try to get a good night sound sleep after donation</p>
                        </div>
                        <div className="appointment-item flex items-center mt-3">
                            <div className="arrow-icon h-6 w-8 bg-green-600 flex items-center">
                                    <AiOutlineArrowRight color='white'/>
                            </div>
                            <p className='ml-2 text-gray-600'>Remember to bring the donor card or national ID/Passport.</p>
                        </div>
                    </div>
            </div>
        </div>
    )
}
