import React, { FC } from "react";
import { Localize } from "helpers";

export const Footer: FC = () => {
    return (
        <footer className="footer">
            <div className="container">
                <span className="text-muted"><Localize id="general.copyright" /></span>
            </div>
        </footer>
    )
}