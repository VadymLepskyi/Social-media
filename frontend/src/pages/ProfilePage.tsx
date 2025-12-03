import ProfileInfo from "../components/profileInfo"
import CreateNewPost from "../components/createNewPost"
import PageContainer from "../components/pageContainer";
import PostItem from "../components/postItem"
export default function Profile()
{
    return(
            <PageContainer title="Padel News">
                <ProfileInfo/>
                <CreateNewPost/>
                <PostItem/>
            </PageContainer>
    );
}