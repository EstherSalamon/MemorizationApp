import { IRecital } from "../../Pages/Home/HomePage";

export enum ResponseStatus {
    Success,
    Error,
}

export interface IFormResponse {
    status: ResponseStatus;
    message: string;
    data: IApiResponseType;
}

type IApiResponseType = ICheckTextResponse | IAddRecitalResponse;

export interface IGetAllRecitalsResponse {
    recitals: IRecital[];
}

export interface IAddRecitalResponse {
    recitalId: number;
}

export interface IGetByIdResponse {
    recital: IRecital;
}

export interface ICheckTextResponse {
    recitalText: string;
    compareText: string;
}
