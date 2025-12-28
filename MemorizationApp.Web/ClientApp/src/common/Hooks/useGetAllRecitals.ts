import { useEffect, useState } from "react";
import { RecitalStore } from "../Utils/RecitalStore";
import { IRecital } from "../../Pages/Home/HomePage";

export function useGetAllRecitals() {

    const [recitals, setRecitals] = useState<IRecital[] | null>(null);

    useEffect(() => {
        const preloadData = async () => {
            const data = await RecitalStore.getAll();
            setRecitals(data);
        }
        preloadData();

    }, [])

    return recitals;
}