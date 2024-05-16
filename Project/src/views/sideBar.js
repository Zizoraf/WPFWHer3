import React, { useState } from 'react';

import './sideBar.css'

const sideBar = props => {
    const [wid, setWid] = useState(0);
    return (
        <div className="sidenav">
            <div>Discover</div>
            <a className="button sideBarButton" href="browse">Browse</a>
            <div>Add/Edit</div>
            <a className="button sideBarButton" href="addMovie">Add Movie</a>
            <a className="button sideBarButton" href="addDirector">Add Director</a>
            <a className="button sideBarButton" href="editDirector">Edit Director</a>
        </div>
    )
}
export default sideBar;