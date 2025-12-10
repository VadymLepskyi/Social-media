import ProfileInfo from "../components/profileInfo"
import CreateNewPost from "../components/createNewPost"
import PageContainer from "../components/pageContainer";
import PostFeed from "../components/postFeed"
import usePost from "../hooks/useGetPost";
import { useParams} from "react-router-dom"

export default function Profile()
{  
    const {userId}=useParams<{ userId: string }>();
    const { post, error } = usePost(userId);
    return(
        <PageContainer title="Community News">
                <CreateNewPost/>
                <PostFeed post={post||[]} error={error} ></PostFeed>
        </PageContainer>
    );
}