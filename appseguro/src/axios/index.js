import axios from 'axios'

const http = axios.create({
    baseURL: 'http://localhost:52378/api/',
    headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json'
    }
})

export default http