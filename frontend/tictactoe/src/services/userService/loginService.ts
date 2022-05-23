import axios from 'axios';
import LoginCredentials from '../../models/loginCredentials';

const loginUrl = "https://localhost:5001/api/Authenticate"

const loginUser = (credentials: LoginCredentials) => axios.post(loginUrl, credentials);

const loginService = {
    loginUser,   
}

export default loginService;