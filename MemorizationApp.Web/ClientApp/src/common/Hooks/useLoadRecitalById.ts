import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { RecitalStore } from "../Utils/RecitalStore";
import { IRecital } from "../../Pages/Home/HomePage";

export function useLoadRecitalById(callbackIfNull?: () => void) {
    const { id } = useParams();
    const [recital, setRecital] = useState<IRecital | null>(null);

    useEffect(() => {

        const preloadData = async () => {
            if (!id) {
                callbackIfNull?.();
            } else {
                RecitalStore.getById(id).then(response => {
                    if (response) {
                        setRecital(response.recital);
                    }
                });
            }

        }
        preloadData();

    }, []);

    return recital;
}