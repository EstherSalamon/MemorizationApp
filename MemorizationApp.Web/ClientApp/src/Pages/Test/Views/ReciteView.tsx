import { FunctionComponent, useState } from "react";
import { Header } from "../../../common/UI/Header/Header";
import { TextArea } from "../../../common/UI/InputField/InputField";
import { Button } from "../../../common/UI/Button/Button";
import { IRecital } from "../../Home/HomePage";

interface IReciteViewProps {
    recital: IRecital;
    onSubmitClick: (text: string) => void;
}

export const ReciteView: FunctionComponent<IReciteViewProps> = ({ recital, onSubmitClick }) => {
    const [text, setText] = useState<string>("");

    return (
        <>
            <Header>{recital.title}</Header>
            <TextArea rows={20} placeholder="type here" value={text} onChange={e => setText(e.target.value)} />
            <Button onClick={() => onSubmitClick(text)}>Submit</Button>
        </>
    )
};
