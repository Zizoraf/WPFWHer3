import React from 'react'
import ReactDOM from 'react-dom'
import {
  BrowserRouter as Router,
  Route,
  Switch,
  Redirect,
} from 'react-router-dom'

import './style.css'
import browse from './views/browse'
import NotFound from './views/not-found'
import GetFilm from "./views/GetFilm";
import AddDirector from "./views/AddDirector";
import AddMovie from "./views/AddMovie";

const App = () => {
  return (
    <Router>
      <Switch>
        <Route component={browse} exact path="/" />
        <Route component={GetFilm} exact path="/GetFilm/:id" />
        <Route component={AddDirector} exact path="/AddDirector/" />
        <Route component={AddMovie} exact path="/AddMovie/" />
        <Route component={NotFound} path="**" />
        <Redirect to="**" />
      </Switch>
    </Router>
  )
}

ReactDOM.render(<App />, document.getElementById('app'))
