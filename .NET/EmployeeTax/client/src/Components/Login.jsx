import React, { useState } from 'react'
import { useDispatch } from 'react-redux'
import { useNavigate } from 'react-router-dom'
import { loginUser } from '../Redux/Actions/UserAction'
import toast from 'react-hot-toast'

const Login = () => {
  const dispatch = useDispatch()
  const navigate = useNavigate()

  const [employeeID, setEmployeeID] = useState('')
  const [password, setPassword] = useState('')

  const handleLoginSubmit = e => {
    e.preventDefault()
    dispatch(loginUser(employeeID, password, navigate))
      .then(token => {
        toast.success('Login Successful')
      })
      .catch(err => {
        toast.error('Unable to Login')
      })
  }

  return (
    <section className='w-full h-full'>
      <div className='max-w-[1200px] mx-auto flex justify-center items-center my-24 '>
        <div className='w-[40%] px-8 py-8  rounded-md   bg-blue-100'>
          <form
            className='flex justify-center  flex-col w-full mt-10'
            onSubmit={handleLoginSubmit}
          >
            <div className='mb-3 mx-2'>
              <label htmlFor='name' className='leading-7 text-sm '>
                Employee ID
              </label>
              <input
                type='text'
                id='name'
                className='w-full h-[40px] text-[14px] bg-white outline-none py-1 px-3 mt-1 '
                value={employeeID}
                onChange={e => setEmployeeID(e.target.value)}
              />
            </div>
            <div className='mb-3 mx-2'>
              <label htmlFor='name' className='leading-7 text-sm '>
                Password
              </label>
              <input
                type='password'
                id='name'
                className='w-full h-[40px] text-[14px] bg-white outline-none py-1 px-3 mt-1 '
                value={password}
                onChange={e => setPassword(e.target.value)}
              />
            </div>
            <div className='m-2'>
              <button
                type='submit'
                className='w-[150px] h-[40px] text-[16px] font-medium  flex justify-center items-center  p-4  rounded bg-green-400 cursor-pointer'
              >
                Login
              </button>
            </div>
          </form>
        </div>
      </div>
    </section>
  )
}

export default Login
