import axios from 'axios'
import { server } from '../Store'

//LOGIN
export const loginUser = (employeeID, password, navigate) => async dispatch => {
  try {
    dispatch({
      type: 'loginRequest'
    })

    const config = { headers: { 'Content-Type': 'application/json' } }

    const { data } = await axios.post(
      `${server}/login`,
      { username: employeeID, password },
      config
    )

    dispatch({
      type: 'loginSuccess',
      payload: data
    })
    if (data.employee.role === 'admin') {
      navigate('/admin/home')
    } else if (data.employee.role === 'employee') {
      navigate('/home')
    } else {
      console.error('Unknown user role:', data.employee.role)
    }
    return data
  } catch (error) {
    dispatch({
      type: 'loginFail',
      payload: error.response.data.message
    })
  }
}

//LOGOUT
export const logout = () => async dispatch => {
  try {
    dispatch({
      type: 'logoutRequest'
    })

    const { data } = await axios.post(`${server}/logout`, {
      withCredentials: true
    })

    dispatch({ type: 'logoutSuccess', payload: data.message })
    return data
  } catch (error) {
    dispatch({ type: 'logoutFail', payload: error.reponse.data.message })
  }
}
