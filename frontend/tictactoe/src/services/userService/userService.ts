import axios from 'axios';
import UserRegister  from '../../models/userRegister';

const userUrl = "https://localhost:5001/api/User"

const registerUser = (user: UserRegister) => axios.post(userUrl, user);

const getUser = (id: number) => axios.get(`${userUrl}/${id}`);

const userSerivce = {
    registerUser,
    getUser
}

export default userSerivce;
