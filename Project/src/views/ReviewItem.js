import React from 'react';

function ReviewItem({ review }) {
    return (
        <div className="reviewItem">
            <div className="reviewItemHeader">
                <div className="descriptionTextContainer">
                    <div className="descriptionText">Score: </div>
                    <div>{review.score}</div>
                </div>
                <div className="descriptionTextContainer">
                    <div className="descriptionText">Username: </div>
                    <div>{review.username}</div>
                </div>
                <div className="descriptionTextContainer">
                    <div className="descriptionText">Creation Date: </div>
                    <div>{review.creationDate}</div>
                </div>
            </div>
            <div className="reviewItemContent">
                <div>{review.description}</div>
            </div>
        </div>
    );
}


export default ReviewItem;