import CreateNewPost from "../components/createNewPost"
import PageContainer from "../components/pageContainer";
import PostFeed from "../components/postFeed"
import useGetAllPosts from "../hooks/useGetAllPosts";

export default function Profile()
{  
    const { posts, error } = useGetAllPosts("CommunityPage");
    return(
        <PageContainer title="Community News">
                <CreateNewPost page="CommunityPage"/>
                <PostFeed post={posts||[]} error={error} ></PostFeed>
        </PageContainer>
    );
}