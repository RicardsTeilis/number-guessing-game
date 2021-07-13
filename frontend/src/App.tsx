import './App.css';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import Leaderboard from './Pages/Leaderboard';
import Home from './Pages/Home';

function App() {

  return (
    <>
      <Router>
        <Switch>
          <Route exact path='/' component={Home} />
          <Route path='/leaderboard' component={Leaderboard} />
        </Switch>
      </Router>
    </>
  );
}

export default App;
