import React, { useEffect, useState } from 'react'
import { useDispatch, useSelector } from 'react-redux'
import { useNavigate } from 'react-router-dom'
import toast from 'react-hot-toast'
import {
  getMyTaxDeclaration,
  saveTaxDeclaration,
  submitTaxDeclaration
} from '../../Redux/Actions/TaxAction'

const TaxForm = () => {
  // STATE VARIABLES FOR FORM INPUT
  const [anyOtherIncome, setAnyOtherIncome] = useState(0)
  const [sukanyaSamriddhiAccount, setSukanyaSamruddhiAccount] = useState(0)
  const [ppf, setPpf] = useState(0)
  const [lic, setLic] = useState(0)
  const [tuitionFee, setTuitionFee] = useState(0)
  const [fixedDeposit, setFixedDeposit] = useState(0)
  const [interestHousingLoan, setInterestHousingLoan] = useState(0)
  const [nps, setNps] = useState(0)
  const [educationLoan, setEducationLoan] = useState(0)
  const [principalHousingLoan, setPrincipalHousingLoan] = useState(0)
  const [houseRent, setHouseRent] = useState(0)
  const [tds, setTds] = useState(0)
  const [healthInsurance, setHealthInsurance] = useState(0)
  const [preventiveHealthCheckup, setPreventiveHealthCheckup] = useState(0)
  const [ltaChecked, setLtaChecked] = useState(false)
  const [financialYear, setFinancialYear] = useState()

  // STATE VARIABLES FOR FORM
  const [taxFormActive, setTaxFormActive] = useState(false)
  const [isSubmitted, setIsSubmitted] = useState(false)
  const [nextButtonStatus, setNextButtonStatus] = useState(false)

  // FETCHING VALUES FROM STORE
  const { user } = useSelector(state => state.auth)
  const { mytaxes } = useSelector(state => state.tax)

  const dispatch = useDispatch()
  const navigate = useNavigate()

  const currentDate = new Date()
  const currentDateString = currentDate.toISOString().split('T')[0]

  useEffect(() => {
    dispatch(getMyTaxDeclaration(user.empId))
  }, [dispatch])

  useEffect(() => {
    // --Check if taxes exist--
    if (mytaxes) {
      // --Check if taxes exist for the current financial year--
      const existingTax = mytaxes.find(
        tax => tax.financialYear === financialYear
      )
      if (existingTax) {
        setAnyOtherIncome(existingTax.anyOtherIncome)
        setSukanyaSamruddhiAccount(existingTax.sukanyaSamriddhiAccount)
        setPpf(existingTax.ppf)
        setLic(existingTax.lifeInsurancePremium)
        setTuitionFee(existingTax.tuitionFee)
        setFixedDeposit(existingTax.bankFixedDeposit)
        setInterestHousingLoan(existingTax.interestHousingLoan)
        setNps(existingTax.nps)
        setEducationLoan(existingTax.higherEducationLoanInterest)
        setPrincipalHousingLoan(existingTax.principalHousingLoan)
        setHouseRent(existingTax.houseRent)
        setTds(existingTax.tds)
        setHealthInsurance(existingTax.mediClaim)
        setPreventiveHealthCheckup(existingTax.preventiveHealthCheckUp)
        setLtaChecked(existingTax.ltaChecked)
      }
    }
  }, [financialYear, mytaxes])

  // FUNCTION TO HANDLE NEXT BUTTON
  const handleNextButton = () => {
    setTaxFormActive(true)
  }

  // FUNCTION TO HANDLE FINANCIAL YEAR CHANGE
  const handleFinancialYearChange = e => {
    setFinancialYear(parseInt(e.target.value))
  }
  // FUNCTION TO HANDLE CHECKBOX  CHANGE
  const handleLtaCheckboxChange = e => {
    setLtaChecked(e.target.checked)
  }

  // FUNCTION TO HANDLE SAVE BUTTON
  const handleSaveButton = () => {
    // --Logic to avoid resubmission of tax form--
    const existingTax = mytaxes.find(tax => tax.financialYear === financialYear)

    if (
      existingTax &&
      (existingTax.status === 'submitted' ||
        existingTax.status === 'accepted' ||
        existingTax.status === 'drafted')
    ) {
      toast.error(
        'Tax form already submitted or Saved  for this financial year.'
      )
      return
    }
    const formData = {
      empId: user.empId,
      financialYear: financialYear,
      anyOtherIncome,
      sukanyaSamriddhiAccount,
      PPF: ppf,
      lifeInsurancePremium: lic,
      tuitionFee,
      bankFixedDeposit: fixedDeposit,
      principalHousingLoan,
      NPS: nps,
      higherEducationLoanInterest: educationLoan,
      interestHousingLoan,
      houseRent,
      TDS: tds,
      mediClaim: healthInsurance,
      preventiveHealthCheckup,
      LTA: ltaChecked,
      dateOfDeclaration: currentDateString
    }
    dispatch(saveTaxDeclaration(formData))
      .then(response => {
        if (response) {
          toast.success('Form Saved successfully')
          navigate('/submissions')
        } else {
          toast.error('Failed to Save form')
        }
      })
      .catch(err => {
        toast.error(JSON.stringify(err))
      })
  }

  // FUNCTION TO HANDLE FORM SUBMISSION
  const handleSubmitButton = e => {
    e.preventDefault()
    // --Check if taxes exist for the current financial year--
    const existingTax = mytaxes.find(tax => tax.financialYear === financialYear)

    // --Logic to avoid resubmission of tax form--
    if (
      existingTax &&
      (existingTax.status === 'submitted' || existingTax.status === 'accepted')
    ) {
      toast.error('Tax form already submitted for this financial year.')
      return
    }

    const formData = {
      empId: user.empId,
      financialYear: financialYear,
      anyOtherIncome,
      sukanyaSamriddhiAccount,
      PPF: ppf,
      lifeInsurancePremium: lic,
      tuitionFee,
      bankFixedDeposit: fixedDeposit,
      principalHousingLoan,
      NPS: nps,
      higherEducationLoanInterest: educationLoan,
      interestHousingLoan,
      houseRent,
      TDS: tds,
      mediClaim: healthInsurance,
      preventiveHealthCheckup,
      LTA: ltaChecked,
      dateOfDeclaration: currentDateString
    }

    dispatch(submitTaxDeclaration(formData))
      .then(response => {
        if (response) {
          toast.success('Form Submitted successfully')
          navigate('/submissions')
        } else {
          toast.error('Failed to Submit form')
        }
      })
      .catch(err => {
        toast.error('Failed to Submit form')
      })
  }

  // LOGIC TO RESTRICT NAVIGATING TO TAX FORM IF FORM IS ALREADY SUBMITTED OR SAVED
  useEffect(() => {
    if (financialYear !== undefined) {
      const existingTax = mytaxes.find(
        tax => tax.financialYear === financialYear
      )
      if (existingTax) {
        toast.error('Form Already Submitted/Drafted for this financial Year')
        setNextButtonStatus(true)
        return
      } else {
        setNextButtonStatus(false)
      }
    }
  }, [financialYear, mytaxes])

  return (
    <section className='w-full h-full mb-20'>
      <div className='max-w-[1200px] mx-auto  my-2'>
        <div className='text-[1.8rem] font-medium text-center p-2 my-2'>
          <h1>Tax Declaration</h1>
        </div>
        {!taxFormActive ? (
          <div className='w-[60%] mx-auto flex flex-col justify-center my-10 '>
            {' '}
            <div className='w-[100%]'>
              <label htmlFor='financial-year' className='leading-7 text-sm '>
                Financial Year
              </label>
              <select
                id='financial-year'
                className='w-full h-[40px] text-[14px] bg-blue-50 outline-none py-1 px-3 mt-1 '
                value={financialYear}
                onChange={handleFinancialYearChange}
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
            <div className='w-[100%] flex  justify-center items-center mt-5 '>
              {' '}
              <button
                type='submit'
                className='bg-blue-500 px-6  py-3 rounded  text-white'
                onClick={handleNextButton}
                disabled={nextButtonStatus}
              >
                Next
              </button>
            </div>
          </div>
        ) : (
          ''
        )}

        {taxFormActive ? (
          <>
            <div className='flex justify-between items-center my-2 border-2 border-solid border-black py-2'>
              <div className='text-[16px] font-medium  p-4'>
                Employee ID :<span className='p-2'> {user.empId}</span>
              </div>
              <div className='text-[16px] font-medium  p-4'>
                Employee Name :<span className='p-2'> {user.name}</span>
              </div>
              <div className='text-[16px] font-medium  p-4'>
                Financial Year :<span className='p-2'> {financialYear}</span>
              </div>
            </div>
            <div className='border-solid border-2 border-black'>
              <div className='flex items-center  py-2 ml-2'>
                <div className='w-[70%] py-1'>
                  <label htmlFor='income' className='text-[14px]'>
                    1.) Any other income (interest from property, rental income,
                    etc.)
                  </label>
                </div>
                <div className='w-[25%]'>
                  <input
                    type='number'
                    name='income'
                    id='income'
                    placeholder='0'
                    className='w-[100%]  border-solid border-2 border-black px-2 py-1 text-[14px] outline-none'
                    value={anyOtherIncome}
                    onChange={e => setAnyOtherIncome(e.target.value)}
                    disabled={isSubmitted}
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
                        type='number'
                        name='ssa'
                        id='ssa'
                        placeholder='0'
                        className='w-[100%]  border-solid border-2 border-black px-2 py-1 text-[14px] outline-none'
                        value={sukanyaSamriddhiAccount}
                        onChange={e =>
                          setSukanyaSamruddhiAccount(e.target.value)
                        }
                        disabled={isSubmitted}
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
                        type='number'
                        name='ppf'
                        id='ppf'
                        placeholder='0'
                        className='w-[100%]  border-solid border-2 border-black px-2 py-1 text-[14px] outline-none'
                        value={ppf}
                        onChange={e => setPpf(e.target.value)}
                        disabled={isSubmitted}
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
                        type='number'
                        name='lic'
                        id='lic'
                        placeholder='0'
                        className='w-[100%]  border-solid border-2 border-black px-2 py-1 text-[14px] outline-none'
                        value={lic}
                        onChange={e => setLic(e.target.value)}
                        disabled={isSubmitted}
                      />
                    </div>
                  </div>
                  <div className='flex  w-[100%]'>
                    <div className='w-[70%] py-1'>
                      <label htmlFor='tuitionfee' className='text-[14px] py-2'>
                        c.) Tuition fee for child
                      </label>
                    </div>
                    <div className='w-[25%] my-1'>
                      <input
                        type='number'
                        name='tuitionfee'
                        id='tuitionfee'
                        placeholder='0'
                        className='w-[100%]  border-solid border-2 border-black px-2 py-1 text-[14px] outline-none'
                        value={tuitionFee}
                        onChange={e => setTuitionFee(e.target.value)}
                        disabled={isSubmitted}
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
                        type='number'
                        name='fixed-deposit'
                        id='fixed-deposit'
                        placeholder='0'
                        className='w-[100%]  border-solid border-2 border-black px-2 py-1 text-[14px] outline-none'
                        value={fixedDeposit}
                        onChange={e => setFixedDeposit(e.target.value)}
                        disabled={isSubmitted}
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
                        type='number'
                        name='housing'
                        id='housing'
                        placeholder='0'
                        className='w-[100%]  border-solid border-2 border-black px-2 py-1 text-[14px] outline-none'
                        value={principalHousingLoan}
                        onChange={e => setPrincipalHousingLoan(e.target.value)}
                        disabled={isSubmitted}
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
                        type='number'
                        name='NPS'
                        id='NPS'
                        placeholder='0'
                        className='w-[100%]  border-solid border-2 border-black px-2 py-1 text-[14px] outline-none'
                        value={nps}
                        onChange={e => setNps(e.target.value)}
                        disabled={isSubmitted}
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
                    type='number'
                    name='health'
                    id='health'
                    placeholder='0'
                    className='w-[100%]  border-solid border-2 border-black px-2 py-1 text-[14px] outline-none'
                    value={educationLoan}
                    onChange={e => setEducationLoan(e.target.value)}
                    disabled={isSubmitted}
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
                    type='number'
                    name='housing-loan'
                    id='housing-loan'
                    placeholder='0'
                    className='w-[100%]  border-solid border-2 border-black px-2 py-1 text-[14px] outline-none'
                    value={interestHousingLoan}
                    onChange={e => setInterestHousingLoan(e.target.value)}
                    disabled={isSubmitted}
                  />
                </div>
              </div>
              <div className='flex items-center  py-2 ml-2'>
                <div className='w-[70%] py-1'>
                  <label htmlFor='house-rent' className='text-[14px] py-2'>
                    5.) House Rent paid (every month/For above amt Rs 8333/-PM)
                    (part of amount liable to provide)
                  </label>
                </div>
                <div className='w-[25%]'>
                  <input
                    type='number'
                    name='house-rent'
                    id='house-rent'
                    placeholder='0'
                    className='w-[100%] border-solid border-2 border-black  px-2 py-1 text-[14px] outline-none'
                    value={houseRent}
                    onChange={e => setHouseRent(e.target.value)}
                    disabled={isSubmitted}
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
                    type='number'
                    name='TDS'
                    id='TDS'
                    placeholder='0'
                    className='w-[100%]  border-solid border-2 border-black px-2 py-1 text-[14px] outline-none'
                    value={tds}
                    onChange={e => setTds(e.target.value)}
                    disabled={isSubmitted}
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
                    type='number'
                    name='health-insurance'
                    id='health-insurance'
                    placeholder='0'
                    className='w-[100%]  border-solid border-2 border-black px-2 py-1 text-[14px] outline-none'
                    value={healthInsurance}
                    onChange={e => setHealthInsurance(e.target.value)}
                    disabled={isSubmitted}
                  />
                </div>
              </div>
              <div className='flex items-center  py-2 ml-2'>
                <div className='w-[70%] py-1'>
                  <label htmlFor='health' className='text-[14px] py-2'>
                    8.)Preventive Health check-up for Self & Family (80D) (Limit
                    5k)
                  </label>
                </div>
                <div className='w-[25%] py-1'>
                  <input
                    type='number'
                    name='health'
                    id='health'
                    placeholder='0'
                    className='w-[100%]  border-solid border-2 border-black px-2  text-[14px] outline-none'
                    value={preventiveHealthCheckup}
                    onChange={e => setPreventiveHealthCheckup(e.target.value)}
                    disabled={isSubmitted}
                  />
                </div>
              </div>
            </div>

            <div className='mt-4'>
              <div className='text-[1.4rem] font-medium text-left py-2 mt-2'>
                <h1>Reimbursement Component</h1>
              </div>
              <div className='flex flex-col   py-4 border-2 border-solid border-black'>
                <div className='flex py-1'>
                  {' '}
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
                      checked={ltaChecked}
                      onChange={handleLtaCheckboxChange}
                      disabled={isSubmitted}
                    />
                  </div>
                </div>
                <div className='flex py-1'>
                  {' '}
                  <div className='w-[70%]'>
                    <label htmlFor='LTA' className='leading-7 text-sm p-2'>
                      Education Allowance(Do you want education allowance as a
                      Reimbursement)
                    </label>
                  </div>
                  <div className='flex justify-center items-center'>
                    <input
                      type='checkbox'
                      name='EA'
                      id='EA'
                      className='h-[20px] w-[20px]'
                      checked={ltaChecked}
                      onChange={handleLtaCheckboxChange}
                      disabled={isSubmitted}
                    />
                  </div>
                </div>
              </div>
            </div>
            <div className='flex justify-between my-2 '>
              <div className='text-[16px] font-medium  p-4'>
                Staff No :<span className='p-2'> {user.empId}</span>
              </div>
              <div className='text-[16px] font-medium  p-4'>
                Name of the Staff :<span className='p-2'> {user.name}</span>
              </div>
              <div className='text-[16px] font-medium  p-4'>
                PAN No :<span className='p-2'> {user.panNo}</span>
              </div>

              <div className='text-[16px] font-medium  p-4'>
                Address :<span className='p-2'> {user.address}</span>
              </div>
            </div>
            <div className='flex justify-end gap-5 py-2'>
              <button
                className='w-[100%] h-[45px] text-[16px] font-medium  flex justify-center items-center  p-4  rounded bg-green-400 cursor-pointer
          '
                onClick={handleSaveButton}
              >
                Save
              </button>
              <button
                type='submit'
                className='w-[100%] h-[45px] text-[16px] font-medium  flex justify-center items-center  p-4  rounded bg-green-400 cursor-pointer'
                onClick={handleSubmitButton}
              >
                Submit
              </button>
            </div>
          </>
        ) : (
          ''
        )}
      </div>
    </section>
  )
}

export default TaxForm
