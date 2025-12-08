import keycloak from "../keycloak"
import {useNavigate} from "react-router-dom"
export default function UseEditorProfile()
{
    const navigate= useNavigate();
    const updateProfile=async(formData:FormData)=>{try {
        const res = await fetch("http://localhost:5145/api/UserProfile/updateProfile", {
            method: "POST",
            headers: {
                Authorization: `Bearer ${keycloak.token}`, // add Keycloak token
            },
            body: formData,
        });
        if (res.ok) {
        navigate("/profile");
        }   
        if (!res.ok) throw new Error("Failed to update profile");
        console.log("Profile updated successfully");
        } catch (err) {
            console.error(err);
        }
    } 
    return({updateProfile});
}