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
<<<<<<< HEAD
  const [errorMessage, setErrorMessage] = useState('')
=======
>>>>>>> 361510a1352e924016f9b4efe1c28c6ee59d6159

  const handleLoginSubmit = e => {
    e.preventDefault()
    dispatch(loginUser(employeeID, password, navigate))
<<<<<<< HEAD
      .then(responseData => {
        if (responseData.token) {
          toast.success('Login Successful')
        }
      })
      .catch(error => {
        setErrorMessage('Invalid username or password.')
        toast.error('Login Failed')
=======
      .then(token => {
        toast.success('Login Successful')
      })
      .catch(err => {
        toast.error('Unable to Login')
>>>>>>> 361510a1352e924016f9b4efe1c28c6ee59d6159
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
<<<<<<< HEAD
            {errorMessage && <p>{errorMessage}</p>}
=======
>>>>>>> 361510a1352e924016f9b4efe1c28c6ee59d6159
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
