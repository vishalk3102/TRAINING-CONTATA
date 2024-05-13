import React, { useEffect, useState } from 'react'
import { useDispatch, useSelector } from 'react-redux'
import {
  getTaxChangeRequestListing,
  getTaxDeclaration,
  requestChange
} from '../../Redux/Actions/TaxAction'
import { useNavigate, useParams } from 'react-router-dom'
import Loader from '../Loader'
import toast from 'react-hot-toast'

const RequestChange = () => {
  // STATE VARIABLES FOR FORM INPUT
  const [empId, setEmpId] = useState()
  const [taxId, setTaxId] = useState()
  const [name, setName] = useState()
  const [financialYear, setFinancialYear] = useState()
  const [reason, setReason] = useState()

  // FETCHING VALUES FROM STORE
  const { loading, user } = useSelector(state => state.auth)
  const { tax, changeRequests } = useSelector(state => state.tax)

  const dispatch = useDispatch()
  const params = useParams()
  const navigate = useNavigate()

  useEffect(() => {
    dispatch(getTaxDeclaration(params.taxId))
  }, [dispatch])

  useEffect(() => {
    dispatch(getTaxChangeRequestListing())
  }, [dispatch])

  useEffect(() => {
    if (user) {
      setEmpId(user.empId)
      setName(user.name)
    }
    if (tax && tax.length > 0 && tax[0].taxDeclaration) {
      setTaxId(tax[0].taxDeclaration.taxId)
      setFinancialYear(tax[0].taxDeclaration.financialYear)
    }
  }, [tax, user])

  // FUNCTION TO HANDLE FORM SUBMISSION
  const formHandler = e => {
    e.preventDefault()

    let existingRequest = changeRequests.find(
      req => req.taxDeclaration.taxId === taxId
    )
    if (existingRequest) {
      toast.error('Tax form already submitted for this financial year.')
      return
    }

    // --Validation of form before submission --
    if (!reason) {
      toast.error('All fields are required')
      return
    }
    const formData = {
      taxId,
      empId,
      name,
      financialYear,
      reason,
      dateOfSubmission: tax.dateOfDeclaration
    }

    dispatch(requestChange(formData))
      .then(message => {
        if (message) {
          setTaxId('')
          setEmpId('')
          setName('')
          setFinancialYear('')
          setReason('')
          toast.success('Request submitted successfully')
          navigate('/submissions')
        }
      })
      .catch(err => {
        toast.error('Failed to submit the change request ')
      })
  }

  return (
    <>
      {loading === false ? (
        <section className='w-full h-full'>
          <div className='max-w-[1200px] mx-auto'>
            <div className='text-[1.8rem] font-medium text-center p-2 my-5'>
              <h1>Tax Declaration Change Request Form</h1>
            </div>
            <div className=''>
              <form
                onSubmit={formHandler}
                className='w-[40%] flex flex-col justify-evenly items-center gap-5  bg-blue-200 mx-auto my-5 py-10 rounded-[10px]'
              >
                <div className='w-[60%]'>
                  <label htmlFor='empId' className='leading-7 text-sm '>
                    Employee Id
                  </label>
                  <input
                    type='numer'
                    id='empId'
                    className='w-full h-[40px] text-[14px] bg-blue-50 outline-none py-1 px-3 mt-1 '
                    value={empId}
                    onChange={e => setEmpId(e.target.value)}
                  />
                </div>
                <div className='w-[60%]'>
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
                <div className='w-[60%]'>
                  <label htmlFor='taxId' className='leading-7 text-sm '>
                    Tax Declaration Id
                  </label>
                  <input
                    type='number'
                    id='taxId'
                    className='w-full h-[40px] text-[14px] bg-blue-50 outline-none py-1 px-3 mt-1 '
                    value={taxId}
                    onChange={e => setTaxId(e.target.value)}
                  />
                </div>
                <div className='w-[60%]'>
                  <label
                    htmlFor='financial-year'
                    className='leading-7 text-sm '
                  >
                    Financial Year
                  </label>
                  <select
                    id='number'
                    className='w-full h-[40px] text-[14px] bg-blue-50 outline-none py-1 px-3 mt-1 '
                    value={financialYear}
                    onChange={e => setFinancialYear(e.target.value)}
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
                <div className='w-[60%]'>
                  <label htmlFor='reason' className='leading-7 text-sm '>
                    Reason For Change
                  </label>
                  <input
                    type='text'
                    id='reason'
                    className='w-full h-[40px] text-[14px] bg-blue-50 outline-none py-1 px-3 mt-1 '
                    value={reason}
                    onChange={e => setReason(e.target.value)}
                  />
                </div>
                <div className='w-[80%] flex  justify-center items-center mt-4 '>
                  {' '}
                  <button
                    type='submit'
                    className='bg-blue-500 px-6  py-3 rounded  text-white'
                  >
                    Submit Request
                  </button>
                </div>
              </form>
            </div>
          </div>
        </section>
      ) : (
        <Loader />
      )}
    </>
  )
}

export default RequestChange
