import {useNavigate, useParams} from "react-router-dom"
import {useProfile} from "../hooks/useProfileInfo"

export default function ProfileInfo({ userId }: { userId?: string })
{
    const navigate= useNavigate();
    
    const {profile,error}=useProfile(userId);
    if (error) return <p>Error: {error.message}</p>;
    if (!profile) return <p>Loading...</p>;
    return(
        <div >
                <div className="bg-white p-6 rounded-lg shadow-lg border border-gray-100 flex flex-col items-center">
                    <div className="flex flex-col items-center gap-4">
                        <div className="w-24 h-24 bg-gray-500 rounded-full flex items-center justify-center border-4 border-padel-accent overflow-hidden">
                            {profile.profilePhotoUrl ? (
                            <img
                                src={`${profile.profilePhotoUrl}?t=${Date.now()}`}
                                className="w-full h-full object-cover"
                            />
                            ) : (
                            <span className="text-gray-400 text-sm">No image</span>
                            )}
                        </div>

                        <div className="flex flex-col items-center gap-1">
                            <span className="text-3xl font-extrabold text-padel-primary">{profile.userName}</span>
                            <span className="text-gray-500">{profile.city}</span>
                        </div>

                        <button
                            onClick={() => navigate("edit")}
                            className="px-4 py-2 text-sm font-semibold text-padel-accent border border-padel-accent rounded-full hover:bg-padel-accent hover:text-white transition duration-200 shadow-md"
                        >
                            Edit Profile
                        </button>
                        </div>
                </div>
                {/* A player statistic box */}
                <div className="p-4 bg-padel-light rounded-lg shadow-inner flex flex-col items-center justify-center gap-1">
                    <span className="text-2xl font-bold">{profile.skillLevel}</span>
                    <p className="text-xs text-gray-500">Skill Level</p>
                </div>

                {/* A bio box */}
                <div className="bg-white p-6 rounded-lg shadow-lg border border-gray-100">
                    <h3 className="font-bold text-xl text-padel-primary mb-4 border-b pb-2 ">About me</h3>
                    <span className="text-gray-600"> {profile.bio}</span>
                </div>

        </div>
    );

}