import { FunctionComponent } from "react";
import { IRecital } from "../../Home/HomePage";
import { Loader } from "../../../common/UI/Loader/Loader";
import { Header } from "../../../common/UI/Header/Header";
import { ICheckTextResponse } from "../../../common/Utils/RecitalApiTypes";

import styles from "./markView.module.scss";

interface IRecitalResponseProps {
    recital: IRecital;
    response: ICheckTextResponse | null;
}

export const MarkView: FunctionComponent<IRecitalResponseProps> = ({ recital, response }) => {

    if (!response) {
        return <Loader />;
    }

    return (
        <>
            <Header>{recital.title}</Header>
            <div className={styles.container}>
                <div className={styles.wrapper}>
                    <h5>Original Recital</h5>
                    <div className={styles.recitalText} dangerouslySetInnerHTML={{ __html: response.recitalText }} />
                </div>
                <div className={styles.wrapper}>
                    <h5>Your Text</h5>
                    <div className={styles.compareText} dangerouslySetInnerHTML={{ __html: response.compareText }} />
                </div>
            </div>
        </>
    )
}