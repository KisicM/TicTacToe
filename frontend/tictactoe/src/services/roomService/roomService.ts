import axios from "axios";
import RoomDTO from "../../models/roomDto";

type Room = {
    id: number;
    name: string;
    firstPlayer: number;
    secondPlayer: number;
}

const roomUrl = "https://localhost:5001/api/PlayerRoom";

const createRoom = (roomDto: RoomDTO) => axios.post(roomUrl, roomDto);
const getRoom = (name: string) => axios.get(roomUrl + "/" + name);
const updateRoom = (room: Room) => axios.put(roomUrl, room);
const deleteRoom = (id: number) => axios.delete(roomUrl+ "/" + id);

const roomService = {
    createRoom,
    getRoom,
    updateRoom,
    deleteRoom
}

export default roomService;