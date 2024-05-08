import React from 'react'
import { useDispatch } from 'react-redux'
<<<<<<< HEAD
import { Link, NavLink, useNavigate } from 'react-router-dom'
import { logout } from '../Redux/Actions/UserAction'
import toast from 'react-hot-toast'

const Navbar = ({ role, isAuthenticated = false }) => {
  const dispatch = useDispatch()
  const navigate = useNavigate()

  const logoutButtonHandler = () => {
    dispatch(logout())
    /*  .then(() => {
        toast.sucess('Successfully Logged out')
        localStorage.removeItem('token')
        navigate('/')
      })
      .catch(err => {
        toast.error('Failed to Logged out')
      }) */
=======
import { Link, NavLink } from 'react-router-dom'
import { logout } from '../Redux/Actions/UserAction'

const Navbar = ({ role, isAuthenticated = false }) => {
  const dispatch = useDispatch()

  const logoutButtonHandler = () => {
    dispatch(logout())
    localStorage.removeItem('token')
>>>>>>> 361510a1352e924016f9b4efe1c28c6ee59d6159
  }

  return (
    <>
      <section
        id='Navbar'
        className='w-full h-full bg-blue-200 border-2 border-solid border-blue-100'
      >
        <div className=' max-w-[1200px]  flex justify-between items-center mx-auto my-2'>
          <div className='flex justify-evenly items-center'>
            <span>
              <h1 className='font-bold text-[24px] p-2 uppercase'>Contata</h1>
            </span>
          </div>

          {/* NAV-ITEMS FOR ADMIN DASHBOARD */}
          {role && role === 'admin' && (
            <div className=''>
              <ul className='flex justify-evenly items-center'>
                <li className='text-[1rem] font-medium  capitalize flex justify-center items-center p-2 m-2 hover:cursor-pointer'>
                  <NavLink to={'/admin/home'}>Home</NavLink>
                </li>
                <li className='text-[1rem] font-medium  capitalize flex justify-center items-center p-2 m-2 hover:cursor-pointer'>
                  <NavLink to={'/admin/employees'}> Employees</NavLink>
                </li>
                <li className='text-[1rem] font-medium  capitalize flex justify-center items-center p-2 m-2 hover:cursor-pointer'>
                  <NavLink to={'/admin/taxes'}> Tax Declaration</NavLink>
                </li>
                <li className='text-[1rem] font-medium  capitalize flex justify-center items-center p-2 m-2 hover:cursor-pointer'>
                  <NavLink to={'/admin/submissions'}>Submission</NavLink>
                </li>
              </ul>
            </div>
          )}

          {/* NAV-ITEMS FOR EMPLOYEE DASHBOARD */}
          {role && role === 'employee' && (
            <div className=''>
              <ul className='flex justify-evenly items-center'>
                <li className='text-[1rem] font-medium  capitalize flex justify-center items-center p-2 m-2 hover:cursor-pointer'>
                  <NavLink to={'/home'}>Home</NavLink>
                </li>
                <li className='text-[1rem] font-medium  capitalize flex justify-center items-center p-2 m-2 hover:cursor-pointer'>
                  <NavLink to={'/taxform'}> Tax Form</NavLink>
                </li>
                <li className='text-[1rem] font-medium  capitalize flex justify-center items-center p-2 m-2 hover:cursor-pointer'>
                  <NavLink to={'/submissions'}>Previous Submissions</NavLink>
                </li>
              </ul>
            </div>
          )}

          <div className=''>
            {isAuthenticated ? (
              <Link
                to='/logout'
                className='flex items-center'
                onClick={logoutButtonHandler}
              >
                <div className='w-[100px] h-[45px] text-[16px] font-medium  flex justify-center items-center  p-4  rounded bg-green-400 cursor-pointer'>
                  Logout
                </div>
              </Link>
            ) : (
              <Link to='/' className='flex items-center'>
                <div className='w-[100px] h-[45px] text-[16px] font-medium  flex justify-center items-center  p-4  rounded bg-green-400 cursor-pointer'>
                  Login
                </div>
              </Link>
            )}
          </div>
        </div>
      </section>
    </>
  )
}

export default Navbar
