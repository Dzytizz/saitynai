import { Routes, Route } from 'react-router-dom';
import Login from './components/Auth/Login';
import Register from './components/Auth/Register';
import { Game } from './components/Games/Game';
import { GamesList } from './components/Games/GamesList'
import { GameAdd } from './components/Games/GameAdd'
import MainNavigation from './components/MainNavigation';
import './App.css'
import { CurrentUserProvider } from './CurrentUserContext';
import { Footer } from './components/Footer';

function App() {
  return (
    <CurrentUserProvider>
      <>
        <MainNavigation/>
        {/* <nav>
          <ul>
            <li><Link to="/">Home</Link></li>
            <li><Link to="/games">Games</Link></li>
          </ul>
        </nav> */}
        <Routes>
          <Route path ="/" element={<GamesList/>} />
          {/* <Route path="/games" element={<GamesList/>}> */}
          <Route path="/games">
            <Route index element={<GamesList/>} />
            <Route path="/games/:id" element={<Game/>} />
            <Route path="/games/new" element={<GameAdd/>} />
          </Route>
          <Route path="/login" element={<Login/>} />
          <Route path="/register" element={<Register/>} />
        </Routes>
        <Footer/>
      </>
    </CurrentUserProvider>
    
  );
}

export default App;
