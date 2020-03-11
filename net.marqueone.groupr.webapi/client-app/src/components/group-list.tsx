import React, { PureComponent, Fragment } from "react";
import { Group } from "types";
import { ListGroup, ListGroupItem, ListGroupItemHeading, ListGroupItemText, CardDeck, Row, Col } from "reactstrap";
import { GetLocalizedMessage } from "helpers";
import { GroupCard } from "components/group-card";

export default class GroupList extends PureComponent<{ items: Array<Group> }, {}> {

    state = {
        view: "list",
    }

    switchView = (type: string) => {
        this.setState({ view: type });
    }

    render() {
        console.log(this.props);
        const { view } = this.state;
        return (
            <Fragment>
                <div className="view-switcher">View: <i className="fas fa-list" onClick={() => this.switchView("list")}></i> | <i className="fas fa-th-large" onClick={() => this.switchView("grid")}></i></div>
                <div className="group-list">
                    {view === "list" ? this.renderAsList() : this.renderAsGrid()}
                </div>
            </Fragment>
        );
    }

    renderAsList() {
        const { items } = this.props;
        return (<ListGroup>
            {items.map(item => <ListGroupItem key={item.id}>
                <ListGroupItemHeading>{item.name}</ListGroupItemHeading>
                <ListGroupItemText>
                    {item.description ? item.description : GetLocalizedMessage("general.no-description")}
                </ListGroupItemText>
            </ListGroupItem>)}
        </ListGroup>)
    }

    renderAsGrid() {
        const { items } = this.props;
        return (<CardDeck>
            <Row>
                {items.map(item => (
                    <Col key={item.id} className="spacing" lg="4" sm="6" xs="12">
                        <GroupCard {...item} />
                    </Col>
                ))}
            </Row>
        </CardDeck>
        );
    }
}