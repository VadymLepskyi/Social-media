import {useEffect,useState} from "react"
import keycloak from "../keycloak"
import {UserPostProps} from "../interfaces/interfaces"

export default function usePost()
{
    const [post,setPost]=useState<UserPostProps[]|null>(null);
    const [error, setError] = useState<Error|null>(null);
    
    useEffect(()=>{
        async function fetchPost(){
            try {
                const res= await fetch("http://localhost:5145/api/UserPost/retrievePosts",{
                    headers: {
                    Authorization: `Bearer ${keycloak.token}`, // add Keycloak token
                },
                });
                if(!res.ok)
                    throw new Error ("Failed to featch the user post")
                const data= await res.json();
                setPost(data);
            }catch (err: unknown) {
                if (err instanceof Error) {
                setError(err);
                } else {
                setError(new Error(String(err))); 
                }
            }
        }
        fetchPost();
    },[]); 

    
    return { post, error };
}