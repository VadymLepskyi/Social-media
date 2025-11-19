import React from 'react';
import ReactDOM from 'react-dom/client';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import './index.css';
import HomePage from './pages/HomePage';
import ProfilePage from './pages/ProfilePage'
import CommunityPage from './pages/CommunityPage'
import EditProfilePage  from './pages/EditProfilePage';
import NavigationBar from './components/navigationBar';
import keycloak from './keycloak';



const root = ReactDOM.createRoot(document.getElementById('root') as HTMLElement);
keycloak.init({onLoad:"login-required"}).then(async(authenticated) =>{
  if(authenticated)
  {
    console.log("Keycloak token:", keycloak.token);
    console.log("Token expiration:", keycloak.tokenParsed?.exp);

    const token= keycloak.token
    await fetch("http://localhost:5145/api/users/sync", {
          method: "POST",
          headers: {
            "Authorization": `Bearer ${keycloak.token}`,
          },
        });

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
        <NavigationBar/>
        <Routes>
          <Route path="/" element={<HomePage/>}/>
          <Route path="/profile" element={<ProfilePage/>}/>
          <Route path="profile/edit" element={<EditProfilePage/>}/>
          <Route path="/community" element={<CommunityPage/>}/>
        </Routes>
    </BrowserRouter>
  );
}
