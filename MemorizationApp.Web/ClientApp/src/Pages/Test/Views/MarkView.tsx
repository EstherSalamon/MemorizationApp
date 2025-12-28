import { FunctionComponent } from "react";
import { IRecital } from "../../Home/HomePage";
import { ICheckTextResponse } from "../../../common/Utils/RecitalStore";
import { Loader } from "../../../common/UI/Loader/Loader";
import { Header } from "../../../common/UI/Header/Header";

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
            <div className={styles.wrapper}>
                <div className={styles.originalText} dangerouslySetInnerHTML={{ __html: response.originalText }} />
                <div className={styles.yourText} dangerouslySetInnerHTML={{ __html: response.finalText }} />
            </div>
        </>
    )
}