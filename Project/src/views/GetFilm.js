// import React, { useState, useEffect } from 'react';
// import { useParams } from 'react-router-dom'; // Import useParams hook
// import { Helmet } from 'react-helmet'
//
// import '../components/app/App.css'
// import SideBar from "./sideBar";
//
// const GetFilm = (props) => {
//   return (
//     <body className="page">
//       <Helmet>
//         <title>Look up movie</title>
//       </Helmet>
//       <SideBar />
//       <div className="mainContainer">
//           <h1 className="TitleText">Search Movie</h1>
//           <h2 className="SecondaryText">Movie name</h2>
//           <GetFilmFromID></GetFilmFromID>
//       </div>
//     </body>
//   )
// }
//
// function GetFilmFromID() {
//     const [data, setFilms] = useState([]);
//     const { id } = useParams();
//
//     useEffect(() => {
//         const fetchFilm = async () => {
//             try {
//                 const response = await fetch(`http://localhost:5274/api/GetFilm/${id}`);
//                 if (!response.ok) {
//                     throw new Error('Network response was not ok');
//                 }
//                 const data = await response.json();
//                 setFilm(data); // Update state with fetched data
//             } catch (error) {
//                 console.error('Error fetching film:', error);
//             }
//         };
//
//         fetchFilm();
//     }, [id]); // Re-run effect whenever id changes
//
//     // Render film details
//     return (
//         <div>
//             {/* Render film details here */}
//         </div>
//     );
// }
//
//
// export default Browse
