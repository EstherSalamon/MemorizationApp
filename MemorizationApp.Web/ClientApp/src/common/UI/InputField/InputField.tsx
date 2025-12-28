import { FunctionComponent, InputHTMLAttributes } from "react";

import styles from "./inputField.module.scss";

interface IInputProps extends InputHTMLAttributes<HTMLInputElement> { }

interface ITextAreaProps extends InputHTMLAttributes<HTMLTextAreaElement> {
    rows?: number;
}

type IInputFieldProps = IInputProps | ITextAreaProps;

export const TextArea: FunctionComponent<ITextAreaProps> = ({ rows, ...props }) => {
    return (
        <textarea className={styles.input} rows={rows ?? 10} {...props}></textarea>
    )
}

export const Input: FunctionComponent<IInputProps> = (props) => {
    return <input {...props} className={styles.input} />
}
// TODO: make 1 component with conditional rendering, fix rows prop