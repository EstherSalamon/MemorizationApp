import axios, { HttpStatusCode } from "axios";
import { IRecital } from "../../Pages/Home/HomePage";

export class RecitalStore {

    public static getAll() {
        const loadData = async () => {
            const { data } = await axios.get("/api/recitals/all");
            return data as IRecital[];
        }
        return loadData();
    }

    public static addRecital(recital: IRecital) {
        const doLoad = async () => {
            const response = await axios.post("/api/recitals/add", recital);
            return response.data as IAddRecitalResponse;
        };
        return doLoad();
    }

    public static async getById(id?: string) {
        if (!id) {
            return null;
        }
        const { data } = await axios.get(`/api/recitals/byid?id=${id}`);
        return data as IRecital;
    }

    public static async compareText(text: string, id: string) {
        const data = await axios.post("/api/recitals/test/knowledge", { RecitalId: id, CompareText: text });
        return {
            success: data.status === HttpStatusCode.Ok,
            response: data.data as ICheckTextResponse
        };
    }
}

export interface ICheckTextResponse {
    recitalText: string;
    compareText: string;
}

export interface IAddRecitalResponse {
    recitalId: number;
}

// TODO: add state, move types