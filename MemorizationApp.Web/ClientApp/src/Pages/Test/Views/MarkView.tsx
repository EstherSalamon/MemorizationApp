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
                    <div className={styles.recitalText}>
                        {response.recitalText.map(({ text, isDiff }) => <span className={isDiff ? styles.diff : ""}>{text}</span>)}
                    </div>
                </div>
                <div className={styles.wrapper}>
                    <h5>Your Text</h5>
                    <div className={styles.compareText}>
                        {response.compareText.map(({ text, isDiff }) => <span className={isDiff ? styles.diff : ""}>{text}</span>)}
                    </div>
                </div>
            </div>
        </>
    )
}