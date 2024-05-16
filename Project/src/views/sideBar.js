import React, { useState } from 'react';

import './sideBar.css'
import {Link} from "react-router-dom";

const sideBar = props => {
    const [wid, setWid] = useState(0);
    return (
        <div className="sidenav">
            <div className="descriptionContainer">Discover</div>
            <Link className="button sideBarButton" to={`/`}>
                <img src="searchIconBlack.svg" alt="SearchIcon"/>
                <div className="descriptionText">Browse</div>
            </Link>
            <div className="descriptionContainer">Add/Edit</div>
            <Link className="button sideBarButton" to={`/addMovie`}>
                <div className="descriptionText">Add Movie</div>
            </Link>
            <Link className="button sideBarButton" to={`/addDirector`}>
                <div className="descriptionText">Add Director</div>
            </Link>
            <Link className="button sideBarButton" to={`/editDirector`}>
                <div className="descriptionText">Edit Director</div>
            </Link>
        </div>
    )
}
export default sideBar;