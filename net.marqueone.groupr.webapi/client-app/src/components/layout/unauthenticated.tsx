import React, { PureComponent, Fragment, FC } from "react";

export const Unauthenticated: FC = props => {
    return (<Fragment>
        {props.children}
    </Fragment>)
}