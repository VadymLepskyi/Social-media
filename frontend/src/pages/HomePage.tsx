import PageContainer from "../components/pageContainer";
import PostFeed from "../components/postFeed";
import useGetAllPosts from "../hooks/useGetAllPosts";
export default function HomePage() {
  const { posts, error } = useGetAllPosts();
  return (
    <PageContainer title="Padel News">
      <PostFeed post={posts||[]} error={error}></PostFeed>
    </PageContainer>
  );
}
