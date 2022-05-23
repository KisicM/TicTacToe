import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import './App.css';
import Game from './components/Game/Game';
import HomePage from './components/HomePage/HomePage';
import LandingPage from './components/LandingPage/LandingPage';
import Lobby from './components/Lobby/Lobby';
import Ranking from './components/Ranking/Ranking';

function App() {

  return (
    <div>
      <div className={`router App-link`}>
        <Router>
            <Routes>
              <Route path="/" element={<LandingPage />} />
              <Route path="/home" element={<HomePage />} />
              <Route path="/game" element={<Game />} />
              <Route path="/lobby" element={<Lobby />} />
            </Routes>
        </Router>
      </div>
      <div className='ranking'>
        <Ranking />
      </div>
      <div>
        <footer className='col'>
          <h3 className='App-link'>
            Mihajlo Kisić Vega IT Internship Project
          </h3>
          <div className='footer'>
            <h4>GitHub:  </h4>
              <a href='https://github.com/KisicM'>
                <img src='https://img.icons8.com/color/48/000000/github.png' alt='github' />
              </a>
          </div>
        </footer>
      </div>
    </div>
  );
}

export default App;
