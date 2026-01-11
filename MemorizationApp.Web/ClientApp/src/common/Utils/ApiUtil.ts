import axios, { HttpStatusCode } from "axios";
import { IFormResponse, ResponseStatus } from "./RecitalApiTypes";

export enum AxiosMethod {
    GET = "get",
    POST = "post"
}

type SupportedEndpoints = "add" | "all" | "byid" | "compare";

export interface IApiProps<TPayload = any> {
    method: AxiosMethod;
    endpoint: SupportedEndpoints;
    payload?: TPayload;
}

export async function doApiRequest<T, TPayload = any>({ method, endpoint, payload }: IApiProps<TPayload>) {
    const url = `/api/recitals/${endpoint}`;
    let response;
    if (method === AxiosMethod.POST) {
        response = await axios.post(url, payload);
    } else {
        response = await axios.get(url, { params: payload });
    }

    if (response.status === HttpStatusCode.Ok && (response.data as IFormResponse).status === ResponseStatus.Success) {
        return (response.data as IFormResponse).data as T;
    } else {
        //trigger error toast
    }
};
