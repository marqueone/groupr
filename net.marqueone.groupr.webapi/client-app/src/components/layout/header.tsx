import React, { FC } from "react";
import { Localize, GetLocalizedMessage } from "helpers";

export const Header: FC = () => {
    return (
        <header>
            {/* Fixed navbar */}
            <nav className="navbar navbar-expand-md navbar-dark fixed-top bg-dark">
                <a className="navbar-brand" href="#"><Localize id="general.name" /></a>
                <button className="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarCollapse" aria-controls="navbarCollapse" aria-expanded="false" aria-label="Toggle navigation">
                    <span className="navbar-toggler-icon" />
                </button>
                <div className="collapse navbar-collapse" id="navbarCollapse">
                    <ul className="navbar-nav mr-auto">
                        <li className="nav-item active">
                            <a className="nav-link" href="#">Home <span className="sr-only">(current)</span></a>
                        </li>
                        <li className="nav-item">
                            <a className="nav-link" href="#">Link</a>
                        </li>
                        <li className="nav-item">
                            <a className="nav-link disabled" href="#">Disabled</a>
                        </li>
                    </ul>
                    <form className="form-inline mt-2 mt-md-0">
                        <input className="form-control mr-sm-2" type="text" placeholder="Search" aria-label={GetLocalizedMessage("general.search")} />
                        <button className="btn btn-outline-success my-2 my-sm-0" type="submit"><Localize id="general.search" /></button>
                    </form>
                </div>
            </nav>
        </header>
    )
}