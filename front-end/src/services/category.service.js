import { apiRequere } from "../helpers/client.helper";


const jwt = apiRequere.get("api/jwt");

export default {
    getAll() {
        return jwt.then(result => {
            const { data } = result
            return apiRequere.get("api/categories", {
                headers: {
                    'Authorization': `Bearer ${data.jwtPass}`
                }
            });
        });        
    }
}
