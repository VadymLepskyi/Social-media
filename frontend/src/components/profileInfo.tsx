import {useNavigate} from "react-router-dom"
export default function ProfileInfo()
{
    const navigate= useNavigate();
    const userName=""
    const city=""
    const skillLevel=""
    const description=""
    return(
        <div>
                <div className="bg-white p-6 rounded-lg shadow-lg border border-gray-100">
                    <div className="flex flex-col items-center ">
                        <div className="w-24 h-24 bg-gray-500 rounded-full flex items-center justify-center border-4 border-padel-accent overflow-hidden">
                            <span className="text-xl font-medium text-white">Avatar </span>
                        </div>
                        <div className="mt-4 text-3xl font-extrabold text-padel-primary">
                                {userName}
                        </div>
                         <div className="flex items-center text-gray-500 mt-1">
                                {city}
                        </div>
                        <button onClick={()=>navigate("edit")}className="mt-5 px-4 py-2 text-sm font-semibold text-padel-accent border border-padel-accent rounded-full hover:bg-padel-accent hover:text-white transition duration-200 shadow-md">
                            Edit Profile
                        </button>
                    </div>
                </div>
                {/* A player statistic box */}
                <div className="p-6 bg-white shadow-lg rounded-lg border border-gray ">
                    <h3 className="text-xl font-bold text-padel-primary mb-4 border-b pb-2 ">Player Statistics</h3>
                    <div className="p-4 bg-padel-light rounded-lg shadow-inner flex flex-col items-center justify-center">
                        <span className="text-2xl font-bold">{skillLevel}</span>
                        <p className="text-xs text-gray-500 mt-1">
                            Skill Level
                        </p>
                    </div>
                </div>
                {/* A bio box */}
                <div className="p-6 rounded-lg shadow-lg border border-gray-100">
                    <h3 className="font-bold text-xl text-padel-primary mb-4 border-b pb-2 ">About me</h3>
                    <span className="text-gara-600"> {description}</span>
                </div>

        </div>
    );

}