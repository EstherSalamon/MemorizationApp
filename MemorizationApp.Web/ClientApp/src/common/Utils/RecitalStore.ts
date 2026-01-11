import { IRecital } from "../../Pages/Home/HomePage";
import { IAddRecitalResponse, ICheckTextResponse, IGetAllRecitalsResponse, IGetByIdResponse } from "./RecitalApiTypes";
import { AxiosMethod, doApiRequest, IApiProps } from "./ApiUtil";

export class RecitalStore {

    public static async getAll() {
        const props: IApiProps = { method: AxiosMethod.GET, endpoint: "all" };
        return await doApiRequest<IGetAllRecitalsResponse>(props);
    }

    public static async addRecital(recital: IRecital) {
        const props: IApiProps<{ Recital: IRecital }> = { method: AxiosMethod.POST, endpoint: "add", payload: { Recital: recital } };
        return await doApiRequest<IAddRecitalResponse, { Recital: IRecital }>(props);
    }

    public static async getById(id?: string) {
        if (!id) {
            return null;
        }
        const props: IApiProps<{ RecitalId: string }> = { method: AxiosMethod.GET, endpoint: "byid", payload: { RecitalId: id } };
        return await doApiRequest<IGetByIdResponse, { RecitalId: string }>(props);
    }

    public static async compareText(text: string, id: string) {
        const props: IApiProps<{ RecitalId: string; CompareText: string }> = { method: AxiosMethod.POST, endpoint: "compare", payload: { RecitalId: id, CompareText: text } };
        return await doApiRequest<ICheckTextResponse, { RecitalId: string; CompareText: string }>(props)
    }
}
// TODO: add state?