import React, { useEffect, useState } from 'react'
import { useDispatch, useSelector } from 'react-redux'
import { addEmployee } from '../../Redux/Actions/EmployeeAction'
import toast from 'react-hot-toast'
import { useNavigate } from 'react-router-dom'

const AddEmployee = () => {
  // STATE VARIABLES FOR FORM INPUT
  const [name, setName] = useState()
  const [phoneNumber, setPhoneNumber] = useState()
  const [gender, setGender] = useState()
  const [panNo, setPanNo] = useState()
  const [address, setAddress] = useState()
  const [dob, setDob] = useState()
  // const [age, setAge] = useState()
  const [role, setRole] = useState()
  const [password, setPassword] = useState()

  const dispatch = useDispatch()
  const navigate = useNavigate()

  // FUNCTION TO HANDLE ADD BUTTON --adding employee details
  const HandleAddButton = e => {
    e.preventDefault()

    // --Validation of form before submission --
    if (
      !name ||
      !phoneNumber ||
      !gender ||
      !panNo ||
      !address ||
      !dob ||
      !role ||
      !password
    ) {
      toast.error('All fields are required')
      return
    }

    const today = new Date()
    const dobDate = new Date(dob)
    let calculatedAge = today.getFullYear() - dobDate.getFullYear()
    const monthDiff = today.getMonth() - dobDate.getMonth()

    if (
      monthDiff < 0 ||
      (monthDiff === 0 && today.getDate() < dobDate.getDate())
    ) {
      calculatedAge--
    }

    const formData = {
      name,
      age: calculatedAge,
      dateOfBirth: dob,
      gender,
      phoneNumber,
      panNo,
      address,
      role,
      password
    }
    dispatch(addEmployee(formData))
      .then(response => {
        if (response) {
          setName('')
          setDob('')
          setPhoneNumber('')
          setGender('')
          setPanNo('')
          setAddress('')
          setRole('')
          setPassword('')
          toast.success('Employee Added Successfully')
          navigate('/admin/employees')
        }
      })
      .catch(err => {
        toast.error('Failed to added Employee')
      })
  }

  return (
    <>
      <section className='w-full h-full'>
        <div className='w-[100%] max-w-[1200px] mx-auto '>
          <div className='my-4'>
            <h2 className='text-[2rem] font-medium text-center p-2'>
              Add Employee Details
            </h2>
          </div>
          <form onSubmit={HandleAddButton}>
            <div className='w-[70%]  flex justify-center items-center flex-wrap gap-6 mx-auto mt-5 '>
              <div className='w-[40%]'>
                <label htmlFor='name' className='leading-7 text-sm '>
                  Full Name
                </label>
                <input
                  type='text'
                  id='name'
                  value={name}
                  onChange={e => setName(e.target.value)}
                  className='px-2 bg-blue-50 py-3 rounded-sm text-base w-full accent-blue-700 outline-none'
                />
              </div>
              <div className='w-[40%]'>
                <label htmlFor='dob' className='leading-7 text-sm '>
                  Date of Birth
                </label>
                <input
                  type='date'
                  id='dob'
                  value={dob}
                  onChange={e => setDob(e.target.value)}
                  className='px-2 bg-blue-50 py-3 rounded-sm text-base w-full accent-blue-700 outline-none'
                />
              </div>
              <div className='w-[40%]'>
                <label htmlFor='phoneNumber' className='leading-7 text-sm '>
                  Phone Number
                </label>
                <input
                  type='text'
                  id='phoneNumber'
                  value={phoneNumber}
                  onChange={e => setPhoneNumber(e.target.value)}
                  className='px-2 bg-blue-50 py-3 rounded-sm text-base w-full accent-blue-700 outline-none'
                />
              </div>
              <div className='w-[40%]'>
                <label htmlFor='gender' className='leading-7 text-sm '>
                  Select Gender
                </label>
                <select
                  id='gender'
                  className='px-2 bg-blue-50 py-3 rounded-sm text-base w-full accent-blue-700 outline-none'
                  value={gender}
                  onChange={e => setGender(e.target.value)}
                >
                  <option defaultValue>-- Select --</option>
                  <option value='Male'>Male</option>
                  <option value='Female'>Female</option>
                </select>
              </div>{' '}
              <div className='w-[40%]'>
                <label htmlFor='panNo' className='leading-7 text-sm '>
                  Pan Card Number
                </label>
                <input
                  type='text'
                  id='panNo'
                  value={panNo}
                  onChange={e => setPanNo(e.target.value)}
                  className='px-2 bg-blue-50 py-3 rounded-sm text-base w-full accent-blue-700 outline-none'
                />
              </div>
              <div className='w-[40%]'>
                <label htmlFor='address' className='leading-7 text-sm '>
                  Address
                </label>
                <input
                  type='text'
                  id='address'
                  value={address}
                  onChange={e => setAddress(e.target.value)}
                  className='px-2 bg-blue-50 py-3 rounded-sm text-base w-full accent-blue-700 outline-none'
                />
              </div>
              <div className='w-[40%]'>
                <label htmlFor='role' className='leading-7 text-sm '>
                  Select Role
                </label>
                <select
                  id='role'
                  className='px-2 bg-blue-50 py-3 rounded-sm text-base w-full accent-blue-700 outline-none'
                  value={role}
                  onChange={e => setRole(e.target.value)}
                >
                  <option defaultValue>-- Select --</option>
                  <option value='admin'>Admin</option>
                  <option value='employee'>Employee</option>
                </select>
              </div>
              <div className='w-[40%]'>
                <label htmlFor='password' className='leading-7 text-sm '>
                  Password
                </label>
                <input
                  type='text'
                  id='password'
                  value={password}
                  onChange={e => setPassword(e.target.value)}
                  className='px-2 bg-blue-50 py-3 rounded-sm text-base w-full accent-blue-700 outline-none'
                />
              </div>
              <div className='w-[80%] flex  justify-center items-center mb-20 '>
                {' '}
                <button
                  type='submit'
                  className='bg-blue-500 px-6  py-3  rounded-sm  text-white'
                >
                  Add Employee
                </button>
              </div>
            </div>
          </form>
        </div>
      </section>
    </>
  )
}

export default AddEmployee
