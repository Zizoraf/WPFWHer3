import React, { useState, useEffect } from 'react';
import { Helmet } from 'react-helmet'

import '../components/app/App.css'
import SideBar from "./sideBar";

const AddMovie = (props) => {
  return (
    <body className="page">
      <Helmet>
        <title>Look up movie</title>
      </Helmet>
      <SideBar />
      <div className="mainContainer">
          <AddMovieForm></AddMovieForm>
      </div>
    </body>
  )
}



function AddMovieForm({ onMovieAdded }) {
    const [movieData, setMovieData] = useState({
        Title: '',
        Year: '',
        LandRecorded: '',
        DirectorId: '' // Adding DirectorId field to the state
    });

    const handleInputChange = (event) => {
        const { name, value } = event.target;
        setMovieData({ ...movieData, [name]: value });
    };

    const handleSubmit = async (event) => {
        event.preventDefault();

        try {
            const response = await fetch(`https://localhost:7281/api/Film/${movieData.DirectorId}`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({
                    Title: movieData.Title,
                    Year: movieData.Year,
                    LandRecorded: movieData.LandRecorded
                })
            });

            if (!response.ok) {
                throw new Error('Network response was not ok');
            }

            const data = await response.json();
            console.log('Movie added successfully:', data);
            if (onMovieAdded) {
                onMovieAdded(data);
            }
        } catch (error) {
            console.error('Error adding movie:', error);
        }
    };

    return (
        <form onSubmit={handleSubmit}>
            <label>
                Title:
                <input type="text" name="Title" value={movieData.Title} onChange={handleInputChange} />
            </label>
            <label>
                Year:
                <input type="number" name="Year" value={movieData.Year} onChange={handleInputChange} />
            </label>
            <label>
                Land Recorded:
                <input type="text" name="LandRecorded" value={movieData.LandRecorded} onChange={handleInputChange} />
            </label>
            <label>
                Director ID:
                <input type="text" name="DirectorId" value={movieData.DirectorId} onChange={handleInputChange} />
            </label>
            <button type="submit">Add Movie</button>
        </form>
    );
}

export default AddMovie;
