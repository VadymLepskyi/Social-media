import{ useNavigate } from "react-router-dom";
import padelBall from '../images/padelBall.png';
import { Link } from "react-router-dom";
import { Home, Users } from "lucide-react";

export default function Navigationar()
{
    const navigate=useNavigate();
    return(
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
                </div>
            </div>
        );
}