import React from 'react';

function ReviewItem({ review }) {
    return (
        <div className="reviewItem">
            <div className="reviewItemHeader">
                <div className="descriptionText">
                    <div>{review.username}:</div>
                </div>
                <div className="descriptionTextContainer">
                    <div className="descriptionText">Score</div>
                    <div>{review.score}</div>
                </div>
                <div className="descriptionTextContainer">
                    <div className="descriptionText">Posted on</div>
                    <div>{new Date(review.creationDate).toLocaleDateString('en-GB')}</div>
                </div>
            </div>
            <div className="reviewItemContent">
            <div>{review.description}</div>
            </div>
        </div>
    );
}


export default ReviewItem;