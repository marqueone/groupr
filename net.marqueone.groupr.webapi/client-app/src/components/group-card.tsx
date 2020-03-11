import React, { FC } from "react";
import { Card, CardImg, CardBody, CardTitle, CardText } from 'reactstrap';
import { Group } from "../types";
import { GetLocalizedMessage } from "../helpers";

export const GroupCard: FC<Group> = (props) => {
    const style = {
        height: "350px",
        marginBottom: "12px"
    }
    return (
        <Card style={style}>
            <CardImg top width="100%" src="https://via.placeholder.com/120x60" alt="Card image cap" />
            <CardBody>
                <CardTitle>{props.name}</CardTitle>
                <CardText>{props.description ? props.description : GetLocalizedMessage("general.no-description")}</CardText>
            </CardBody>
        </Card>
    )
}