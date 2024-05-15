import './FilmTabel.css'

function FilmTabel({tableData}) {
  return (
    <div className="table-container">
      <h1>Film tabel</h1>
      <table className="custom-table">
        <thead>
          <tr>
            <th>Id</th>
            <th>Titel</th>
            <th>Jaar</th>
          </tr>
        </thead>
        <tbody>
          {tableData.map((item) => (
              <tr key={item.id}>
                  <td>{item.id}</td>
                  <td>{item.title}</td>
                  <td>{item.year}</td>
                  <td>{item.director.name}</td>
                  <td>
                      <ul>
                          {item.filmReviews.map((review, index) => (
                              <li key={index}>
                                  <strong>{review.username}: </strong>
                                  {review.description}
                              </li>
                          ))}
                      </ul>
                  </td>
              </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default FilmTabel;
