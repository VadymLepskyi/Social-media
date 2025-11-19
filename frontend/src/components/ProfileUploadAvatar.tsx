
interface UploadAvatarProp{
    handleImageChange:(event:React.ChangeEvent<HTMLInputElement>)=>void;
    avatarPreview: string | null;
}
export default function UploadAvatar({ handleImageChange, avatarPreview }: UploadAvatarProp){

return(
            <div className="flex flex-col items-center border-b pb-6 mb-6">
                 {/* Profile Picture Section   */}
                <div className="w-32 h-32 bg-gray-200 rounded-full flex items-center justify-center border-4 border-padel-accent overflow-hidden">
                    
                    <input id="uploadInput" 
                        type="file"
                        accept="image/*"
                        style={{display:"none"}}
                        onChange={handleImageChange}
                        className="text-lg text-gray-500 "
                    />
                    {avatarPreview ? (
                            <img
                            src={avatarPreview}
                            alt="Profile Preview"
                            style={{ width: "250px", marginTop: "10px" }}
                            />
                    ):(<span className="text-gray-400 text-sm">No image</span>)}
                </div>
                    <button className="mt-4 px-4 py-2 text-sm font-semibold text-padel-primary border border-padel-primary rounded-full hover:bg-padel-primary hover:text-white transition duration-200 shadow-md "
                            onClick={()=>document.getElementById("uploadInput")?.click()} >
                        Change Photo
                    </button>
            </div>
);
}