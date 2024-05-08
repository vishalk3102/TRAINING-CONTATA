import { createReducer } from '@reduxjs/toolkit'

export const employeeReducer = createReducer(
  { employees: {} },
  {
    getEmployeeRequest: state => {
      state.loading = true
    },
    getEmployeeSuccess: (state, action) => {
      state.loading = false
      state.employee = action.payload
    },
    getEmployeeFail: (state, action) => {
      state.loading = false
      state.error = action.payload
    },
    getAllEmployeeRequest: state => {
      state.loading = true
    },
    getAllEmployeeSuccess: (state, action) => {
      state.loading = false
      state.employees = action.payload
    },
    getAllEmployeeFail: (state, action) => {
      state.loading = false
      state.error = action.payload
    },
    addEmployeeRequest: state => {
      state.loading = true
    },
    addEmployeeSuccess: (state, action) => {
      state.loading = false
      state.employee = action.payload
    },
    addEmployeeFail: (state, action) => {
      state.loading = false
      state.error = action.payload
    },
    updateEmployeeRequest: state => {
      state.loading = true
    },
    updateEmployeeSuccess: (state, action) => {
      state.loading = false
      state.message = action.payload
    },
    updateEmployeeFail: (state, action) => {
      state.loading = false
      state.error = action.payload
    },
    deleteEmployeeRequest: state => {
      state.loading = true
    },
    deleteEmployeeSuccess: (state, action) => {
      state.loading = false
      state.message = action.payload
    },
    deleteEmployeeFail: (state, action) => {
      state.loading = false
      state.error = action.payload
    },
    clearError: state => {
      state.error = null
    },
    clearMessage: state => {
      state.message = null
    }
  }
)
