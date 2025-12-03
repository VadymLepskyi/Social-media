import PageContainer from "../components/pageContainer";
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
        <PageContainer title="Edit Profile">
            <UploadAvatar handleImageChange={handleImageChange} avatarPreview={avatarPreview}/>
            <UploadForm  handleSubmit={handleSubmit} />
        </PageContainer>
        );
}