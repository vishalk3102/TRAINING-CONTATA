import axios from 'axios'
import { server } from '../Store'

// ADD EMPLOYEE
export const addEmployee = formData => async dispatch => {
  try {
    dispatch({
      type: 'addEmployeeRequest'
    })

    const config = {
      headers: { 'Content-Type': 'application/json' }
    }
    const { data } = await axios.post(
      `${server}/admin/employee/add`,
      formData,
      config
    )
    dispatch({
      type: 'addEmployeeSuccess',
      payload: data
    })
    return data
  } catch (error) {
    dispatch({
      type: 'addEmployeeFail',
      payload: error.response.data.message
    })
  }
}

// UPDATE EMPLOYEE
export const updateEmployee = (formData, empId) => async dispatch => {
  try {
    dispatch({
      type: 'updateEmployeeRequest'
    })
    const config = {
      headers: { 'Content-Type': 'application/json' }
    }
    const { data } = await axios.put(
      `${server}/admin/employee/${empId}`,
      formData,
      config
    )
    dispatch({
      type: 'updateEmployeeSuccess',
      payload: data
    })
    return data
  } catch (error) {
    dispatch({
      type: 'updateEmployeeFail',
      payload: error.response.data.message
    })
  }
}

// DELETE EMPLOYEE
export const deleteEmployee = empId => async dispatch => {
  try {
    dispatch({
      type: 'deleteEmployeeRequest'
    })

    const { data } = await axios.delete(`${server}/admin/employee/${empId}`)
    dispatch({
      type: 'deleteEmployeeSuccess',
      payload: data
    })
    return data
  } catch (error) {
    dispatch({
      type: 'deleteEmployeeFail',
      payload: error.response.data.message
    })
  }
}

// GET EMPLOYEE  DETAILS
export const getEmployee = empId => async dispatch => {
  try {
    dispatch({
      type: 'getEmployeeRequest'
    })

    const { data } = await axios.get(`${server}/employee/${empId}`)
    dispatch({
      type: 'getEmployeeSuccess',
      payload: data
    })
  } catch (error) {
    dispatch({
      type: 'getEmployeeFail',
      payload: error.response.data.message
    })
  }
}

// GET ALL  EMPLOYEE DETAILS
export const getAllEmployee = () => async dispatch => {
  try {
    dispatch({
      type: 'getAllEmployeeRequest'
    })

    const { data } = await axios.get(`${server}/admin/employees`)
    dispatch({
      type: 'getAllEmployeeSuccess',
      payload: data
    })
  } catch (error) {
    dispatch({
      type: 'getAllEmployeeFail',
      payload: error.response.data.message
    })
  }
}
