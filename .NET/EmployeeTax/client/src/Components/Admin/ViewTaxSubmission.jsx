import React, { useEffect, useState } from 'react'
import { useDispatch, useSelector } from 'react-redux'
import { Link, useNavigate, useParams } from 'react-router-dom'
import toast from 'react-hot-toast'
import {
  acceptTaxDeclaration,
  getTaxDeclaration,
  rejectTaxDeclaration
} from '../../Redux/Actions/TaxAction'
import Loader from '../Loader'

const ViewTaxSubmission = () => {
  const dispatch = useDispatch()
  const params = useParams()
  const navigate = useNavigate()
  const editable = false

  //FETCHING VALUE FROM OF VARIABLE'S FROM STORE
  const { loading, tax } = useSelector(state => state.tax)

  useEffect(() => {
    dispatch(getTaxDeclaration(params.taxId))
  }, [dispatch])

  // CHECK IF TAX OBJECT EXIST AND HAS EMPLOYEE AND TAX DECLARATION
  if (!tax || !tax.length || !tax[0].taxDeclaration || !tax[0].employee) {
    return <Loader />
  }

  // FUNCTION TO HANDLE ACCEPT BUTTON CLICK
  const handleAcceptButton = () => {
    dispatch(acceptTaxDeclaration(tax[0].taxDeclaration.taxId))
      .then(() => {
        navigate('/admin/submissions')
        toast.success('Accepted successful')
      })
      .catch(err => {
        toast.error('Failed to Accept form')
      })
  }

  // FUNCTION TO HANDLE REJECT BUTTON CLICK
  const handleRejectButton = () => {
    dispatch(rejectTaxDeclaration(tax[0].taxDeclaration.taxId))
      .then(() => {
        navigate('/admin/submissions')
        toast.success('Rejected successful')
      })
      .catch(err => {
        toast.error('Failed to Reject form')
      })
  }
  return (
    <>
      {loading === false ? (
        <section className='w-full h-full'>
          <div className='max-w-[1200px] mx-auto  my-2'>
            <div className='text-[1.8rem] font-medium text-center p-2 my-2'>
              <h1>Tax Declaration</h1>
            </div>
            <form>
              <div className='flex justify-between items-center my-2 border-2 border-solid border-black py-2'>
                <div className='text-[16px] font-medium  p-4'>
                  Employee ID :
                  <span className='p-2'> {tax[0].employee.empId}</span>
                </div>
                <div className='text-[16px] font-medium  p-4'>
                  Employee Name :
                  <span className='p-2'> {tax[0].employee.name}</span>
                </div>
                <div className='text-[16px] font-medium  p-4'>
                  Financial Year :
                  <span className='p-2'>
                    {' '}
                    {tax[0].taxDeclaration.financialYear}
                  </span>
                </div>
                <div className='text-[16px] font-medium  p-4'>
                  Tax declaration Id :
                  <span className='p-2'> {tax[0].taxDeclaration.taxId}</span>
                </div>
              </div>

              <div className='border-solid border-2 border-black'>
                <div className='flex items-center  py-2 ml-2'>
                  <div className='w-[70%] py-1'>
                    <label htmlFor='income' className='text-[14px]'>
                      1.) Any other income (interest from property, rental
                      income, etc.)
                    </label>
                  </div>
                  <div className='w-[25%]'>
                    <input
                      type='text'
                      name='income'
                      id='income'
                      placeholder='0'
                      className='w-[100%]  border-solid border-2 border-black px-2 py-1 text-[14px] outline-none'
                      value={tax[0].taxDeclaration.anyOtherIncome}
                      disabled={!editable}
                    />
                  </div>
                </div>
                <div className=''>
                  <h4 className='text-[14px] py-2 ml-2'>
                    2.)Investment under Section 80C
                  </h4>
                  <div className='py-2 ml-3'>
                    <div className='flex  w-[100%]'>
                      <div className='w-[70%] py-1'>
                        <label htmlFor='ssa' className='text-[14px] py-2'>
                          a.) Sukanya Samriddhi Account
                        </label>
                      </div>
                      <div className='w-[25%] my-1'>
                        <input
                          type='text'
                          name='ssa'
                          id='ssa'
                          placeholder='0'
                          className='w-[100%]  border-solid border-2 border-black px-2 py-1 text-[14px] outline-none'
                          value={tax[0].taxDeclaration.sukanyaSamriddhiAccount}
                          disabled={!editable}
                        />
                      </div>
                    </div>
                    <div className='flex  w-[100%]'>
                      <div className='w-[70%] py-1'>
                        <label htmlFor='ppf' className='text-[14px] py-2'>
                          a.) PPF/NSC
                        </label>
                      </div>
                      <div className='w-[25%] my-1'>
                        <input
                          type='text'
                          name='ppf'
                          id='ppf'
                          placeholder='0'
                          className='w-[100%]  border-solid border-2 border-black px-2 py-1 text-[14px] outline-none'
                          value={tax[0].taxDeclaration.ppf}
                          disabled={!editable}
                        />
                      </div>
                    </div>
                    <div className='flex  w-[100%]'>
                      <div className='w-[70%] py-1'>
                        <label htmlFor='lic' className='text-[14px] py-2'>
                          b.) Life Insurance Premium
                        </label>
                      </div>
                      <div className='w-[25%] my-1'>
                        <input
                          type='text'
                          name='lic'
                          id='lic'
                          placeholder='0'
                          className='w-[100%]  border-solid border-2 border-black px-2 py-1 text-[14px] outline-none'
                          value={tax[0].taxDeclaration.lifeInsurancePremium}
                          disabled={!editable}
                        />
                      </div>
                    </div>
                    <div className='flex  w-[100%]'>
                      <div className='w-[70%] py-1'>
                        <label
                          htmlFor='tuitionfee'
                          className='text-[14px] py-2'
                        >
                          c.) Tuition fee for child
                        </label>
                      </div>
                      <div className='w-[25%] my-1'>
                        <input
                          type='text'
                          name='tuitionfee'
                          id='tuitionfee'
                          placeholder='0'
                          className='w-[100%]  border-solid border-2 border-black px-2 py-1 text-[14px] outline-none'
                          value={tax[0].taxDeclaration.tuitionFee}
                          disabled={!editable}
                        />
                      </div>
                    </div>
                    <div className='flex  w-[100%]'>
                      <div className='w-[70%] py-1'>
                        <label
                          htmlFor='fixed-deposit'
                          className='text-[14px] py-2'
                        >
                          d.) Bank Fixed Deposits/NSC (in Five Years)
                        </label>
                      </div>
                      <div className='w-[25%] my-1'>
                        <input
                          type='text'
                          name='fixed-deposit'
                          id='fixed-deposit'
                          placeholder='0'
                          className='w-[100%]  border-solid border-2 border-black px-2 py-1 text-[14px] outline-none'
                          value={tax[0].taxDeclaration.bankFixedDeposit}
                          disabled={!editable}
                        />
                      </div>
                    </div>
                    <div className='flex  w-[100%]'>
                      <div className='w-[70%] py-1'>
                        <label htmlFor='housing' className='text-[14px] py-2'>
                          e.) Principal amount of housing loan paid during the
                          year
                        </label>
                      </div>
                      <div className='w-[25%] my-1'>
                        <input
                          type='text'
                          name='housing'
                          id='housing'
                          placeholder='0'
                          className='w-[100%]  border-solid border-2 border-black px-2 py-1 text-[14px] outline-none'
                          value={tax[0].taxDeclaration.principalHousingLoan}
                          disabled={!editable}
                        />
                      </div>
                    </div>
                    <div className='flex  w-[100%]'>
                      <div className='w-[70%] py-1'>
                        <label htmlFor='NPS' className='text-[14px] py-2'>
                          d.) National Pension Scheme 80CCD (1B) (Limit 50k)
                        </label>
                      </div>
                      <div className='w-[25%] my-1'>
                        <input
                          type='text'
                          name='NPS'
                          id='NPS'
                          placeholder='0'
                          className='w-[100%]  border-solid border-2 border-black px-2 py-1 text-[14px] outline-none'
                          value={tax[0].taxDeclaration.nps}
                          disabled={!editable}
                        />
                      </div>
                    </div>
                  </div>
                </div>
                <div className='flex items-center  py-2 ml-2'>
                  <div className='w-[70%] py-1'>
                    <label htmlFor='health' className='text-[14px] py-2'>
                      3.) Higher Education Loan interest via EDE
                    </label>
                  </div>
                  <div className='w-[25%] '>
                    <input
                      type='text'
                      name='health'
                      id='health'
                      placeholder='0'
                      className='w-[100%]  border-solid border-2 border-black px-2 py-1 text-[14px] outline-none'
                      value={tax[0].taxDeclaration.higherEducationLoanInterest}
                      disabled={!editable}
                    />
                  </div>
                </div>
                <div className='flex items-center  py-2 ml-2'>
                  <div className='w-[70%] py-1'>
                    <label htmlFor='housing-loan' className='text-[14px] py-2'>
                      4.)Interest paid on Housing Loan via 24
                    </label>
                  </div>
                  <div className='w-[25%]'>
                    <input
                      type='text'
                      name='housing-loan'
                      id='housing-loan'
                      placeholder='0'
                      className='w-[100%]  border-solid border-2 border-black px-2 py-1 text-[14px] outline-none'
                      value={tax[0].taxDeclaration.interestHousingLoan}
                      disabled={!editable}
                    />
                  </div>
                </div>
                <div className='flex items-center  py-2 ml-2'>
                  <div className='w-[70%] py-1'>
                    <label htmlFor='house-rent' className='text-[14px] py-2'>
                      5.) House Rent paid (every month/For above amt Rs
                      8333/-PM) (part of amount liable to provide)
                    </label>
                  </div>
                  <div className='w-[25%]'>
                    <input
                      type='text'
                      name='house-rent'
                      id='house-rent'
                      placeholder='0'
                      className='w-[100%] border-solid border-2 border-black  px-2 py-1 text-[14px] outline-none'
                      value={tax[0].taxDeclaration.houseRent}
                      disabled={!editable}
                    />
                  </div>
                </div>
                <div className='flex items-center  py-2 ml-2'>
                  <div className='w-[70%] py-1'>
                    <label htmlFor='TDS' className='text-[14px] py-2'>
                      6.) Tax Deducted at Source by the previous employer at TCS
                    </label>
                  </div>
                  <div className='w-[25%]'>
                    <input
                      type='text'
                      name='TDS'
                      id='TDS'
                      placeholder='0'
                      className='w-[100%]  border-solid border-2 border-black px-2 py-1 text-[14px] outline-none'
                      value={tax[0].taxDeclaration.tds}
                      disabled={!editable}
                    />
                  </div>
                </div>
                <div className='flex items-center  py-2 ml-2'>
                  <div className='w-[70%] py-1'>
                    <label
                      htmlFor='health-insurance'
                      className='text-[14px] py-2'
                    >
                      7.) Health insurance policy - Premium (RS 25,000)
                    </label>
                  </div>
                  <div className='w-[25%]'>
                    <input
                      type='text'
                      name='health-insurance'
                      id='health-insurance'
                      placeholder='0'
                      className='w-[100%]  border-solid border-2 border-black px-2 py-1 text-[14px] outline-none'
                      value={tax[0].taxDeclaration.mediClaim}
                      disabled={!editable}
                    />
                  </div>
                </div>
                <div className='flex items-center  py-2 ml-2'>
                  <div className='w-[70%] py-1'>
                    <label htmlFor='health' className='text-[14px] py-2'>
                      8.)Preventive Health check-up for Self & Family (80D)
                      (Limit 5k)
                    </label>
                  </div>
                  <div className='w-[25%] py-1'>
                    <input
                      type='text'
                      name='health'
                      id='health'
                      placeholder='0'
                      className='w-[100%]  border-solid border-2 border-black px-2  text-[14px] outline-none'
                      value={tax[0].taxDeclaration.preventiveHealthCheckUp}
                      disabled={!editable}
                    />
                  </div>
                </div>
              </div>

              <div className='mt-4'>
                <div className='text-[1.4rem] font-medium text-left py-2 mt-2'>
                  <h1>Reimbursement Component</h1>
                </div>
                <div className='flex  py-4 border-2 border-solid border-black'>
                  <div className='w-[70%]'>
                    <label htmlFor='LTA' className='leading-7 text-sm p-2'>
                      LTA (Do you want LTA as a Reimbursement)
                    </label>
                  </div>
                  <div className='flex justify-center items-center'>
                    <input
                      type='checkbox'
                      name='LTA'
                      id='LTA'
                      className='h-[20px] w-[20px]'
                      checked={tax[0].taxDeclaration.lta}
                      disabled={!editable}
                    />
                  </div>
                </div>
              </div>
              <div className='flex justify-between my-2 '>
                <div className='text-[16px] font-medium  p-4'>
                  Staff No :
                  <span className='p-2'> {tax[0].employee.empId}</span>
                </div>
                <div className='text-[16px] font-medium  p-4'>
                  Name of the Staff :
                  <span className='p-2'> {tax[0].employee.name}</span>
                </div>
                <div className='text-[16px] font-medium  p-4'>
                  PAN No :<span className='p-2'> {tax[0].employee.panNo}</span>
                </div>

                <div className='text-[16px] font-medium  p-4'>
                  Address :
                  <span className='p-2'> {tax[0].employee.address}</span>
                </div>
              </div>
              <div className='w-[60%] flex justify-evenly gap-5 py-2 mb-20 mx-auto'>
                <button className='w-[100%] h-[45px] text-[16px] font-medium  flex justify-center items-center  p-4  rounded bg-blue-400 cursor-pointer '>
                  <Link to={'/admin/submissions'}>Back To Submissions</Link>
                </button>
                <button
                  onClick={handleAcceptButton}
                  className='w-[100%] h-[45px] text-[16px] font-medium  flex justify-center items-center  p-4  rounded bg-green-400 cursor-pointer '
                >
                  Accept
                </button>
                <button
                  onClick={handleRejectButton}
                  className='w-[100%] h-[45px] text-[16px] font-medium  flex justify-center items-center  p-4  rounded bg-red-400 cursor-pointer '
                >
                  Reject
                </button>
              </div>
            </form>
          </div>
        </section>
      ) : (
        <Loader />
      )}
    </>
  )
}

export default ViewTaxSubmission
