import { FunctionComponent, InputHTMLAttributes, TextareaHTMLAttributes } from "react";

import styles from "./inputField.module.scss";

interface IFieldProps {
    fieldType: "input" | "textarea";
}

interface IInputProps extends IFieldProps, InputHTMLAttributes<HTMLInputElement> {
    fieldType: "input";
}

interface ITextFieldProps extends IFieldProps, TextareaHTMLAttributes<HTMLTextAreaElement> {
    fieldType: "textarea";
}

type IInputFieldProps = IInputProps | ITextFieldProps;

export const InputField: FunctionComponent<IInputFieldProps> = (props) => {

    return (
        props.fieldType === "input" ?
            <input className={styles.input} {...props} />
            : <textarea className={styles.input} rows={props.rows ?? 10} {...props}></textarea>
    )
}
