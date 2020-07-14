import { apiRequere } from "../helpers/client.helper";

export default {
    getAll() {
        return apiRequere.get("/products");
    }
}
