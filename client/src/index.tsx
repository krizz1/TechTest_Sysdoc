import React from 'react';
import ReactDOM from 'react-dom';
import * as serviceWorker from './serviceWorker';
import Projects from './screens/projects'
import Actions from './screens/actions'
import { Container } from 'react-bootstrap';
import NavMain from './components/navigation/navmain';
import { BrowserRouter, Route, Switch } from 'react-router-dom';

ReactDOM.render(
  <React.StrictMode>
    <Container>
      <NavMain></NavMain>
      <BrowserRouter>
        <Switch>
            <Route path="/" component={Projects} exact />
            <Route path="/projects" component={Projects} />
            <Route path="/actions" component={Actions} />
        </Switch>
      </BrowserRouter>
    </Container>
  </React.StrictMode>,
  document.getElementById('root')
);

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
serviceWorker.unregister();
