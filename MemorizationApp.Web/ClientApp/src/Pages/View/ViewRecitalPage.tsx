import { FunctionComponent } from "react";
import { useLoadRecitalById } from "../../common/Hooks/useLoadRecitalById";
import { Header } from "../../common/UI/Header/Header";
import { Container } from "../../common/UI/Container/Container";
import { Loader } from "../../common/UI/Loader/Loader";

import styles from "./viewRecitalPage.module.scss";

export const ViewRecitalPage: FunctionComponent = () => {
    const recital = useLoadRecitalById();

    if (!recital) {
        return <Loader />;
    }

    return (
        <Container>
            <Header>{recital.title}</Header>
            <div className={styles.wrapper}>
                <h6>{recital.description}</h6>
                <p>{recital.text}</p>
            </div>
        </Container>
    );
}