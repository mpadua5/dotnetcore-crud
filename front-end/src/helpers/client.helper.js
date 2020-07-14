import axios from "axios";


const apiRequere = axios.create({
    baseURL: process.env.API_URL,
    headers: {
        "Content-Type" : "application/json"
    }
});


export {
    apiRequere
}