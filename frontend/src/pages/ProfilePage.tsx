import ProfileInfo from "../components/profileInfo"
import CreateNewPost from "../components/createNewPost"
import PostItem from "../components/postItem"
export default function Profile()
{
    return(
        <div className="grid grid-cols-1">
            <div className="space-y-6">
                <ProfileInfo/>
            </div>
            <div className="lg:col-span-2 space-y-2">
                <CreateNewPost/>
                <div className=" space-y-4">
                <PostItem/>
                </div>
            </div>
        </div>
    );
}