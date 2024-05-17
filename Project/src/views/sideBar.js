import React, { useState } from 'react';

import './sideBar.css'
import {Link} from "react-router-dom";

const sideBar = props => {
    const [wid, setWid] = useState(0);
    return (
        <div className="sidenav">
            <div className="descriptionContainer">Discover</div>
            <Link className="button sideBarButton" to={`/`}>
                <div className="descriptionTextSideBar">Browse Movies</div>
            </Link>
            <div className="descriptionContainer">Add/Edit</div>
            <Link className="button sideBarButton" to={`/addMovie`}>
                <div className="descriptionTextSideBar">Add Movie</div>
            </Link>
            <Link className="button sideBarButton" to={`/addDirector`}>
                <div className="descriptionTextSideBar">Add Director</div>
            </Link>
            <Link className="button sideBarButton" to={`/editDirector`}>
                <div className="descriptionTextSideBar">Edit Director</div>
            </Link>
        </div>
    )
}
export default sideBar;