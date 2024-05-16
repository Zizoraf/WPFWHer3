import './FilmTabel.css'
import {Link} from "react-router-dom";

function FilmTabel({tableData}) {
  return (
    <div className="table-container">
      <table className="custom-table">
        <thead>
        <tr>
          <th className="leftSideTable">Movies name</th>
          <th className="rightSideTable">Average review score</th>
          <th className="alignCenter">Review</th>
          <th className="alignCenter">Edit</th>
        </tr>
        </thead>
        <tbody>
        {tableData.map((item) => {
          // Calculate average review rate
          let totalScore = 0;
          if (item.filmReviews && item.filmReviews.length > 0) {
            totalScore = item.filmReviews.reduce((acc, review) => acc + review.score, 0);
            totalScore /= item.filmReviews.length;
          }
          let totalReviews = item.filmReviews.length;

          return (
              <tr key={item.id}>
                <td>{item.title}</td>
                <td>
                  <div className="averageReviewWithStar">
                    <span>{totalScore.toFixed(1) + " (" + totalReviews + ") "}</span>
                    <img src="star.svg" alt="StarImage"/>
                  </div>
                </td>
                <td className="alignCenter">
                  <Link to={`/lookUpFilm/${item.id}`}>
                    <div className="reviewButton">Review</div>
                  </Link>
                </td>
                <td className="alignCenter">
                  <Link to={`/editFilm/${item.id}`}>
                    <div className="editButton">Edit</div>
                  </Link>
                </td>
              </tr>
          );
        })}
        </tbody>
      </table>
    </div>
  );
};

export default FilmTabel;
