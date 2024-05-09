import { createReducer } from '@reduxjs/toolkit'

export const taxReducer = createReducer(
  { taxes: {} },
  {
    getTaxDeclarationRequest: state => {
      state.loading = true
    },
    getTaxDeclarationSuccess: (state, action) => {
      state.loading = false
      state.tax = action.payload
    },
    getTaxDeclarationFail: (state, action) => {
      state.loading = false
      state.error = action.payload
    },
    getAllTaxDeclarationRequest: state => {
      state.loading = true
    },
    getAllTaxDeclarationSuccess: (state, action) => {
      state.loading = false
      state.taxes = action.payload
    },
    getAllTaxDeclarationFail: (state, action) => {
      state.loading = false
      state.error = action.payload
    },
    getMyTaxDeclarationRequest: state => {
      state.loading = true
    },
    getMyTaxDeclarationSuccess: (state, action) => {
      state.loading = false
      state.taxes = action.payload
    },
    getMyTaxDeclarationFail: (state, action) => {
      state.loading = false
      state.error = action.payload
    },
    getTaxChangeRequestListingRequest: state => {
      state.loading = true
    },
    getTaxChangeRequestListingSuccess: (state, action) => {
      state.loading = false
      state.changeRequests = action.payload
    },
    getTaxChangeRequestListingFail: (state, action) => {
      state.loading = false
      state.error = action.payload
    },
    createTaxDeclarationRequest: state => {
      state.loading = true
    },
    createTaxDeclarationSuccess: (state, action) => {
      state.loading = false
      state.message = action.payload
      state.tax = action.payload
    },
    createTaxDeclarationFail: (state, action) => {
      state.loading = false
      state.error = action.payload
    },
    updateTaxDeclarationRequest: state => {
      state.loading = true
    },
    updateTaxDeclarationSuccess: (state, action) => {
      state.loading = false
      state.message = action.payload
      state.tax = action.payload
    },
    updateTaxDeclarationFail: (state, action) => {
      state.loading = false
      state.error = action.payload
    },
    submitTaxDeclarationRequest: state => {
      state.loading = true
    },
    submitTaxDeclarationSuccess: (state, action) => {
      state.loading = false
      state.message = action.payload
    },
    submitTaxDeclarationFail: (state, action) => {
      state.loading = false
      state.error = action.payload
    },
    RequestForTaxDeclarationChangeRequest: state => {
      state.loading = true
    },
    RequestForTaxDeclarationChangeSuccess: (state, action) => {
      state.loading = false
      state.message = action.payload
    },
    RequestForTaxDeclarationChangeFail: (state, action) => {
      state.loading = false
      state.error = action.payload
    },
    unfreezeTaxFormRequest: state => {
      state.loading = true
    },
    unfreezeTaxFormSuccess: (state, action) => {
      state.loading = false
      state.message = action.payload
    },
    unfreezeTaxFormFail: (state, action) => {
      state.loading = false
      state.error = action.payload
    },

    acceptTaxDeclarationRequest: state => {
      state.loading = true
    },
    acceptTaxDeclarationSuccess: (state, action) => {
      state.loading = false
      state.message = action.payload
    },
    acceptTaxDeclarationFail: (state, action) => {
      state.loading = false
      state.error = action.payload
    },

    rejectTaxDeclarationRequest: state => {
      state.loading = true
    },
    rejectTaxDeclarationSuccess: (state, action) => {
      state.loading = false
      state.message = action.payload
    },
    rejectTaxDeclarationFail: (state, action) => {
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
