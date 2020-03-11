import React, { FC } from 'react';

import { IntlProvider } from 'react-intl';
import AppLocale from "./constants/index";
import { Group } from "types"
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import Home from "components/pages/home";
import CreateGroup from "components/pages/create-group";
import ListGroups from "components/pages/list-groups";

function App() {

  const locale = localStorage.getItem("locale") as string
  const currentLocalization = AppLocale[locale];

  return (
    <IntlProvider
      locale={locale}
      messages={currentLocalization}
    >
      <Router>
        <Switch>
          <Route path="/" exact component={Home} />
          <Route path="/create" exact component={CreateGroup} />
          <Route path="/join" exact component={ListGroups} />
        </Switch>
      </Router>
    </IntlProvider>
  );
}

export default App;

const GroupListItem: FC<Group> = ({ id, name, description }) => {
  return (<div></div>);
}