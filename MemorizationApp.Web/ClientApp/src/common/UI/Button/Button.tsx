import { ButtonHTMLAttributes, FunctionComponent } from "react";

import styles from "./button.module.scss";

interface IButtonProps extends ButtonHTMLAttributes<HTMLButtonElement> { }

export const Button: FunctionComponent<IButtonProps> = ({ children, ...props }) => {
    return (
        <button className={styles.button} {...props}>{children}</button>
    )
}