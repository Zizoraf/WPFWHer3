import React, { useState, useEffect } from 'react';

import '../components/app/App.css'

function AddReview() {
    const [textInput, setTextInput] = useState('');
    const [selectValue, setSelectValue] = useState('');
    const [username, setUsername] = useState('');

    const handleTextChange = (event) => {
        setTextInput(event.target.value);
    };

    const handleSelectChange = (event) => {
        setSelectValue(event.target.value);
    };

    const handleUsernameChange = (event) => {
        setUsername(event.target.value);
    };

    const handleSubmit = (event) => {
        event.preventDefault();

        const formData = {
            textInput: textInput,
            selectValue: selectValue,
            username: username
        };

        fetch('https://localhost:7281/api/Review/Add', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(formData)
        })
            .then(response => {
                if (!response.ok) {
                    throw new Error('Network response was not ok');
                }
            })
            .catch(error => {
                console.error('Error sending review:', error);
            });
    };

    return (
        <div className="reviewAddContainer">
            <form onSubmit={handleSubmit}>
                <label className="formLabel">
                    Username:
                    <input type="text" value={username} onChange={handleUsernameChange} className="formInput" placeholder="PirateSoftware"/>
                </label>
                <label >
                    Rating:
                    <select value={selectValue} onChange={handleSelectChange} className="rating">
                        <option value="">1</option>
                        {[2, 3, 4, 5].map(value => (
                            <option key={value} value={value}>{value}</option>
                        ))}
                    </select>
                </label>
                <label>
                    <textarea className="reviewAddTextContainer" value={textInput} onChange={handleTextChange} placeholder="Write review here"/>
                </label>
                <br/>

                <br/>
                <button type="submit" className="submitButton">Submit review</button>
            </form>
        </div>
    );
}

export default AddReview;

