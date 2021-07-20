import './App.css';
import { Router, Route, Switch } from 'react-router-dom';
import History from './History';
import Home from './Pages/Home';
import Game from './Pages/Game';
import Leaderboard from './Pages/Leaderboard';
import axios from 'axios';
import { useEffect, useState, createContext } from 'react';

export const GameContext = createContext();

window.onbeforeunload = function () {
  localStorage.clear();
}

function App() {
  const [inputValue, setInputValue] = useState('');
  const [player, setPlayer] = useState();
  const [game, setGame] = useState();

  useEffect(() => {
    axios.get('http://localhost:5000/startSession')
  }, [])

  return (
    <>
      <GameContext.Provider value={{ inputValue, setInputValue, player, setPlayer, game, setGame }}>
        <Router history={History}>
          <Switch>
            <Route exact path='/' component={Home} />
            <Route exact path='/game' component={Game} />
            <Route path='/leaderboard' component={Leaderboard} />
          </Switch>
        </Router>
      </GameContext.Provider>
    </>
  );
}

export default App;
