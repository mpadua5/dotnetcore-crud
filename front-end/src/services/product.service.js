import { apiRequere } from "../helpers/client.helper";


const jwt = apiRequere.get("api/jwt");

export default {
    getAll() {
        return jwt.then(result => {
            const { data } = result
            return apiRequere.get("api/products", {
                headers: {
                    'Authorization': `Bearer ${data.jwtPass}`
                }
            });
        });
    },
    post(obj) {
        return jwt.then(result => {
            const { data } = result
            return apiRequere.post("api/product",
                obj,
                {
                    headers: {
                        'Authorization': `Bearer ${data.jwtPass}`
                    }
                });
        });
    },
    put(obj) {
        return jwt.then(result => {
            const { data } = result
            return apiRequere.put("api/product",
                obj,
                {
                    headers: {
                        'Authorization': `Bearer ${data.jwtPass}`
                    }
                });
        });
    },
    delete(guid) {
        return jwt.then(result => {
            const { data } = result
            return apiRequere.delete(`api/product/${guid}`,
                {
                    headers: {
                        'Authorization': `Bearer ${data.jwtPass}`
                    }
                });
        });
    }
}
