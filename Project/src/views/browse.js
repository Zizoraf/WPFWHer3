import React, { useState, useEffect } from 'react';
import { Helmet } from 'react-helmet'

import './browse.css'
import FilmTabel from "../components/film/filmTabel/FilmTabel";
import SideBar from "./sideBar";

const Browse = (props) => {
  return (
    <body className="page">
      <Helmet>
        <title>Movie reviewer</title>
      </Helmet>
      <SideBar />
      <div className="mainContainer">
          <div className="TitleText">Search Movie</div>
          <div>Movie name</div>
          <Film></Film>
      </div>
    </body>
  )
}

function Film() {
    const [data, setFilms] = useState([]);

  useEffect(() => {
    const fetchFilms = async () => {
      try {
        const response = await fetch('http://localhost:5274/api/Film');
        if (!response.ok) {
          throw new Error('Network response was not ok');
        }
        const data = await response.json();
        setFilms(data); // Update state with fetched data
      } catch (error) {
        console.error('Error fetching films:', error);
      }
    };

    fetchFilms();
  }, []);


  return (
      <>
        <FilmTabel tableData={data}/>
      </>
  );
}

export default Browse
