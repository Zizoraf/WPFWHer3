import React from 'react'

import { Helmet } from 'react-helmet'

import './wireframe3.css'

const Wireframe3 = (props) => {
  return (
    <div className="wireframe3-container">
      <Helmet>
        <title>exported project</title>
      </Helmet>
      <div className="wireframe3-wireframe3">
        <div className="wireframe3-frame11-sidebar">
          <span className="wireframe3-text">
            <span>Movie Reviewer</span>
          </span>
          <div className="wireframe3-list">
            <div className="wireframe3-menuitem">
              <span className="wireframe3-text02">
                <span>Discover</span>
              </span>
            </div>
            <div className="wireframe3-menuitem1">
              <img
                src="/external/search2030-31ri.svg"
                alt="search2030"
                className="wireframe3-search"
              />
              <span className="wireframe3-text04 Smalltext">
                <span>Browse</span>
              </span>
            </div>
            <div className="wireframe3-menuitem2"></div>
            <div className="wireframe3-menuitem3">
              <div className="wireframe3-frame2610399">
                <span className="wireframe3-text06">
                  <span>Add/Edit</span>
                </span>
              </div>
            </div>
            <div className="wireframe3-menuitem4">
              <img
                src="/external/home2030-ukmv.svg"
                alt="home2030"
                className="wireframe3-home"
              />
              <span className="wireframe3-text08 Smalltext">
                <span>Add movie</span>
              </span>
            </div>
            <div className="wireframe3-menuitem5">
              <img
                src="/external/home2030-onw.svg"
                alt="home2030"
                className="wireframe3-home1"
              />
              <span className="wireframe3-text10 Smalltext">
                <span>Add director</span>
              </span>
            </div>
            <div className="wireframe3-menuitem6">
              <img
                src="/external/home2030-6b49.svg"
                alt="home2030"
                className="wireframe3-home2"
              />
              <span className="wireframe3-text12 Smalltext">
                <span>Edit director</span>
              </span>
            </div>
          </div>
        </div>
        <div className="wireframe3-frame03-inputfieldwithlabel">
          <span className="wireframe3-text14">
            <span>Movie name</span>
          </span>
          <div className="wireframe3-field">
            <span className="wireframe3-text16 Bodytext">
              <span>Movie name</span>
            </span>
          </div>
        </div>
        <div className="wireframe3-frame03-inputfieldwithlabel1">
          <span className="wireframe3-text18">
            <span>Release date</span>
          </span>
          <div className="wireframe3-field1">
            <span className="wireframe3-text20 Bodytext">
              <span>dd-mm-yyyy</span>
            </span>
          </div>
        </div>
        <div className="wireframe3-frame03-inputfieldwithlabel2">
          <span className="wireframe3-text22">
            <span>Director</span>
          </span>
          <div className="wireframe3-frame04-searchinput">
            <img
              src="/external/search2026-7ua.svg"
              alt="search2026"
              className="wireframe3-search1"
            />
            <span className="wireframe3-text24 PresetsBody2">
              <span>Search</span>
            </span>
          </div>
        </div>
        <span className="wireframe3-text26">
          <span>Add Movie</span>
        </span>
        <button className="wireframe3-frame00-primarybutton">
          <span className="wireframe3-text28 Smalltext">
            <span>Save new movie</span>
          </span>
        </button>
      </div>
    </div>
  )
}

export default Wireframe3
