import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom'; // Import useParams hook
import { Helmet } from 'react-helmet'

import '../components/app/App.css'
import SideBar from "./sideBar";
import ReviewItem from "./ReviewItem";

const GetFilm = (props) => {
  return (
    <div className="page">
      <Helmet>
        <title>Look up movie</title>
      </Helmet>
      <SideBar />
      <div className="mainContainer">
          <GetFilmFromID></GetFilmFromID>
      </div>
    </div>
  )
}

function GetFilmFromID() {
    const [data, setFilm] = useState(null);
    const { id } = useParams();

    useEffect(() => {
        const fetchFilmId = async () => {
            try {
                const response = await fetch(`https://localhost:7281/api/Film/${id}`);
                if (!response.ok) {
                    throw new Error('Network response was not ok');
                }
                const data = await response.json();
                setFilm(data);
            } catch (error) {
                console.error('Error fetching film:', error);
            }
        };

        fetchFilmId();
    }, [id]); // Re-run effect whenever id changes

    // Render film details
    return (
        <div>
            {data && (
                <>
                    <h1>{data.title}</h1>
                    <div className="descriptionTextContainerContainer">
                        <div className="descriptionTextContainer">
                            <div className="descriptionText">Year of release: </div>
                            <div>{data.year}</div>
                        </div>
                        <div className="descriptionTextContainer">
                            <div className="descriptionText">Directed by: </div>
                            <div>{data.director?.name}</div>
                        </div>
                        <div className="descriptionTextContainer">
                            <div className="descriptionText">Land of recording: </div>
                            <div>{data.landRecorded}</div>
                        </div>
                    </div>
                    <hr className="hrBar"/>
                    <div>
                        <div className="SecondaryText">Add Review</div>
                        <MyForm></MyForm>
                        <div className="space"/>
                        <div className="TitleText">Reviews</div>
                        <div className="reviewAddContainer">
                            {data.filmReviews.map((review, index) => (
                                <div key={review.id}>
                                    <ReviewItem review={review}/>
                                    {index < data.filmReviews.length - 1 && <hr className="reviewSeparator"/>}
                                </div>
                            ))}
                        </div>

                    </div>

                </>
            )}
        </div>
    );
}

function MyForm() {
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
                // Handle success if needed
            })
            .catch(error => {
                console.error('Error sending review:', error);
            });
    };

    return (
        <div className="reviewAddContainer">
            <form onSubmit={handleSubmit}>
                <label>
                    Username:
                    <input type="text" value={username} onChange={handleUsernameChange}/>
                </label>
                <label>
                    Rating (1-5):
                    <select value={selectValue} onChange={handleSelectChange}>
                        <option value="">1</option>
                        {[2, 3, 4, 5].map(value => (
                            <option key={value} value={value}>{value}</option>
                        ))}
                    </select>
                </label>
    
                <label>
                    <textarea className="reviewAddTextContainer" value={textInput} onChange={handleTextChange}/>
                </label>
                <br/>
    
                <br/>
                <button type="submit" className="submitButton">Submit review</button>
            </form>
        </div>
    );
}


export default GetFilm
