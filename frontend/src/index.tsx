import React from 'react';
import ReactDOM from 'react-dom/client';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import './index.css';
import HomePage from './pages/HomePage';
import keycloak from './keycloak';

const root = ReactDOM.createRoot(document.getElementById('root') as HTMLElement);
keycloak.init({onLoad:"login-required"}).then(authenticated =>{
  if(authenticated)
  {
    root.render(
       <React.StrictMode>
        <App/>
       </React.StrictMode>
    );
  }
  else
  {
    keycloak.login();
  }
  }).catch(error=>console.error("Keycloak initilize error", error))

function App(){
  return(
    <BrowserRouter>
        <Routes>
          {/* <Route path="/" element={<LoginPage/>}/> */}
          <Route path="/" element={<HomePage/>}/>
        </Routes>
    </BrowserRouter>
  );
}
