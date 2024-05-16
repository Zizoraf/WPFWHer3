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
import Film from "./components/film/Film";
import GetFilm from "./views/GetFilm";

const App = () => {
  return (
    <Router>
      <Switch>
        <Route component={browse} exact path="/" />
        <Route component={GetFilm} exact path="/GetFilm/:id" />
        <Route component={NotFound} path="**" />
        <Redirect to="**" />
      </Switch>
    </Router>
  )
}

ReactDOM.render(<App />, document.getElementById('app'))
