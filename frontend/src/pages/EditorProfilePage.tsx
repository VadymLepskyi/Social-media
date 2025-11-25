import UploadForm from "../components/profileUploadForm"
import UploadAvatar from "../components/profileUploadAvatar"
import {useState} from "react"
import UseEditorProfile from "../hooks/useEditorProfile"
export default function EditProfilePage()
{
    const { updateProfile } = UseEditorProfile();
    const [avatarFile, setAvatarFile]=useState<File|null>(null)
    const [avatarPreview, setAvatarPreview]=useState<string|null>(null)
    const handleImageChange=(event:React.ChangeEvent<HTMLInputElement>)=>{
    const file= event.target.files?.[0];
        if(!file) return;
        setAvatarFile(file)
        setAvatarPreview(URL.createObjectURL(file));     
  }
    const handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault(); // stop page reload
    const formData = new FormData(e.currentTarget);
    if(avatarFile)
        formData.append("avatar", avatarFile)
    formData.forEach((key,value)=>{ console.log(key,value)})
    updateProfile(formData);
};
    return(
    <div className="max-w-4xl mx-auto py-10 px-4 sm:px-6 lg:px-8">
        <h2 className="text-4xl font-extrabold text-padel-primary mb-6">Edit Your Profile</h2>
            <div className="bg-white p-8 rounded-xl shadow-2xl border border-padel-accent/30 space-y-6">
                <UploadAvatar handleImageChange={handleImageChange} avatarPreview={avatarPreview}/>
                <UploadForm  handleSubmit={handleSubmit} />
            </div>
    </div>);
}