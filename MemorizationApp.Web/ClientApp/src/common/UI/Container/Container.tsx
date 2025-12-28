import { FunctionComponent, ReactNode } from "react";

import styles from "./container.module.scss";

export interface IChildrenProps {
    children: ReactNode;
}

export const Container: FunctionComponent<IChildrenProps> = ({ children }) => {
    return (
        <div className={styles.container}>
            {children}
        </div>
    )
}