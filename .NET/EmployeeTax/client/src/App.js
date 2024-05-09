import React from 'react'
import { Toaster } from 'react-hot-toast'
import { BrowserRouter, Route, Routes } from 'react-router-dom'
import { useSelector } from 'react-redux'
import { ProtectedRoute } from 'protected-route-react'

import Home from './Components/Home'
import Login from './Components/Login'
import Navbar from './Components/Navbar'
import Footer from './Components/Footer'

// ADMIN COMPONENT IMPORTS
import Employees from './Components/Admin/Employees'
import AddEmployee from './Components/Admin/AddEmployee'
import EditEmployee from './Components/Admin/EditEmployee'
import TaxListing from './Components/Admin/TaxListing'
import SubmissionListing from './Components/Admin/SubmissionList'
import ViewTaxSubmissionAdmin from './Components/Admin/ViewTaxSubmission'
import RequestChange from './Components/Employee/RequestChange'

// EMPLOYEE COMPONENT IMPORTS
import TaxForm from './Components/Employee/TaxForm'
import PreviousSubmission from './Components/Employee/PreviousSubmission'
import ViewTaxSubmission from './Components/Employee/ViewTaxSubmission'

const App = () => {
  const { user, isAuthenticated } = useSelector(state => state.auth)
  return (
    <>
      <BrowserRouter>
        <Navbar isAuthenticated={isAuthenticated} role={user.role} />

        <Routes>
          <Route exact path='/' element={<Login />} />

          {/* ADMIN ROUTING  */}
          <Route
            element={
              <ProtectedRoute
                isAuthenticated={isAuthenticated}
                adminroute={true}
                isAdmin={user && user.role === 'admin'}
                redirect='/'
              />
            }
          >
            <Route exact path='/admin/home' element={<Home />} />
            <Route exact path='/admin/taxes' element={<TaxListing />} />
            <Route
              exact
              path='/admin/:taxId'
              element={<ViewTaxSubmissionAdmin />}
            />
            <Route
              exact
              path='/admin/submissions'
              element={<SubmissionListing />}
            />
            <Route exact path='/admin/employees' element={<Employees />} />
            <Route exact path='/admin/employee/add' element={<AddEmployee />} />
            <Route
              exact
              path='/admin/employee/:empId'
              element={<EditEmployee />}
            />
          </Route>

          {/* EMPLOYEE ROUTING  */}
          <Route
            element={
              <ProtectedRoute isAuthenticated={isAuthenticated} redirect='/' />
            }
          >
            <Route exact path='/home' element={<Home />} />
            <Route exact path='/taxform' element={<TaxForm />} />
            <Route exact path='/submissions' element={<PreviousSubmission />} />
            <Route
              exact
              path='/submission/:taxId'
              element={<ViewTaxSubmission />}
            />

            <Route
              exact
              path='/change-request/:taxId'
              element={<RequestChange />}
            />
          </Route>
        </Routes>
        <Footer />
        <Toaster />
      </BrowserRouter>
    </>
  )
}

export default App
