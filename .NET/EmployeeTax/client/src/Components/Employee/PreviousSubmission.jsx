import React, { useEffect } from 'react'
import { FaEye } from 'react-icons/fa'
import { useDispatch, useSelector } from 'react-redux'
import {
  deleteTaxDeclaration,
  getMyTaxDeclaration
} from '../../Redux/Actions/TaxAction'
import { Link } from 'react-router-dom'
import Loader from '../Loader'
import toast from 'react-hot-toast'

const PreviousSubmission = () => {
  // FETCHING VALUES FROM STORE
  const { loading, mytaxes } = useSelector(state => state.tax)
  const { user } = useSelector(state => state.auth)
  const dispatch = useDispatch()

  useEffect(() => {
    dispatch(getMyTaxDeclaration(user.empId))
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [dispatch])

  const handleDeleteButton = taxId => {
    dispatch(deleteTaxDeclaration(taxId))
      .then(message => {
        if (message) {
          toast.success(message)
          dispatch(dispatch(getMyTaxDeclaration(user.empId)))
        } else {
          toast.error('Failed to Delete Tax Declaration')
        }
      })
      .catch(err => {
        toast.error('Failed to Delete Tax Declaration')
      })
  }

  return (
    <>
      {loading === false ? (
        <section className='w-full h-full mb-20'>
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
                  {Array.isArray(mytaxes) && mytaxes.length > 0 ? (
                    mytaxes.map((i, index) => {
                      return (
                        <tr className='border border-slate-900  ' key={index}>
                          <td className='text-[1rem] font-normal border border-slate-900 p-1 capitalize text-center'>
                            {i.taxId}
                          </td>
                          <td className='text-[1rem] font-normal border border-slate-900 p-1 capitalize text-center'>
                            {i.financialYear}
                          </td>
                          <td className='text-[1rem] font-normal border border-slate-900 p-1 capitalize text-center'>
                            {i.isDrafted === true && i.isRejected === true
                              ? 'Drafted'
                              : i.isSubmitted === true && i.isRejected === true
                              ? 'Submitted'
                              : i.status.isDrafted === true
                              ? 'Drafted'
                              : i.status}
                          </td>
                          <td className='text-[1rem] font-normal border border-slate-900 p-1 capitalize text-center'>
                            {i.dateOfDeclaration}
                          </td>
                          <td className='text-[1rem] font-normal border border-slate-900 p-1 capitalize'>
                            <Link to={`/submission/${i.taxId}`}>
                              <span className='flex justify-center cursor-pointer'>
                                <FaEye size={22} />
                              </span>
                            </Link>
                          </td>
                          <td className='text-[1rem] font-medium border border-slate-900 capitalize  p-3 '>
                            {i.status === 'accepted' ? (
                              ''
                            ) : i.status === 'drafted' ? (
                              <button
                                className='text-[14px] font-medium bg-red-400 outline-none py-2 px-4 rounded m-1'
                                onClick={() => handleDeleteButton(i.taxId)}
                              >
                                Delete
                              </button>
                            ) : i.status === 'submitted' ? (
                              <Link to={`/change-request/${i.taxId}`}>
                                <button className='text-[14px] font-medium bg-blue-400 outline-none py-2 px-4 rounded m-1'>
                                  Request For Change
                                </button>
                              </Link>
                            ) : (
                              ''
                            )}
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
