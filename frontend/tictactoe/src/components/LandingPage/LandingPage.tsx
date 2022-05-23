import React, { useState } from 'react'
import { useNavigate } from 'react-router-dom'
import loginFormInputs from '../../helpers/formConfigurations/loginForm/loginForm'
import registerFormInputs from '../../helpers/formConfigurations/registerForm/registerForm'
import LoginCredentials from '../../models/loginCredentials'
import UserRegister from '../../models/userRegister'
import loginService from '../../services/userService/loginService'
import userSerivce from '../../services/userService/userService'
import Form from '../Form/Form'
import Button from '../shared/Button/Button'
import styles from './LandingPage.module.css'

const LandingPage = (): JSX.Element => {
    const [isRegisterForm, setRegisterForm] = useState<boolean>(false)
    const navigate = useNavigate()
    const changeForm = (): void => {
        setRegisterForm(!isRegisterForm)
    }

    const register = async (user: UserRegister) => {
        const response = await userSerivce.registerUser(user)
        if(response.status === 200) changeForm()
        else alert('Something went wrong')
    }  

    const login = async (credentials: LoginCredentials) => {
        const response = await loginService.loginUser(credentials)
        if(response.status === 200) {
            localStorage.setItem('token', response.data.token)
            navigate('/home')
        }
        else alert('Something went wrong')
    } 

    const renderForm = (): JSX.Element => {
        return (isRegisterForm ? 
                <Form inputs={registerFormInputs} formTitle="Sign up" onSubmit={register} />
                : <Form inputs={loginFormInputs} formTitle="Sign in" onSubmit={login} />)
            }

  return (
    <div>
        <div>
            <h1 className={styles.heading}>Welcome to my <strong className={styles.tictactoe}>Tic-Tac-Toe</strong></h1>
            <hr></hr>
        </div>
        <div className='container'>
            <div className='col'>
                <h1>
                    Play <strong className={styles.tictactoe}>Tic-Tac-Toe</strong> with your friends <br></br> and others around the world.
                </h1>
                <Button btnType='button' btnStyle='secondary' content={isRegisterForm ? 'Sign in' : 'Sign up'} onClick={changeForm} />
                <Button btnType='button' btnStyle='warning' content='Play as a guest' onClick={function (): void {
                      throw new Error('Function not implemented.')
                  } } />
            </div>
            <div>
                {renderForm()}
            </div>
        </div>
    </div>
  )
}

export default LandingPage