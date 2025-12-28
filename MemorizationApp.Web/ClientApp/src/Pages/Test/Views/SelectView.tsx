import { FunctionComponent } from "react";
import { useGetAllRecitals } from "../../../common/Hooks/useGetAllRecitals";
import { Header } from "../../../common/UI/Header/Header";
import { RecitalsList } from "../../../common/Components/RecitalsList/RecitalsList";

interface ISelectViewProps {
    onClick: (id: number) => void;
}

export const SelectView: FunctionComponent<ISelectViewProps> = ({ onClick }) => {

    const recitals = useGetAllRecitals();

    return (
        <>
            <Header>Select recital to test your knowledge thereof</Header>
            <RecitalsList recitals={recitals} onClick={onClick} />
        </>
    )
};
