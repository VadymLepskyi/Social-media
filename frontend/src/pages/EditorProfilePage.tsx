import UploadForm from "../components/ProfileUploadForm"
import UploadAvatar from "../components/ProfileUploadAvatar"
import {useState} from "react"
export default function EditProfilePage()
{
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
    updateEditPage(formData)
};
    const updateEditPage=async(formData:FormData)=>{try {
        const res = await fetch("api/updateProfile", {
            method: "POST",
            body: formData,
        });
        if (!res.ok) throw new Error("Failed to update profile");
        console.log("Profile updated successfully");
    } catch (err) {
        console.error(err);
    }
} 
    return(
    <div className="max-w-4xl mx-auto py-10 px-4 sm:px-6 lg:px-8">
        <h2 className="text-4xl font-extrabold text-padel-primary mb-6">Edit Your Profile</h2>
            <div className="bg-white p-8 rounded-xl shadow-2xl border border-padel-accent/30 space-y-6">
                <UploadAvatar handleImageChange={handleImageChange} avatarPreview={avatarPreview}/>
                <UploadForm  handleSubmit={handleSubmit} />
            </div>
    </div>);
}