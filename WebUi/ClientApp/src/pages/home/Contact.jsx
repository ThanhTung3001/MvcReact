import React from 'react'
import { AiOutlineArrowRight } from 'react-icons/ai';
import { Button, DatePicker } from 'antd';
import CustomButton from '../../components/button/CustomButton';
export const Contact = () => {
    return (
        <div id="contact">
            <div className="container h-full flex flex-col justify-center">
                <p className="appointment text-md text-gray-600">Appointment</p>
                <h3 className="text-2xl sm:text-4xl text-center sm:text-left">Good to know
                    helpful information</h3>
                <div className="flex flex-col sm:flex-row p-4 pt-0 sm:p-0">
                    <div className="appointment-commmit mt-2 sm:mt-4 w-full">
                        <div className="appointment-item flex items-center mt-3">
                            <div className="arrow-icon h-6 w-8 bg-green-600 flex items-center">
                                <AiOutlineArrowRight color='white' />
                            </div>
                            <p className='ml-2 text-gray-600 text-sm sm:text-lg'>Maintain a healthy iron level by eating iron rich foods.</p>
                        </div>
                        <div className="appointment-item flex items-center mt-3">
                            <div className="arrow-icon h-6 w-8 bg-green-600 flex items-center">
                                <AiOutlineArrowRight color='white' />
                            </div>
                            <p className='ml-2 text-gray-600 text-sm sm:text-lg'>Drink an extra 16 oz. of water prior to your donation.</p>
                        </div>
                        <div className="appointment-item flex items-center mt-3">
                            <div className="arrow-icon h-6 w-8 bg-green-600 flex items-center">
                                <AiOutlineArrowRight color='white' />
                            </div>
                            <p className='ml-2 text-gray-600 text-sm sm:text-lg'>Avoid alcohol consumption before your blood donation.</p>
                        </div>
                        <div className="appointment-item flex items-center mt-3">
                            <div className="arrow-icon h-6 w-8 bg-green-600 flex items-center">
                                <AiOutlineArrowRight color='white' />
                            </div>
                            <p className='ml-2 text-gray-600 text-sm sm:text-lg'>Finally, Try to get a good night sound sleep after donation</p>
                        </div>
                        <div className="appointment-item flex items-center mt-3">
                            <div className="arrow-icon h-6 w-8 bg-green-600 flex items-center">
                                <AiOutlineArrowRight color='white' />
                            </div>
                            <p className='ml-2 text-gray-600 text-sm sm:text-lg'>Remember to bring the donor card or national ID/Passport.</p>
                        </div>
                    </div>
                     <div className="appointment-contact-form w-full mt-4 sm:mt-2 ">
                            <div className="flex flex-col w-full sm:w-4/5">
                                 <input type="text" placeholder='Name' className="rounded-2xl bg-white form-control p-3 active:border-gray-500 mb-4" />
                                 <input type="text" placeholder='Email' className="rounded-2xl bg-white form-control p-3 active:border-gray-500 mb-4" />
                                 <input type="text" placeholder='Phone' className="rounded-2xl bg-white form-control p-3 active:border-gray-500 mb-4" />
                              <div className="flex flex-row justify-center items-center">
                              <div className="w-1/2 mr-2">
                                       <DatePicker
                                       format={'HH:mm:ss'}
                                       picker='time'
                                       placeholder='Select time' className="rounded-2xl bg-white form-control p-3 active:border-gray-500 mb-3 w-full" />
                                </div>
                                <div className="w-1/2 ml-2">
                                      <DatePicker 
                                      placeholder='Select date'
                                      format={'DD/MM/YYYY'}
                                      className="rounded-2xl bg-white form-control p-3 active:border-gray-500 mb-3 w-full" />
                                </div>
                                
                              </div>
                             <div className="w-full flex justify-center sm:justify-start">
                           
                              {/* <Button size='large' type="primary" className='button-primary mt-2'>Appointment Submit</Button> */}
                              <button class="button-36 mt-2" role="button">Appointment Submit</button>
                             </div>
                            
                            </div>
                     </div>
                </div>
            </div>
        </div>
    )
}
