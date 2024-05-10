import axios from 'axios'
import { server } from '../Store'

// CREATE TAX FORM(SUBMISSION)
export const createTaxDeclaration = formData => async dispatch => {
  console.log(formData)
  try {
    dispatch({
      type: 'createTaxDeclarationRequest'
    })

    const config = {
      headers: { 'Content-Type': 'application/json' }
    }
    const { data } = await axios.post(
      `${server}/employee/taxform/submit`,
      formData,
      config
    )
    dispatch({
      type: 'createTaxDeclarationSuccess',
      payload: data
    })
    return data
  } catch (error) {
    dispatch({
      type: 'createTaxDeclarationFail',
      payload: error.response.data.message
    })
  }
}

// UPDATE TAX FORM
export const updateTaxDeclaration = (formData, taxId) => async dispatch => {
  console.log(formData)
  try {
    dispatch({
      type: 'updateTaxDeclarationRequest'
    })

    const config = {
      headers: { 'Content-Type': 'application/json' }
    }
    const { data } = await axios.put(
      `${server}/admin/tax/update/${taxId}`,
      formData,
      config
    )
    dispatch({
      type: 'updateTaxDeclarationSuccess',
      payload: data
    })
    return data
  } catch (error) {
    dispatch({
      type: 'updateTaxDeclarationFail',
      payload: error.response.data.message
    })
  }
}

// GET TAX DECLARATION BY TAXID
export const getTaxDeclaration = taxId => async dispatch => {
  try {
    dispatch({
      type: 'getTaxDeclarationRequest'
    })

    const { data } = await axios.get(`${server}/tax-submission/${taxId}`)
    dispatch({
      type: 'getTaxDeclarationSuccess',
      payload: data
    })
  } catch (error) {
    dispatch({
      type: 'getTaxDeclarationFail',
      payload: error.response.data.message
    })
  }
}

// GET ALL TAX DECLARATION SUBMISSIONS
export const getAllTaxDeclaration = () => async dispatch => {
  try {
    dispatch({
      type: 'getAllTaxDeclarationRequest'
    })

    const { data } = await axios.get(`${server}/admin/submissions`)
    dispatch({
      type: 'getAllTaxDeclarationSuccess',
      payload: data
    })
  } catch (error) {
    dispatch({
      type: 'getAllTaxDeclarationFail',
      payload: error.response.data.message
    })
  }
}

// GET ALL MY SUBMITTED TAX DECLARATION
export const getMyTaxDeclaration = empId => async dispatch => {
  try {
    dispatch({
      type: 'getMyTaxDeclarationRequest'
    })

    const { data } = await axios.get(`${server}/submissions/${empId}`)
    dispatch({
      type: 'getMyTaxDeclarationSuccess',
      payload: data
    })
  } catch (error) {
    dispatch({
      type: 'getMyTaxDeclarationFail',
      payload: error.response.data.message
    })
  }
}

// GET ALL TAX DECLARATION WITH CHANGE REQUEST
export const getTaxChangeRequestListing = () => async dispatch => {
  try {
    dispatch({
      type: 'getTaxChangeRequestListingRequest'
    })

    const { data } = await axios.get(`${server}/admin/taxes`)
    dispatch({
      type: 'getTaxChangeRequestListingSuccess',
      payload: data
    })
    console.log(data)
  } catch (error) {
    dispatch({
      type: 'getTaxChangeRequestListingFail',
      payload: error.response.data.message
    })
  }
}

// REQUEST FOR CHANGE
export const requestChange = formData => async dispatch => {
  try {
    dispatch({
      type: 'RequestForTaxDeclarationChangeRequest'
    })
    const config = {
      headers: { 'Content-Type': 'application/json' }
    }
    const { data } = await axios.post(
      `${server}/change-request`,
      formData,
      config
    )
    dispatch({
      type: 'RequestForTaxDeclarationChangeSuccess',
      payload: data
    })
    return data
  } catch (error) {
    dispatch({
      type: 'RequestForTaxDeclarationChangeFail',
      payload: error.response.data.message
    })
  }
}

// UNFREEZE TAX DECLARATION  --admin
export const unfreezeTaxForm = taxId => async dispatch => {
  try {
    dispatch({
      type: 'unfreezeTaxFormRequest'
    })

    console.log(taxId)
    const { data } = await axios.get(`${server}/admin/tax/unfreeze/${taxId}`)
    dispatch({
      type: 'unfreezeTaxFormSuccess',
      payload: data
    })
  } catch (error) {
    dispatch({
      type: 'unfreezeTaxFormFail',
      payload: error.response.data.message
    })
  }
}

// ACCEPTED SUBMITTED  TAX DECLARATION  --admin
export const acceptTaxDeclaration = taxId => async dispatch => {
  try {
    dispatch({
      type: 'acceptTaxDeclarationRequest'
    })

    const { data } = await axios.get(`${server}/admin/tax/accept/${taxId}`)
    dispatch({
      type: 'acceptTaxDeclarationSuccess',
      payload: data
    })
    return data
  } catch (error) {
    dispatch({
      type: 'acceptTaxDeclarationFail',
      payload: error.response.data.message
    })
  }
}

// REJECT SUBMITTED  TAX DECLARATION  --admin
export const rejectTaxDeclaration = taxId => async dispatch => {
  try {
    dispatch({
      type: 'rejectTaxDeclarationRequest'
    })

    const { data } = await axios.get(`${server}/admin/tax/reject/${taxId}`)
    dispatch({
      type: 'rejectTaxDeclarationSuccess',
      payload: data
    })
    return data
  } catch (error) {
    dispatch({
      type: 'rejectTaxDeclarationFail',
      payload: error.response.data.message
    })
  }
}
