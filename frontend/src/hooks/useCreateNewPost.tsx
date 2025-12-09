import keycloak from "../keycloak"
export default function useCreateNewPost()
{
    const createNewPost= async(message:string) => {
        try
        {
            const postData={PostContent: message}
            const res = await fetch ("http://localhost:5145/api/UserPost/createPost",{
                method:"POST",
                headers: {
                    "Content-Type": "application/json", // <-- required for JSON
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