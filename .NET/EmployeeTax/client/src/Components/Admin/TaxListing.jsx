import React, { useEffect, useState } from 'react'
import { FaEye } from 'react-icons/fa'
import { useDispatch, useSelector } from 'react-redux'
import { Link } from 'react-router-dom'
import {
  unfreezeTaxForm,
  getTaxChangeRequestListing
} from '../../Redux/Actions/TaxAction'
import toast from 'react-hot-toast'
import Pagination from '../Pagination'

const TaxListing = () => {
  // STATE VARIABLES FOR FORM INPUT
  const [year, setYear] = useState()
  const [name, setName] = useState()
  const [empId, setEmpId] = useState()
  const [filteredData, setFilteredData] = useState([])
  const [currentPage, setCurrentPage] = useState(1)
  const [totalPages, setTotalPages] = useState(0)
  const itemsPerPage = 3

  const dispatch = useDispatch()

  //FETCHING VALUE FROM OF VARIABLE'S FROM STORE
  const { loading, changeRequests } = useSelector(state => state.tax)

  useEffect(() => {
    dispatch(getTaxChangeRequestListing())
  }, [dispatch])

  useEffect(() => {
    setFilteredData(changeRequests)
  }, [changeRequests])

<<<<<<< HEAD
  //FILTERING OF DATA BASED ON FILTER SELECTEDS
=======
  //FILTERING OF DATA BASED ON FILTER SELECTED
>>>>>>> 361510a1352e924016f9b4efe1c28c6ee59d6159
  useEffect(() => {
    const filterData = () => {
      let filtered = changeRequests || []
      if (year) {
        filtered = filtered.filter(
          item => item.financialYear === parseInt(year)
        )
      }

      if (name) {
        filtered = filtered.filter(item =>
          item.name.toLowerCase().includes(name.toLowerCase())
        )
      }

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
  }, [changeRequests, currentPage, empId, itemsPerPage, name, year])

  //FUNCTION TO HANDLE PAGE CHANGE
  const handlePageChange = pageNumber => {
    setCurrentPage(pageNumber)
  }

  // FUNCTION TO HANDLE UNFREEZE BUTTON FUNCTIONALITY
  const unfreezeButtonHandler = taxId => {
    dispatch(unfreezeTaxForm(taxId))
      .then(message => {
        dispatch(getTaxChangeRequestListing())
        toast.success('Unfreeze successful')
      })
      .catch(err => {
        toast.error('Failed to unfreeze form')
      })
  }

  return (
    <>
      {loading === false ? (
        <section className='w-full h-full'>
          <div className='max-w-[1200px] mx-auto'>
            <div className='my-4'>
              <h2 className='text-[2rem] font-medium text-center p-2'>
                Tax Declaration Listing
              </h2>
            </div>
            <div className='flex justify-evenly items-center gap-5 my-4'>
              <div className='w-[40%]'>
                <label htmlFor='financial-year' className='leading-7 text-sm '>
                  Financial Year
                </label>
                <select
                  id='text'
                  className='w-full h-[40px] text-[14px] bg-blue-50 outline-none py-1 px-3 mt-1 '
                  value={year}
                  onChange={e => setYear(e.target.value)}
                >
                  <option defaultValue>-- Select --</option>
                  <option value='2019'>2019</option>
                  <option value='2020'>2020</option>
                  <option value='2021'>2021</option>
                  <option value='2022'>2022</option>
                  <option value='2023'>2023</option>
                  <option value='2024'>2024</option>
                  <option value='2025'>2025</option>
                </select>
              </div>
              <div className='w-[40%]'>
                <label htmlFor='name' className='leading-7 text-sm '>
                  Employee Name
                </label>
                <input
                  type='text'
                  id='name'
                  className='w-full h-[40px] text-[14px] bg-blue-50 outline-none py-1 px-3 mt-1 '
                  value={name}
                  onChange={e => setName(e.target.value)}
                />
              </div>
              <div className='w-[40%]'>
                <label htmlFor='empId' className='leading-7 text-sm '>
                  Employee ID
                </label>
                <input
                  type='number'
                  id='empId'
                  className='w-full h-[40px] text-[14px] bg-blue-50 outline-none py-1 px-3 mt-1 '
                  value={empId}
                  onChange={e => setEmpId(e.target.value)}
                />
              </div>
            </div>
            <div className=' overflow-auto my-5 '>
              <table className=' w-[100%] table-auto border-solid border-2 border-black border-collapse rounded mx-auto my-5'>
                <thead>
                  <tr className='w-[100%] border-solid border-2 border-black'>
                    <th className='text-[1.1rem] font-bold bg-blue-100  border border-slate-900 p-3 uppercase text-center'>
                      employee ID
                    </th>
                    <th className='text-[1.1rem] font-bold bg-blue-100 border border-slate-900 p-3  uppercase text-center'>
                      Employee Name
                    </th>
<<<<<<< HEAD
                    <th className='text-[1.1rem] font-bold bg-blue-100  border border-slate-900 p-3 uppercase text-center'>
                      Tax ID
                    </th>
=======
>>>>>>> 361510a1352e924016f9b4efe1c28c6ee59d6159
                    <th className='text-[1.1rem] font-bold bg-blue-100 border border-slate-900 p-3  uppercase text-center'>
                      Date of Submission
                    </th>
                    <th className='text-[1.1rem] font-bold bg-blue-100 border border-slate-900 p-3  uppercase text-center'>
                      Unfreeze Reason
                    </th>
                    <th className='text-[1.1rem] font-bold bg-blue-100 border border-slate-900 p-3  uppercase text-center'>
                      View Declaration
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
<<<<<<< HEAD
                            {i.taxId}
                          </td>
                          <td className='text-[1rem] font-normal border border-slate-900 p-1 capitalize text-center'>
=======
>>>>>>> 361510a1352e924016f9b4efe1c28c6ee59d6159
                            {i.dateOfSubmission}
                          </td>
                          <td className='text-[1rem] font-normal border border-slate-900 p-1 capitalize text-center'>
                            {i.reason}
                          </td>
                          <td className='text-[1rem] font-normal border border-slate-900 p-1 capitalize'>
                            <Link to={`/admin/${i.taxId}`}>
                              <span className='flex justify-center'>
                                <FaEye size={22} />
                              </span>
                            </Link>
                          </td>
                          <td className='text-[1rem] font-normal border border-slate-900 p-1 capitalize text-center px-4 '>
                            <button
                              className='w-full h-[35px] text-[14px] bg-blue-200 outline-none p-2 rounded '
                              onClick={() => unfreezeButtonHandler(i.taxId)}
                            >
                              Unfreeze
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
        ''
      )}
    </>
  )
}

export default TaxListing
