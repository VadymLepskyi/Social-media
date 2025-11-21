import EditProfilePage from "./EditorProfilePage";
import {useNavigate} from "react-router-dom"

export default function Profile()
{
    const navigate= useNavigate();
    const userName="Vadym"
    const city="Grenå"
    const skillLevel=3.5
    const description="Description"
    const post=""
    
    return(
        <div className="grid grid-cols-1">
            <div className="space-y-6">
                {/* A profile information box */}
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
                    <span className="text-gara-600"> Description</span>
                </div>
            </div>
            {/* A post box */}
            <div className="lg:col-span-2 space-y-2">
                <div className="p-6 rounded-lg shadow-lg border border-gray-100">
                    <h3 className="font-bold text-xl text-padel-primary mb-4 border-b pb-2 ">What's on your mind ?</h3>
                   <textarea id="post-input"className="w-full p-3 border border-gray-300 rounded-lg  focus:border-padel-accent focus:outline-none resize-none"
                             placeholder="Write a new post...">
                    </textarea>
                    <div className="flex justify-end mt-3">
                        <button className="px-6 py-2 bg-padel-accent text-medium text-bold text-white shadow-md border border-padel-accent rounded-md hover:bg-emerald-600 transition duration-200 "> Post Update</button>
                    </div>
                </div>
                <div className="flex border border-gray-200 text-gray-600">
                    <button className="py-2 px-4 border-b-2 border-padel-accent text-padel-accent font-semibold">
                        My Posts
                    </button>
                    {/* Potentially can be more tabs */}
                </div>
                <div className=" space-y-4">
                    {/* Posted message */}
                <div className="bg-white p-5 rounded-xl shadow-lg border border-gray-100">
                        <div className="flex items-center mb-3">
                            <div className="w-8 h-8 bg-gray-200 rounded-full mr-3"></div>
                            <span className="font-semibold text-padel-primary">Jane Doe</span>
                            <span className="text-xs text-gray-400 ml-auto">2 hours ago</span>
                        </div>
                        <p className="text-gray-700">
                            Just secured a spot for an open court this Saturday at 10 AM. Looking for 3 players, 3.0-3.5 level. Anyone free? 🎾 #PadelLife #MatchFinder
                        </p>
                    </div>

                </div>
            </div>
        </div>
    );
}