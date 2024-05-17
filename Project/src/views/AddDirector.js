import React, { useState, useEffect } from 'react';
import { Helmet } from 'react-helmet'

import '../components/app/App.css'
import SideBar from "./sideBar";

const AddDirector = (props) => {
  return (
    <div className="page">
      <Helmet>
        <title>Look up movie</title>
      </Helmet>
      <SideBar />
        <div className="mainContainer">
            <h1 className="TitleText">Add director</h1>
            <AddDirectorForm></AddDirectorForm>
        </div>
    </div>
  )
}

function AddDirectorForm({ onDirectorAdded }) {
    const [directorName, setDirectorName] = useState('');

    const handleNameChange = (event) => {
        setDirectorName(event.target.value);
    };

    const handleSubmit = async (event) => {
        event.preventDefault();

        try {
            const response = await fetch('https://localhost:7281/api/Director', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({ Name: directorName })
            });

            if (!response.ok) {
                throw new Error('Network response was not ok');
            }

            const data = await response.json();
            console.log('Director added successfully:', data);
            if (onDirectorAdded) {
                onDirectorAdded(data);
            }
        } catch (error) {
            console.error('Error adding director:', error);
        }
    };

    return (
        <form onSubmit={handleSubmit} className="directorForm">
            <label className="formLabel">
                Director Name:
                <input type="text" value={directorName} onChange={handleNameChange} className="formInput" placeholder="Steven Spielberg"/>
            </label>
            <button type="submit" className="submitButton">Add Director</button>
        </form>
    );
}

export default AddDirector;

