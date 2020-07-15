import axios from "axios";


export const apiRequere = axios.create({
    baseURL: `http://${process.env.VUE_APP_API_URL}`,
    headers: {
        "Content-Type" : "application/json"
    }
});