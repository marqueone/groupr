import React, { FC, Fragment } from "react";
import withAuthenticatedLayout from "components/layout/authenticated";
import { Group } from "types";
import { Localize } from "helpers";
import GroupList from "components/group-list";

const Home: FC = () => {
    const groups: Array<Group> = [{ id: 1, name: "one" }, { id: 2, name: "two" }, { id: 3, name: "three" }, { id: 4, name: "four" }, { id: 5, name: "five" }, { id: 6, name: "six", description: "moooooooooo" }, { id: 7, name: "seven", description: "this is an actual description, hey look at meeee!" },]

    return (
        <div className="container main-body">

            <h1><Localize id="general.title" /></h1>
            <p><Localize id="general.description" /></p>

            <h2 className="item_title_no_image"><Localize id="general.my-groups" />
                <span className="b2t_link">
                    <button type="button" className="btn btn-primary"><span className="fas fa-plus"></span> <Localize id="general.create-group" /></button>
                </span>
            </h2>

            <GroupList items={groups} />

            <div>
                <button type="button" className="btn btn-primary"><Localize id="general.join-group" /></button>
            </div>

        </div>
    );
}

export default withAuthenticatedLayout(Home);