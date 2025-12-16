import keycloak from "../keycloak"
type PostPage = "ProfilePage" | "CommunityPage";
export default function useCreateNewPost(page:PostPage)
{
    const createNewPost= async(message:string) => {
        try
        {
            const postData={PostContent: message}
            let url="";
            if(page==="ProfilePage")
                url="http://localhost:5145/api/UserPost/createPost"
            if(page==="CommunityPage")
                url="http://localhost:5145/api/CommunityPost/createPost"
            const res = await fetch (url,{
                method:"POST",
                headers: {
                    "Content-Type": "application/json", 
                    Authorization: `Bearer ${keycloak.token}`,
                },
                body: JSON.stringify(postData)
    
            });
             if (!res.ok) {
                console.error("Server returned an error:", res.status, res.statusText);
                const errorBody = await res.text();
                console.error("Error body:", errorBody);
                throw new Error(`Request failed: ${res.status}`);
            }

            const data = await res.json();
            console.log("Post created successfully:", data);
            return data;

        } catch (err) {
            console.error("Error in createNewPost:", err);
            return null;
        }
    };
    return { createNewPost };
}