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
import Wireframe2 from './views/wireframe2'
import Wireframe3 from './views/wireframe3'
import Wireframe4 from './views/wireframe4'
import NotFound from './views/not-found'
import FilmTabel from "./components/film/filmTabel/FilmTabel";
import Film from "./components/film/Film";

const App = () => {
  return (
    <Router>
      <Switch>
        <Route component={browse} exact path="/" />
        <Route component={Wireframe2} exact path="/wireframe2" />
        <Route component={Wireframe3} exact path="/wireframe3" />
        <Route component={Wireframe4} exact path="/wireframe4" />
        <Route component={Film} exact path="/films" />
        <Route component={NotFound} path="**" />
        <Redirect to="**" />
      </Switch>
    </Router>
  )
}

ReactDOM.render(<App />, document.getElementById('app'))
