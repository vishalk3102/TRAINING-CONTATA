import { configureStore } from '@reduxjs/toolkit'
import { authReducer } from '../Redux/Reducers/UserReducer'

import { employeeReducer } from './Reducers/EmployeeReducer'
import { taxReducer } from './Reducers/TaxReducer'

const store = configureStore({
  reducer: {
    auth: authReducer,
    employee: employeeReducer,
    tax: taxReducer
  }
})

export default store

export const server = 'http://localhost:5056/api/v1'
