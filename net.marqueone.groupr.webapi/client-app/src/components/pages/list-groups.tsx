import React, { FC } from "react";
import withAuthenticatedLayout from "components/layout/authenticated";
import { Localize } from "helpers";

const ListGroups: FC = () => {
    return (
        <div className="container main-body">

            <h1><Localize id="general.title" /></h1>
            <p><Localize id="general.description" /></p>
        </div>
    )
}

export default withAuthenticatedLayout(ListGroups);