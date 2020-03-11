import React, { FC } from "react";
import { IconProps } from "../types";
import { classes } from "../helpers";

export const IconButton: FC<IconProps> = ({ size, width, color, outline, icon, circle, children, onClick }) => {
    return (<span
        className={classes("btn", [size, width, color ? `btn-${color}` : "btn-default", outline && "btn-outline", circle && "btn-circle"])}
        onClick={onClick}
    >
        <i className={icon}></i>{circle ? "" : children}
    </span>);
}