import React, { FC } from 'react';

import { IntlProvider } from 'react-intl';
import AppLocale from "./constants/index";

import { Footer } from 'components/layout/footer';
import { Localize, GetLocalizedMessage } from 'helpers';
import { Header } from 'components/layout/header';
import GroupList from "components/group-list";
import { Group } from "types"

function App() {

  const locale = localStorage.getItem("locale") as string
  const currentLocalization = AppLocale[locale];

  const groups: Array<Group> = [{ id: 1, name: "one" }, { id: 2, name: "two" }, { id: 3, name: "three" }, { id: 4, name: "four" }, { id: 5, name: "five" }, { id: 6, name: "six", description: "moooooooooo" }, { id: 7, name: "seven", description: "this is an actual description, hey look at meeee!" },]

  return (
    <IntlProvider
      locale={locale}
      messages={currentLocalization}
    >
      <Header />
      {/* Begin page content */}
      <main role="main" className="container" style={{ marginTop: "12px", marginBottom: "12px", paddingTop: "75px" }}>
        {/* <h1 className="mt-5">Sticky footer with fixed navbar</h1>
        <p className="lead">Pin a fixed-height footer to the bottom of the viewport in desktop browsers with this custom HTML and CSS. A fixed navbar has been added with <code>padding-top: 60px;</code> on the <code>body &gt; .container</code>.</p>
        <p>Back to <a href="../sticky-footer/">the default sticky footer</a> minus the navbar.</p> */}

        <h1>Welcome to Groupr</h1>
        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce pellentesque diam vitae auctor pellentesque. Donec eu sapien non diam pulvinar condimentum a et ipsum. Aenean turpis libero, pulvinar at sem ac, cursus dignissim leo. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Sed id sollicitudin justo, vel tincidunt nulla. Duis tristique sodales viverra. Sed ut felis at neque dignissim sagittis. Sed sed faucibus ligula, eget luctus quam. Maecenas vitae posuere purus. Nulla in egestas dolor. Sed nisl arcu, congue vel nisl nec, blandit facilisis metus.</p>

        <h2 className="item_title_no_image">My Groups<span className="b2t_link">Create New Group</span></h2>

        <GroupList items={groups} />       

        <div>Join Group</div>

      </main>
      <Footer />
    </IntlProvider>
  );
}

export default App;

const GroupListItem: FC<Group> = ({ id, name, description }) => {
  return (<div></div>);
}