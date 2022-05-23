import React from 'react'
import { Link } from 'react-router-dom'
import Button from '../shared/Button/Button'
import styles from './HomePage.module.css'

const HomePage = () => {
  return (
    <div className='col'>
      <h1 className={styles.heading}>Select Game Mode</h1>
      <Link to={"/lobby"} >
        <Button btnStyle='friend' btnType='button' content='vs Friend'></Button>
      </Link>
      <Link to={"/lobby"} >
        <Button btnStyle='others' btnType='button' content='vs Others'></Button>
      </Link>
      <Button btnStyle='ai' btnType='button' content='vs AI'></Button>
    </div>
  )
}

export default HomePage