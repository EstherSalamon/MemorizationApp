import { FunctionComponent } from "react";
import { IRecital } from "../HomePage";
import { NavigateToView } from "../../../common/Utils/NavigationUtil";

import styles from "./recitalCard.module.scss";

interface IRecitalCardProps {
    recital: IRecital;
    onButtonClick?: (id: number) => void;
}

export const RecitalCard: FunctionComponent<IRecitalCardProps> = ({ recital, onButtonClick }) => {

    const onClick = onButtonClick ?? NavigateToView;

    return (
        <button className={styles.card} onClick={() => onClick(recital.id)}>
            <h2 className={styles.cardTitle}>{recital.title}</h2>
            <p className={styles.cardDescription}>{recital.description}</p>
        </button>
    )
};
// TODO: make onhover buttons component