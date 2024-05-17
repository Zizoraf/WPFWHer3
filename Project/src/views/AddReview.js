import React, { useState } from 'react';

function AddReview({ movieId }) {
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

    const handleSubmit = async (event) => {
        event.preventDefault();

        const reviewDto = {
            score: parseInt(selectValue), // Convert selectValue to integer
            description: textInput,
            username: username
        };

        try {
            const response = await fetch(`https://localhost:7281/api/Review/${movieId}`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(reviewDto)
            });

            if (!response.ok) {
                throw new Error('Network response was not ok');
            }

            // Handle success if needed
        } catch (error) {
            console.error('Error sending review:', error);
        }
    };

    return (
        <div className="reviewAddContainer">
            <form onSubmit={handleSubmit}>
                <label className="formLabel">
                    Username:
                    <input type="text" value={username} onChange={handleUsernameChange} className="formInput" placeholder="PirateSoftware"/>
                </label>
                <label>
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
                <button type="submit" className="submitButton">Submit review</button>
            </form>
        </div>
    );
}

export default AddReview;


