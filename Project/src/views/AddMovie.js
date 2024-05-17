import React, { useState, useEffect } from 'react';
import { Helmet } from 'react-helmet'

import '../components/app/App.css'
import SideBar from "./sideBar";

const AddMovie = (props) => {
  return (
    <div className="page">
      <Helmet>
        <title>Look up movie</title>
      </Helmet>
      <SideBar />
      <div className="mainContainer">
          <AddMovieForm></AddMovieForm>
      </div>
    </div>
  )
}

function AddMovieForm({ onMovieAdded }) {
    const [movieData, setMovieData] = useState({
        Title: '',
        Year: '',
        LandRecorded: '',
        DirectorId: ''
    });

    const [directors, setDirectors] = useState([]);

    useEffect(() => {
        fetchDirectors();
    }, []);

    const fetchDirectors = async () => {
        try {
            const response = await fetch('https://localhost:7281/api/Director');
            if (!response.ok) {
                throw new Error('Failed to fetch directors');
            }
            const data = await response.json();
            setDirectors(data);
        } catch (error) {
            console.error('Error fetching directors:', error);
        }
    };

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
        <form onSubmit={handleSubmit} className="movieForm">
            <h1 className="TitleText">Add Movie</h1>
            <label className="formLabel">
                Movie name:
                <input type="text" name="Title" value={movieData.Title} onChange={handleInputChange}
                       className="formInput" placeholder="Movie name"/>
            </label>
            <label className="formLabel">
                Release date:
                <input type="text" name="Year" value={movieData.Year} onChange={handleInputChange} className="formInput"
                       placeholder="Year"/>
            </label>
            <label className="formLabel">
                Land recorded:
                <input type="text" name="LandRecorded" value={movieData.LandRecorded} onChange={handleInputChange}
                       className="formInput" placeholder="Netherlands"/>
            </label>
            <label className="formLabel">
                Director:
                <select name="DirectorId" value={movieData.DirectorId} onChange={handleInputChange}
                        className="formInput">
                    <option value="">Select Director</option>
                    {directors.map(director => (
                        <option key={director.id} value={director.id}>{director.name}</option>
                    ))}
                </select>
            </label>
            <button type="submit" className="submitButton">Save new movie</button>
        </form>
    );
}

export default AddMovie;

