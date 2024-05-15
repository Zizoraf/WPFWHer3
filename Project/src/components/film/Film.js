import React, { useState, useEffect } from 'react';
import FilmTabel from "./filmTabel/FilmTabel";

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

export default Film;
