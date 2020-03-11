import React, { Fragment, ComponentType, ReactElement } from "react";
// import Navigation from "./navigation";
import { Footer } from "./footer";
import { Header } from "./header";

interface Props {
    isHomePage?: boolean;
}

const withAuthenticatedLayout = <P extends object>(Wrapped: ComponentType<P>) => (props: P & Props): ReactElement => {
    return (<Fragment>
        <Header />
        {/* <Navigation /> */}
        <div id="wrapper">
            <Wrapped {...props} />
            <Footer />
        </div>
    </Fragment>);
};

export default withAuthenticatedLayout;