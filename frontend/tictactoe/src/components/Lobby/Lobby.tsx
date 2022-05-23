import React, { ChangeEvent, useState } from 'react'
import { useNavigate } from 'react-router-dom'
import roomService from '../../services/roomService/roomService'
import Button from '../shared/Button/Button'
import styles from './Lobby.module.css'

const Lobby = () => {
    const navigate = useNavigate()
    const [roomName, setRoomName] = useState<string>('')

    const createRoom = async (e: any) => {
        e.preventDefault()
        const newRoom = {
            name: roomName,
            firstPlayer: -1,
            secondPlayer: -1,
        }
        const response = await roomService.createRoom(newRoom)
        if(response.status === 200) {
            localStorage.setItem('roomId', response.data.id)
            navigate("/game")
        }
        else alert('Something went wrong')
    }

    const onChange = (event: ChangeEvent<HTMLInputElement>) => {
        setRoomName(event.target.value)
    }

    const joinRoom = async (e: any) => {
        e.preventDefault()
        const response = await roomService.getRoom(roomName)
        if(response.status === 200) {
            const room = {
                id: response.data.id,
                name: response.data.name,
                firstPlayer: response.data.firstPlayer,
                secondPlayer: -1,
            }
            if(await roomService.updateRoom(room) !== null){
                localStorage.setItem('roomId', room.id)
                const response = await roomService.deleteRoom(room.id)
                if(response.data === true)
                    navigate("/game")
            }
            else alert('Failed while updating room')
        }
        else alert('Wrong room name')
    }

  return (
    <>
        <div>
            <h1 className={styles.heading}>Lobby</h1>
        </div>
        <div className='container'>
            <div>
                <h2>Create room</h2>
                <form onSubmit = {createRoom}>
                    <label>
                        Room name:
                        <input type="text" name="roomName" onChange={onChange}/>
                    </label>
                    <Button btnType='submit' content='Confirm' btnStyle='warning'/>
                </form>
            </div>
            <div>
                <h2>Join room</h2>
                <form onSubmit = {joinRoom}>
                    <label>
                        Room name:
                        <input type="text" name="roomName" onChange={onChange}/>
                    </label>
                    <Button btnType='submit' content='Confirm' btnStyle='warning'/>
                </form>
            </div>
        </div>
    </>
  )
}

export default Lobby