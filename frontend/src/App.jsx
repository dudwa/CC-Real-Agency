import { BrowserRouter, Routes, Route } from 'react-router-dom';
import { useState } from 'react';
import Home from './pages/Home';
import Layout from './pages/Layout';
import Forsale from './pages/Forsale';
import Torent from './pages/Torent';
import Newproperty from './pages/Newproperty';
import Myproperties from './pages/Myproperties';
import Faq from './pages/Faq';
import About from './pages/About';
import Login from './pages/Login';
import Register from './pages/Register';
import './App.css';

function App() {

  const [authenticated, setAuthenticated] = useState(false);

  return (
    <BrowserRouter>
      <Routes>
        <Route path='/' element={<Layout authenticated={authenticated} setAuthenticated={setAuthenticated} />}>
          <Route index element={<Home />} />
          <Route
            path='/forsale'
            element={<Forsale/>}
          />
          <Route
            path='/torent'
            element={<Torent/>}
          />
          <Route
            path='/newproperty'
            element={<Newproperty/>}
          />
          <Route
            path='/myproperties'
            element={<Myproperties/>}
          />
          <Route
            path='/faq'
            element={<Faq/>}
          />
          <Route
            path='/about'
            element={<About/>}
          />
          <Route
            path='/login'
            element={<Login setAuthenticated={setAuthenticated}/>}
          />
          <Route
            path='/register'
            element={<Register/>}
          />
        </Route>
      </Routes>
    </BrowserRouter>
  );
}

export default App;
