import React from 'react'

import { Helmet } from 'react-helmet'

import './wireframe4.css'

const Wireframe4 = (props) => {
  return (
    <div className="wireframe4-container">
      <Helmet>
        <title>exported project</title>
      </Helmet>
      <div className="wireframe4-wireframe4">
        <div className="wireframe4-frame11-sidebar">
          <span className="wireframe4-text">
            <span>Movie Reviewer</span>
          </span>
          <div className="wireframe4-list">
            <div className="wireframe4-menuitem">
              <span className="wireframe4-text02">
                <span>Discover</span>
              </span>
            </div>
            <div className="wireframe4-menuitem1">
              <img
                src="/external/search2030-afl.svg"
                alt="search2030"
                className="wireframe4-search"
              />
              <span className="wireframe4-text04 Smalltext">
                <span>Browse</span>
              </span>
            </div>
            <div className="wireframe4-menuitem2"></div>
            <div className="wireframe4-menuitem3">
              <div className="wireframe4-frame2610399">
                <span className="wireframe4-text06">
                  <span>Add/Edit</span>
                </span>
              </div>
            </div>
            <div className="wireframe4-menuitem4">
              <img
                src="/external/home2030-d7fq.svg"
                alt="home2030"
                className="wireframe4-home"
              />
              <span className="wireframe4-text08 Smalltext">
                <span>Add movie</span>
              </span>
            </div>
            <div className="wireframe4-menuitem5">
              <img
                src="/external/home2030-6lr.svg"
                alt="home2030"
                className="wireframe4-home1"
              />
              <span className="wireframe4-text10 Smalltext">
                <span>Add director</span>
              </span>
            </div>
            <div className="wireframe4-menuitem6">
              <img
                src="/external/home2030-w5ge.svg"
                alt="home2030"
                className="wireframe4-home2"
              />
              <span className="wireframe4-text12 Smalltext">
                <span>Edit director</span>
              </span>
            </div>
          </div>
        </div>
        <div className="wireframe4-frame03-inputfieldwithlabel">
          <span className="wireframe4-text14">
            <span>Movie name</span>
          </span>
          <div className="wireframe4-field">
            <span className="wireframe4-text16 Bodytext">
              <span>Movie name</span>
            </span>
          </div>
        </div>
        <div className="wireframe4-frame03-inputfieldwithlabel1">
          <span className="wireframe4-text18">
            <span>Release date</span>
          </span>
          <div className="wireframe4-field1">
            <span className="wireframe4-text20 Bodytext">
              <span>dd-mm-yyyy</span>
            </span>
          </div>
        </div>
        <div className="wireframe4-frame03-inputfieldwithlabel2">
          <span className="wireframe4-text22">
            <span>Director</span>
          </span>
          <div className="wireframe4-frame04-searchinput">
            <img
              src="/external/search2026-dvtv.svg"
              alt="search2026"
              className="wireframe4-search1"
            />
            <span className="wireframe4-text24 PresetsBody2">
              <span>Search</span>
            </span>
          </div>
        </div>
        <span className="wireframe4-text26">
          <span>Edit Movie</span>
        </span>
        <button className="wireframe4-frame00-primarybutton">
          <span className="wireframe4-text28 Smalltext">
            <span>Save new movie</span>
          </span>
        </button>
      </div>
    </div>
  )
}

export default Wireframe4
