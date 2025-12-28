import { FunctionComponent } from "react";

import styles from "./header.module.scss";

interface IHeaderProps {
    children: string;
}

export const Header: FunctionComponent<IHeaderProps> = ({ children }) => {
    return (
        <h1 className={styles.header}>{children}</h1>
    )
}