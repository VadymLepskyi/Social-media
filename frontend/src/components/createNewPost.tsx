import {useState} from "react"
import useCreateNewPost from "../hooks/useCreateNewPost"
type PostPage="ProfilePage"|"CommunityPage"
interface CreateNewPostProps {
    page: PostPage;
}
export default function CreateNewPost({ page }: CreateNewPostProps)
{
    
    const [message,setMessage]= useState("")
    const {createNewPost}=useCreateNewPost(page);
    const handlePost=()=>{
        createNewPost(message);
        setMessage('');
    }
    return(
        <div>
            <div className="bg-white p-6 rounded-lg shadow-lg border border-gray-100">
                    <h3 className="font-bold text-xl text-padel-primary mb-4 border-b pb-2 ">What's on your mind ?</h3>
                   <textarea id="post-input"className="w-full p-3 border border-gray-300 rounded-lg  focus:border-padel-accent focus:outline-none resize-none"
                             placeholder="Write a new post..."
                             value={message}
                             onChange={(e)=>setMessage(e.target.value)} />
                    <div className="flex justify-end mt-3">
                        <button className="px-6 py-2 bg-padel-accent text-medium text-bold text-white shadow-md border border-padel-accent rounded-md hover:bg-emerald-600 transition duration-200 "
                        onClick={() => handlePost()}
                        > Post Update</button>
                    </div>
            </div>
        </div>
    );

}