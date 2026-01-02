import { FunctionComponent, useEffect, useState } from "react";
import { useLoadRecitalById } from "../../common/Hooks/useLoadRecitalById";
import { SelectView } from "./Views/SelectView";
import { ReciteView } from "./Views/ReciteView";
import { MarkView } from "./Views/MarkView";
import { RecitalStore, ICheckTextResponse } from "../../common/Utils/RecitalStore";
import { IRecital } from "../Home/HomePage";

enum IRecitalStages {
    SELECT = "Select",
    RECITE = "Recite",
    MARK = "Mark"
}

export const TestRecitalPage: FunctionComponent = () => {
    const [view, setView] = useState<IRecitalStages>(IRecitalStages.SELECT);
    const [currentRecitalId, setCurrentRecitalId] = useState<number | null>(null);
    const [checkTextResponse, setCheckTextResponse] = useState<ICheckTextResponse | null>(null);
    const setSelectView = () => setView(IRecitalStages.SELECT);
    const [recital, setRecital] = useState<IRecital | null>(useLoadRecitalById(setSelectView));

    useEffect(() => {
        async function loadRecital() {
            if (currentRecitalId && (!recital || recital.id !== currentRecitalId)) {
                await RecitalStore.getById(currentRecitalId.toString()).then(
                    (rec) => {
                        setRecital(rec)
                        setView(IRecitalStages.RECITE)
                    }
                );
            }
        }
        loadRecital();
    }, [currentRecitalId])

    function _getComponent() {
        switch (view) {
            case IRecitalStages.SELECT:
                return <SelectView onClick={(id) => setCurrentRecitalId(id)} />;
            case IRecitalStages.RECITE:
                return <ReciteView recital={recital!} onSubmitClick={handleTestClick} />;
            case IRecitalStages.MARK:
                return <MarkView recital={recital!} response={checkTextResponse} />;
        }
    };

    async function handleTestClick(text: string) {
        const result = await RecitalStore.compareText(text, recital!.id.toString());
        if (result.success) {
            setCheckTextResponse(result.response);
            setView(IRecitalStages.MARK);
        }
    }

    return _getComponent();
};
// TODO: clear currentRecitalId / recital on reload