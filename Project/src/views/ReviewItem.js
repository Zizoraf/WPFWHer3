import React from 'react';

function ReviewItem({ review }) {
    return (
        <div className="reviewItem">
            <div className="reviewItemHeader">
                <div>Score: {review.score}</div>
                <div>Username: {review.username}</div>
                <div>Creation Date: {review.creationDate}</div>
            </div>
            <div className="reviewItemContent">
                <div>Description: {review.description}</div>
            </div>
        </div>
    );
}

export default ReviewItem;