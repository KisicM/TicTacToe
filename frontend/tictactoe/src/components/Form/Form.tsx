import { ChangeEvent, useState } from 'react';
import InputType from '../../helpers/formConfigurations/inputType';
import LoginCredentials from '../../models/loginCredentials';
import UserRegister from '../../models/userRegister';
import Button from '../shared/Button/Button';
import styles from './Form.module.css';

type FormProps = {
    inputs: InputType[],
    formTitle: string,
    onSubmit: ((user: UserRegister) => Promise<void>) | ((credentials: LoginCredentials) => Promise<void>),
}

const Form = ({inputs, formTitle, onSubmit}: FormProps): JSX.Element => {
    const createInitalState = () => {
        const initialState: any = {}
        inputs.forEach(input => {
            initialState[input.name] = ''
        })
        return initialState
    }
    const [state, setState] = useState(createInitalState())

    const onChange = (event: ChangeEvent<HTMLInputElement>) => {
        setState({...state, [event.target.name]: event.target.value});
    }

    const handleSubmit = async (e: any) => {
        onSubmit(state)
        e.preventDefault()
    }
  return (
    <div className={styles.shape}>
        <h1>{formTitle}</h1>
        <hr></hr>
        <form onSubmit={handleSubmit}>
            <div className='board'>
                {inputs.map((inputObject) => {
                    return (
                        <div key={inputObject.name}>      
                            <label>{`${inputObject.labelText}: `}</label>              
                            <input className={styles.input} type={inputObject.type} name={inputObject.name} onChange={onChange}/>
                        </div>
                    )
                })}       
                <Button btnType='submit' content={formTitle} btnStyle='primary' onSubmit = {handleSubmit}/>
            </div>
        </form>
    </div>
  );
}

export default Form
