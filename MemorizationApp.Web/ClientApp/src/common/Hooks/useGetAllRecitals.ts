import { useEffect, useState } from "react";
import { RecitalStore } from "../Utils/RecitalStore";
import { IRecital } from "../../Pages/Home/HomePage";

export function useGetAllRecitals() {

    const [recitals, setRecitals] = useState<IRecital[] | null>(null);

    useEffect(() => {

        RecitalStore.getAll().then(response => {
            if (response) {
                setRecitals(response.recitals);
            }
        })

    }, [])

    return recitals;
}