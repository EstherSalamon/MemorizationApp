import { FormEvent, FunctionComponent, useState } from "react";
import { IRecital } from "../Home/HomePage";
import { RecitalStore } from "../../common/Utils/RecitalStore";
import { Header } from "../../common/UI/Header/Header";
import { Input, TextArea } from "../../common/UI/InputField/InputField";
import { Button } from "../../common/UI/Button/Button";
import { Container } from "../../common/UI/Container/Container";
import { NavigateToView } from "../../common/Utils/NavigationUtil";

import styles from "./addRecitalPage.module.scss";

export const AddRecitalPage: FunctionComponent = () => {

    const [name, setName] = useState<string>("");
    const [description, setDescription] = useState<string>("");
    const [text, setText] = useState<string>("");

    function handleFormSubmit(e: FormEvent) {
        e.preventDefault();
        const recital: IRecital = { id: 0, title: name, description, text };
        RecitalStore.addRecital(recital).then(data => NavigateToView(data.recitalId));
    }

    return (
        <Container>
            <Header>Add a recital</Header>
            <form onSubmit={handleFormSubmit} className={styles.form}>
                <Input type="text" placeholder="Name" value={name} onChange={e => setName(e.target.value)} />
                <Input type="text" placeholder="Description" value={description} onChange={e => setDescription(e.target.value)} />
                <TextArea placeholder="Go for it" value={text} onChange={(e => setText(e.target.value))} />
                <Button type="submit" onClick={handleFormSubmit}>Submit</Button>
            </form>
        </Container>
    )
}