import { FunctionComponent } from "react";
import { IRecital } from "../../../Pages/Home/HomePage";
import { RecitalCard } from "../../../Pages/Home/RecitalCard/RecitalCard";

import styles from "./recitalsList.module.scss";

interface IRecitalsListProps {
    recitals: IRecital[] | null;
    onClick?: (id: number) => void;
}

export const RecitalsList: FunctionComponent<IRecitalsListProps> = ({ recitals, onClick }) => {

    // note, not loading recitals here so can use the component for search results

    if (!recitals) {
        return <>No recitals yet. add some? with a link</>
    }

    return (
        <div className={styles.wrapper}>
            {recitals?.map(rec =>
                <div key={rec.id}>
                    <RecitalCard recital={rec} {...(onClick && { onButtonClick: onClick })} />
                </div>
            )}
        </div>
    )
};
