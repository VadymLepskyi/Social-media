import usePost from "../hooks/useGetPost";

export default function PostItem() {
  const { post, error } = usePost();

  if (error) return <p>Error: {error.message}</p>;
  if (!post) return <p>Loading...</p>;
  const sortedPosts = [...post].sort(
        (a, b) => new Date(b.createdAt).getTime() - new Date(a.createdAt).getTime()
    );
  return (
    <div>
      {sortedPosts.map((p) => {
        const formattedDate = new Date(p.createdAt).toLocaleString("en-GB", {
          day: "2-digit",
          month: "short",
          year: "numeric",
          hour: "2-digit",
          minute: "2-digit",
        });

        return (
          <div key={p.postId} className="bg-white p-5 rounded-xl shadow-lg border border-gray-100">
            <div className="flex items-center mb-3">
              <div className="w-8 h-8 bg-gray-200 rounded-full mr-3"></div>
              <span className="font-semibold text-padel-primary">{p.userName}</span>
              <span className="text-xs text-gray-400 ml-auto">{formattedDate}</span>
            </div>
            <p className="text-gray-700">{p.postContent}</p>
          </div>
        );
      })}
    </div>
  );
}
