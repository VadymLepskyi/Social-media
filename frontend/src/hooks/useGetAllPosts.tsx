import {useEffect,useState} from "react"
import keycloak from "../keycloak"
import {UserPostProps} from "../interfaces/interfaces"
export default function useGetAllPosts()
{
    const [posts, setPosts]=useState<UserPostProps[]|null>(null);
    const [error, setError]=useState<Error|null>(null);
    useEffect(()=>{ 
        async function fetchPosts()
        {
            try
            {
                const res= await fetch("http://localhost:5145/api/UserPost/retrieveUsersPosts",{
                    headers: {
                        Authorization: `Bearer ${keycloak.token}`, // add Keycloak token
                    },

                })
                if(!res.ok)
                        throw new Error ("Failed to featch the user post")
                    const data= await res.json();
                    setPosts(data);
                }catch (err: unknown){
                    if (err instanceof Error) {
                    setError(err);
                    } else {
                    setError(new Error(String(err))); 
                    }}
        }
        fetchPosts();
    },[]);
    return {posts,error}
}