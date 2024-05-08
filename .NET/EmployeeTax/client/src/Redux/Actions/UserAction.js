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
      { empId: employeeID, password },
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
<<<<<<< HEAD
    return data
  } catch (error) {
    dispatch({
      type: 'loginFail',
      payload: error.response.data.title
=======
  } catch (error) {
    dispatch({
      type: 'loginFail',
      payload: error.response.data.message
>>>>>>> 361510a1352e924016f9b4efe1c28c6ee59d6159
    })
  }
}

//LOGOUT
export const logout = () => async dispatch => {
  try {
    dispatch({
      type: 'logoutRequest'
    })

<<<<<<< HEAD
    const { data } = await axios.get(`${server}/`, {
      withCredentials: true
    })

    dispatch({ type: 'logoutSuccess', payload: data })
    return data
=======
    const { data } = await axios.get(`${server}/logout`, {
      withCredentials: true
    })

    dispatch({ type: 'logoutSuccess', payload: data.message })
    if (data.success) {
    }
>>>>>>> 361510a1352e924016f9b4efe1c28c6ee59d6159
  } catch (error) {
    dispatch({ type: 'logoutFail', payload: error.reponse.data.message })
  }
}
