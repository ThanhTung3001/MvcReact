import React from 'react';
import CustomButton from '../../components/button/CustomButton';

export const Slogan = () => {
  return (
    <div id="hepping-history">
    <div className="container h-full flex">
         <div className="w-9/12 h-full flex justify-center flex-col">
              <h3 className='text-white text-4xl font-bold'>We are helping people from 10 years</h3>
                <p className="text-sm text-white mt-4">Lorem ipsum, dolor sit amet consectetur adipisicing elit. Fugiat aspernatur modi quisquam exercitationem aut, vel minima iusto repudiandae! Distinctio facere iure consequatur, labore ex beatae. Repellat culpa minus laborum exercitationem!</p>
         </div>
         <div className="w-3/12 flex flex-col justify-center items-end">
              <CustomButton onClick={()=>{}} content={'Donate Now'}/>
              {/* <CustomButton/> */}
         </div>
    </div>
</div>
  )
}
