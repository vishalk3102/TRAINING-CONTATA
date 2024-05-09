import React, { useEffect, useState } from 'react'
import { FiSearch } from 'react-icons/fi'
import { IoIosAdd } from 'react-icons/io'
import { MdDelete, MdEdit } from 'react-icons/md'
import { useDispatch, useSelector } from 'react-redux'
import Loader from '../Loader'

import {
  deleteEmployee,
  getAllEmployee
} from '../../Redux/Actions/EmployeeAction'
import { Link } from 'react-router-dom'
import toast from 'react-hot-toast'
import Pagination from '../Pagination'

const Employees = () => {
  // STATE VARIABLES FOR FORM INPUT
  const [empId, setEmpId] = useState()
  const [filteredData, setFilteredData] = useState([])
  const [currentPage, setCurrentPage] = useState(1)
  const [totalPages, setTotalPages] = useState(0)
  const itemsPerPage = 5

  const dispatch = useDispatch()
  const { loading, employees } = useSelector(state => state.employee)

  useEffect(() => {
    dispatch(getAllEmployee())
  }, [dispatch])

  useEffect(() => {
    setFilteredData(employees)
  }, [employees])

  //FILTERING OF DATA BASED ON FILTER SELECTED
  useEffect(() => {
    const filterData = () => {
      let filtered = employees
      if (empId) {
        filtered = filtered.filter(item =>
          item.empId.toString().includes(empId)
        )
      }
      const indexOfLastItem = currentPage * itemsPerPage
      const indexOfFirstItem = indexOfLastItem - itemsPerPage
      const currentItems = Array.isArray(filtered)
        ? filtered.slice(indexOfFirstItem, indexOfLastItem)
        : []

      setFilteredData(currentItems)
      setTotalPages(Math.ceil(filtered.length / itemsPerPage))
    }

    filterData()
  }, [currentPage, empId, employees])

  //FUNCTION TO HANDLE PAGE CHANGE
  const handlePageChange = pageNumber => {
    setCurrentPage(pageNumber)
  }

  //FUNCTION TO HANDLE DELETE BUTTON
  const handleDeleteButton = empId => {
    dispatch(deleteEmployee(empId))
      .then(() => {
        toast.success('Employee Deleted successfully')
        dispatch(getAllEmployee())
      })
      .catch(err => {
        toast.error('Failed to delete Employee')
      })
  }

  return (
    <>
      {loading === false ? (
        <section className='w-full h-full'>
          <div className='max-w-[1200px] mx-auto'>
            <div className='my-4'>
              <h2 className='text-[2rem] font-medium text-center p-2'>
                Employee's List
              </h2>
            </div>
            <div className='flex justify-evenly items-center gap-5 mt-8'>
              <div className='w-[40%] flex '>
                <input
                  type='number'
                  id='empId'
                  className='w-full h-[40px] text-[14px] bg-blue-50 outline-none py-1 px-3 mt-1 '
                  placeholder='Employee Id'
                  value={empId}
                  onChange={e => setEmpId(e.target.value)}
                />
                <button
                  className='px-4 text-2xl hover:text-blue-500'
                  type='submit'
                >
                  <FiSearch />
                </button>
              </div>
            </div>
            <div className='flex justify-end mt-8'>
              <Link to={'/admin/employee/add'}>
                <button className='text-[#fff] text-[14px] font-semibold flex justify-center items-center bg-blue-500  rounded p-3 hover:bg-blue-700 ease-linear duration-300 hover:ease-linear hover:duration-300 hover:transition-all transition-all'>
                  {' '}
                  Add Employee{' '}
                  <span className=''>
                    <IoIosAdd size={24} />
                  </span>
                </button>
              </Link>
            </div>
            <div className=' overflow-auto mb-5 '>
              <table className=' w-[100%] table-auto border-solid border-2 border-black border-collapse rounded mx-auto my-5'>
                <thead>
                  <tr className='w-[100%] border-solid border-2 border-black'>
                    <th className='text-[1.1rem] font-bold bg-blue-100  border border-slate-900 p-3 uppercase text-center'>
                      employee ID
                    </th>
                    <th className='text-[1.1rem] font-bold bg-blue-100 border border-slate-900 p-3  uppercase text-center'>
                      Employee Name
                    </th>
                    <th className='text-[1.1rem] font-bold bg-blue-100 border border-slate-900 p-3  uppercase text-center'>
                      Age
                    </th>
                    <th className='text-[1.1rem] font-bold bg-blue-100 border border-slate-900 p-3  uppercase text-center'>
                      Gender
                    </th>
                    <th className='text-[1.1rem] font-bold bg-blue-100 border border-slate-900 p-3  uppercase text-center'>
                      phoneNumber
                    </th>
                    <th className='text-[1.1rem] font-bold bg-blue-100 border border-slate-900 p-3  uppercase text-center'>
                      Pan Card Number
                    </th>
                    <th className='text-[1.1rem] font-bold bg-blue-100 border border-slate-900 p-3  uppercase text-center'>
                      Address
                    </th>
                    <th className='text-[1.1rem] font-bold bg-blue-100 border border-slate-900 p-3  uppercase text-center'>
                      Action
                    </th>
                  </tr>
                </thead>
                <tbody>
                  {Array.isArray(filteredData) && filteredData.length > 0 ? (
                    filteredData.map((i, index) => {
                      return (
                        <tr className='border border-slate-900  ' key={index}>
                          <td className='text-[1rem] font-normal border border-slate-900 p-1 capitalize text-center'>
                            {i.empId}
                          </td>
                          <td className='text-[1rem] font-normal border border-slate-900 p-1 capitalize text-center'>
                            {i.name}
                          </td>
                          <td className='text-[1rem] font-normal border border-slate-900 p-1 capitalize text-center'>
                            {i.age}
                          </td>
                          <td className='text-[1rem] font-normal border border-slate-900 p-1  text-center'>
                            {i.gender}
                          </td>
                          <td className='text-[1rem] font-normal border border-slate-900 p-1 capitalize text-center'>
                            {i.phoneNumber}
                          </td>
                          <td className='text-[1rem] font-normal border border-slate-900 p-1 capitalize text-center'>
                            {i.panNo}
                          </td>
                          <td className='text-[1rem] font-normal border border-slate-900 p-1 capitalize text-center'>
                            {i.address}
                          </td>
                          <td className='text-[0.7rem] md:text-[1rem] font-normal border border-slate-900 p-1 capitalize text-center'>
                            <Link to={`/admin/employee/${i.empId}`}>
                              <button className='p-1 m-1'>
                                <MdEdit size={24} />
                              </button>
                            </Link>
                            <button
                              className='p-1 m-1'
                              onClick={() => handleDeleteButton(i.empId)}
                            >
                              <MdDelete size={24} />
                            </button>
                          </td>
                        </tr>
                      )
                    })
                  ) : (
                    <tr>
                      <td
                        colSpan='6'
                        className='text-[1rem] font-normal border border-slate-900 p-4 text-center'
                      >
                        No data available
                      </td>
                    </tr>
                  )}
                  {}
                </tbody>
              </table>
            </div>

            {/* PAGINATION COMPONENT  */}
            <Pagination
              totalPages={totalPages}
              currentPage={currentPage}
              onPageChange={handlePageChange}
            />
          </div>
        </section>
      ) : (
        <Loader />
      )}
    </>
  )
}

export default Employees
