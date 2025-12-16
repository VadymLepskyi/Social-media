import PostItem from "./postItem";
import {PostFeedProps} from "../interfaces/interfaces"

export default function PostFeed({ post, error }:PostFeedProps) 
{

  if (error) return <p>Error: {error.message}</p>;
  if (!post) return <p>Loading...</p>;
  const sortedPosts = [...post].sort(
        (a, b) => new Date(b.createdAt).getTime() - new Date(a.createdAt).getTime()
    );
  return (
    <div className="space-y-1">
      {sortedPosts.map((p) => 
        <PostItem key={p.postId} post={p}/>)}
    </div>
  );
}

