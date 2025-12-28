import { FunctionComponent } from "react";
import { Header } from "../../common/UI/Header/Header";
import { useGetAllRecitals } from "../../common/Hooks/useGetAllRecitals";
import { RecitalsList } from "../../common/Components/RecitalsList/RecitalsList";

import styles from "./homePage.module.scss";

export interface IRecital {
    id: number;
    text: string;
    title: string;
    description: string;
}

export const HomePage: FunctionComponent = () => {

    const recitals = useGetAllRecitals();

    return (
        <div className={styles.container}>
            <Header>Current Recitals</Header>
            <a href="/rec/add" className={styles.link}>New Recital</a>
            <RecitalsList recitals={recitals} />
        </div>
    )
}