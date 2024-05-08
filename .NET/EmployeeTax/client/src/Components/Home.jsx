import React from 'react'
import { useSelector } from 'react-redux'
import Loader from './Loader'

const Home = () => {
  const { loading, user } = useSelector(state => state.auth)

  return (
    <>
      {loading === false ? (
        <section id='Profile' className='w-full h-full  mt-20'>
          <div className='max-w-[1200px] w-[100%] mx-auto my-10'>
            <div className='w-[70%] mx-auto bg-blue-200 border-2 border-solid rounded-[10px] my-4'>
              <div className='p-4'>
                <h4 className='text-[1.4rem] font-bold text-center capitalize px-20'>
                  Personal Details
                </h4>
              </div>
              <hr className='w-[80%] mx-auto border-solid border-2 border-black' />
              <div className='grid grid-cols-2 md:grid-cols-4 w-[80%] mx-auto my-2'>
                <div className='col-span-1 md:col-span-2 '>
                  <ul className='flex flex-col justify-center items-start p-4'>
                    <li className='text-[14px] md:text-[1rem] font-semibold capitalize p-1 md:p-2'>
                      {' '}
                      Employee ID :
                      <span className='text-[14px] md:text-[0.9rem] font-normal '>
                        {user.empId}
                      </span>
                    </li>
                    <li className='text-[14px] md:text-[1rem] font-semibold capitalize p-1 md:p-2'>
                      {' '}
                      Employee Name :
                      <span className='text-[14px] md:text-[0.9rem] font-normal '>
                        {user.name}
                      </span>
                    </li>
                    <li className='text-[14px] md:text-[1rem] font-semibold capitalize p-1 md:p-2'>
                      {' '}
                      Age :
                      <span className='text-[14px] md:text-[0.9rem] font-normal '>
                        {user.age}
                      </span>
                    </li>
                    <li className='text-[14px] md:text-[1rem] font-semibold capitalize p-1 md:p-2'>
                      {' '}
                      Gender :
                      <span className='text-[14px] md:text-[0.9rem] font-normal '>
                        {user.gender}
                      </span>
                    </li>
                    <li className='text-[14px] md:text-[1rem] font-semibold capitalize p-1 md:p-2'>
                      {' '}
                      PhoneNumber:
                      <span className='text-[14px] md:text-[0.9rem] font-normal '>
                        {user.phoneNumber}
                      </span>
                    </li>
                    <li className='text-[14px] md:text-[1rem] font-semibold capitalize p-1 md:p-2'>
                      {' '}
                      Pan Card Number :
                      <span className='text-[14px] md:text-[0.9rem] font-normal '>
                        {user.panNo}
                      </span>
                    </li>
                    <li className='text-[14px] md:text-[1rem] font-semibold capitalize p-1 md:p-2'>
                      {' '}
                      Address :
                      <span className='text-[14px] md:text-[0.9rem] font-normal '>
                        {user.address}
                      </span>
                    </li>
                  </ul>
                </div>
              </div>
            </div>
          </div>
        </section>
      ) : (
        <Loader />
      )}
    </>
  )
}

export default Home
