import React, { useEffect, useState } from 'react'
import { FaEye } from 'react-icons/fa'
import { useDispatch, useSelector } from 'react-redux'
import { getMyTaxDeclaration } from '../../Redux/Actions/TaxAction'
import { Link } from 'react-router-dom'
import Loader from '../Loader'

const PreviousSubmission = () => {
  // FETCHING VALUES FROM STORE
  const { loading, taxes } = useSelector(state => state.tax)
  const { user } = useSelector(state => state.auth)
  const dispatch = useDispatch()

  useEffect(() => {
    dispatch(getMyTaxDeclaration(user.empId))
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [dispatch])
  return (
    <>
      {loading === false ? (
        <section className='w-full h-full'>
          <div className='max-w-[1200px] mx-auto'>
            <div className='my-4'>
              <h2 className='text-[2rem] font-medium text-center p-2'>
                Previous Submission
              </h2>
            </div>
            <div className=' overflow-auto my-5 '>
              <table className=' w-[100%] table-auto border-solid border-2 border-black border-collapse rounded mx-auto my-5'>
                <thead>
                  <tr className='w-[100%] border-solid border-2 border-black'>
                    <th className='text-[1.1rem] font-bold bg-blue-100  border border-slate-900 p-3 uppercase text-center'>
                      Tax ID
                    </th>
                    <th className='text-[1.1rem] font-bold bg-blue-100 border border-slate-900 p-3  uppercase text-center'>
                      Financial Year
                    </th>
                    <th className='text-[1.1rem] font-bold bg-blue-100 border border-slate-900 p-3  uppercase text-center'>
                      Declaration Status
                    </th>
                    <th className='text-[1.1rem] font-bold bg-blue-100 border border-slate-900 p-3  uppercase text-center'>
                      Declaration Date
                    </th>
                    <th className='text-[1.1rem] font-bold bg-blue-100 border border-slate-900 p-3  uppercase text-center'>
                      View
                    </th>
                    <th className='text-[1.1rem] font-bold bg-blue-100 border border-slate-900 p-3  uppercase text-center'>
                      Action
                    </th>
                  </tr>
                </thead>
                <tbody>
                  {Array.isArray(taxes) && taxes.length > 0 ? (
                    taxes.map((i, index) => {
                      return (
                        <tr className='border border-slate-900  ' key={index}>
                          <td className='text-[1rem] font-normal border border-slate-900 p-1 capitalize text-center'>
                            {i.taxId}
                          </td>
                          <td className='text-[1rem] font-normal border border-slate-900 p-1 capitalize text-center'>
                            {i.financialYear}
                          </td>
                          <td className='text-[1rem] font-normal border border-slate-900 p-1 capitalize text-center'>
<<<<<<< HEAD
                            Submitted
                          </td>
                          <td className='text-[1rem] font-normal border border-slate-900 p-1 capitalize text-center'>
                            {i.dateOfDeclaration}
=======
                            {i.taxId}
                          </td>
                          <td className='text-[1rem] font-normal border border-slate-900 p-1 capitalize text-center'>
                            {i.taxId}
>>>>>>> 361510a1352e924016f9b4efe1c28c6ee59d6159
                          </td>
                          <td className='text-[1rem] font-normal border border-slate-900 p-1 capitalize'>
                            <Link to={`/submission/${i.taxId}`}>
                              <span className='flex justify-center cursor-pointer'>
                                <FaEye size={22} />
                              </span>
                            </Link>
                          </td>
                          <td className='text-[1rem] font-medium border border-slate-900 capitalize  p-3 '>
                            <Link to={`/change-request/${i.taxId}`}>
                              <button className='w-full h-[35px] text-[14px] bg-blue-300 outline-none px-2 py-4 rounded flex justify-center items-center'>
                                Request For Change
                              </button>
                            </Link>
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
          </div>
        </section>
      ) : (
        <Loader />
      )}
    </>
  )
}

export default PreviousSubmission
