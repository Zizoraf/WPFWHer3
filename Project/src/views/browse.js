import React, { useState, useEffect } from 'react';
import { Helmet } from 'react-helmet'

import '../components/app/App.css'
import FilmTabel from "../components/film/filmTabel/FilmTabel";
import SideBar from "./sideBar";

const Browse = (props) => {
  return (
    <div className="page">
      <Helmet>
        <title>Movie reviewer</title>
      </Helmet>
      <SideBar />
      <div className="mainContainer">
          <h1 className="TitleText">Search Movie</h1>
          <h2 className="SecondaryText">Movie name</h2>
          <Film></Film>
      </div>
    </div>
  )
}

function Film() {
    const [data, setFilms] = useState([]);

  useEffect(() => {
    const fetchFilms = async () => {
      try {
        const response = await fetch('https://localhost:7281/api/Film');
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
