import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom'; // Import useParams hook
import { Helmet } from 'react-helmet'

import '../components/app/App.css'
import SideBar from "./sideBar";
import ReviewItem from "./ReviewItem";
import AddReview from "./AddReview";

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
                        <AddReview></AddReview>
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

export default GetFilm
