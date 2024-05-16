import React from 'react'
import ReactDOM from 'react-dom'
import {
  BrowserRouter as Router,
  Route,
  Switch,
  Redirect,
} from 'react-router-dom'

import './style.css'
import Wireframe1 from './views/wireframe1'
import Wireframe2 from './views/wireframe2'
import Wireframe3 from './views/wireframe3'
import Wireframe4 from './views/wireframe4'
import NotFound from './views/not-found'

const App = () => {
  return (
    <Router>
      <Switch>
        <Route component={Wireframe1} exact path="/" />
        <Route component={Wireframe2} exact path="/wireframe2" />
        <Route component={Wireframe3} exact path="/wireframe3" />
        <Route component={Wireframe4} exact path="/wireframe4" />
        <Route component={NotFound} path="**" />
        <Redirect to="**" />
      </Switch>
    </Router>
  )
}

ReactDOM.render(<App />, document.getElementById('app'))
