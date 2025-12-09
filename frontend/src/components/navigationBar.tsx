import{ useNavigate } from "react-router-dom";
import padelBall from '../images/padelBall.png';
import { Link } from "react-router-dom";

import { Home, Users, User,LogOut  } from "lucide-react";

export default function Navigationar()
{
    const handleLogout = () => {
    // Clear local tokens
    localStorage.removeItem("accessToken");
    localStorage.removeItem("refreshToken");

    const keycloakBase = "http://localhost:8080/realms/Padel/protocol/openid-connect/logout";
    const redirectUri = encodeURIComponent("http://localhost:3000/");
    const clientId = "myclient";
    window.location.href = 
        `${keycloakBase}?client_id=${clientId}&post_logout_redirect_uri=${redirectUri}`;
};

    const navigate=useNavigate();
    return(
        <header className="bg-padel-primary shadow-lg sticky top-0 z-10">
            <div className="p-3 flex items-center bg-padel-primary justify-between">
                <div className="flex items-center">
                    <img 
                        className="mx-10 w-14 sm:w-22 lg:w-38 mr-4 cursor-pointer" 
                        src={padelBall}
                        alt="Padel Ball" 
                        onClick={()=>navigate("/")}
                    />
                    <span className="text-4xl text-white "> Padel Connect </span>
                </div>
   
                <div className="flex space-x-4">
                        <Link to="/" className="flex items-center gap-2 text-white hover:text-blue-400">
                            <Home size={24} />
                            <span>Home</span>
                        </Link>

                        <Link to="/community" className="flex items-center gap-2 text-white hover:text-blue-400">
                            <Users size={24} />
                            <span>Community</span>
                        </Link>
                         <Link to="/profile" className="flex items-center gap-2 text-white hover:text-blue-400">
                            <User  size={24} />
                            <span>Profile</span>
                        </Link>
                        <button className="flex items-center gap-2 text-white hover:text-blue-400"
                            onClick={handleLogout}>
                            <LogOut  size={24} />
                            
                        </button>
                </div>
            </div>
            </header>
        );
}