import './App.css';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import Login from './pages/Login';
import Home from './pages/Home';
import Menu from './components/Menu';

function App() {
  return (
    <div className="App">
        <BrowserRouter>
          <Menu></Menu>
          <Routes>
            <Route path="/" element={<Home/>}></Route>
            <Route path="/login" element={<Login/>}></Route>
          </Routes>
        </BrowserRouter>
    </div>
  );
}

export default App;
