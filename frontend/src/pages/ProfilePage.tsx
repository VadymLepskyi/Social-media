import ProfileInfo from "../components/profileInfo"
import CreateNewPost from "../components/createNewPost"
import PageContainer from "../components/pageContainer";
import PostFeed from "../components/postFeed"
import usePost from "../hooks/useGetPost";
export default function Profile()
{  const { post, error } = usePost();
    return(
            <PageContainer title="Padel News">
                <ProfileInfo/>
                <CreateNewPost/>
                <PostFeed post={post||[]} error={error}></PostFeed>
            </PageContainer>
    );
}