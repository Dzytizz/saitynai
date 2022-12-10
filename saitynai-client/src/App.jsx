import { Routes, Route } from 'react-router-dom';
import Login from './components/Auth/Login';
import Register from './components/Auth/Register';
import { Game } from './components/Games/Game';
import { GamesList } from './components/Games/GamesList'
import { GameAdd } from './components/Games/GameAdd'
import MainNavigation from './components/MainNavigation';
// import './App.css'
import { CurrentUserProvider } from './CurrentUserContext';
import { Footer } from './components/Footer';
import { AdvertisementAdd } from './components/Advertisements/AdvertisementAdd';
import { Unauthorized } from './components/Auth/Unauthorized';
import {Advertisement} from './components/Advertisements/Advertisement';
import { AdvertisemensList } from './components/Advertisements/AdvertisementsList';
import { AdvertisementUpdate } from './components/Advertisements/AdvertisementUpdate';
import { GameUpdate } from './components/Games/GameUpdate';

import './styles.css'

function App() {
  return (

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
          <Route exact path="/games">
            <Route index element={<GamesList/>} />
            <Route path="/games/:id" element={<Game/>} />
            <Route path="/games/new" element={<GameAdd/>} />
            <Route path="/games/:id/update" element={<GameUpdate/>} />
            <Route path="/games/:gameId/advertisements/new" element={<AdvertisementAdd/>} />
            <Route path="/games/:gameId/advertisements/:id" element={<Advertisement/>} />
            <Route path="/games/:gameId/advertisements" element={<AdvertisemensList/>} />
            <Route path="/games/:gameId/advertisements/:id/update" element={<AdvertisementUpdate/>} />
            
          </Route>
          <Route path="/login" element={<Login/>} />
          <Route path="/register" element={<Register/>} />
          <Route path="/unauthorized" element={<Unauthorized/>} />
        </Routes>
        <Footer/>
      </>
    
  );
}

export default App;
