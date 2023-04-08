import React from 'react'
import { AiOutlineArrowRight } from 'react-icons/ai';
import { DatePicker } from 'antd';
import CustomButton from '../../components/button/CustomButton';
export const Contact = () => {
    return (
        <div id="contact">
            <div className="container h-full flex flex-col justify-center">
                <p className="appointment text-md text-gray-600">Appointment</p>
                <h3 className="text-4xl">Good to know
                    helpful information</h3>
                <div className="flex flex-wrap ">
                    <div className="appointment-commmit mt-4 w-full sm:w-1/2">
                        <div className="appointment-item flex items-center mt-3">
                            <div className="arrow-icon h-6 w-8 bg-green-600 flex items-center">
                                <AiOutlineArrowRight color='white' />
                            </div>
                            <p className='ml-2 text-gray-600 text-lg'>Maintain a healthy iron level by eating iron rich foods.</p>
                        </div>
                        <div className="appointment-item flex items-center mt-3">
                            <div className="arrow-icon h-6 w-8 bg-green-600 flex items-center">
                                <AiOutlineArrowRight color='white' />
                            </div>
                            <p className='ml-2 text-gray-600 text-lg'>Drink an extra 16 oz. of water prior to your donation.</p>
                        </div>
                        <div className="appointment-item flex items-center mt-3">
                            <div className="arrow-icon h-6 w-8 bg-green-600 flex items-center">
                                <AiOutlineArrowRight color='white' />
                            </div>
                            <p className='ml-2 text-gray-600 text-lg'>Avoid alcohol consumption before your blood donation.</p>
                        </div>
                        <div className="appointment-item flex items-center mt-3">
                            <div className="arrow-icon h-6 w-8 bg-green-600 flex items-center">
                                <AiOutlineArrowRight color='white' />
                            </div>
                            <p className='ml-2 text-gray-600 text-lg'>Finally, Try to get a good night sound sleep after donation</p>
                        </div>
                        <div className="appointment-item flex items-center mt-3">
                            <div className="arrow-icon h-6 w-8 bg-green-600 flex items-center">
                                <AiOutlineArrowRight color='white' />
                            </div>
                            <p className='ml-2 text-gray-600 text-lg'>Remember to bring the donor card or national ID/Passport.</p>
                        </div>
                    </div>
                     <div className="appointment-contact-form  w-full sm:w-1/2">
                            <div className="flex flex-col w-[80%]">
                                 <input type="text" placeholder='Name' className="rounded-2xl bg-white form-control p-3 active:border-gray-500 mb-3" />
                                 <input type="text" placeholder='Email' className="rounded-2xl bg-white form-control p-3 active:border-gray-500 mb-3" />
                                 <input type="text" placeholder='Phone' className="rounded-2xl bg-white form-control p-3 active:border-gray-500 mb-3" />
                              <div className="flex flex-row justify-center items-center">
                              <div className="w-1/2 mr-2">
                                       <DatePicker
                                       format={'HH:mm:ss'}
                                       picker='time'
                                       placeholder='Select time' className="rounded-2xl bg-white form-control p-3 active:border-gray-500 mb-3" />
                                </div>
                                <div className="w-1/2 ml-2">
                                      <DatePicker 
                                      placeholder='Select date'
                                      format={'DD/MM/YYYY'}
                                      className="rounded-2xl bg-white form-control p-3 active:border-gray-500 mb-3" />
                                </div>
                                
                              </div>
                             <div className="flex justify-center w-full">
                             <CustomButton content={'Appointment Submit'} classname='w-full' onClick={()=>{}} />
                             </div>
                            
                            </div>
                     </div>
                </div>
            </div>
        </div>
    )
}
