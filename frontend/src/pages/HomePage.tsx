import PageContainer from "../components/pageContainer";
import PostFeed from "../components/postFeed";
import usePost from "../hooks/useGetPost";
export default function HomePage() {
  const { post, error } = usePost();
  return (
    <PageContainer title="Padel News">
      <PostFeed post={post||[]} error={error}></PostFeed>
    </PageContainer>
  );
}
