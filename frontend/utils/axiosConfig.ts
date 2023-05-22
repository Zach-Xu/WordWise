import axios from "axios";

const customAxios = axios.create({
    baseURL: process.env.API_BASE_URL
})

export default customAxios

