import {UserPostProps} from "../interfaces/interfaces"
import { Link} from "react-router-dom";
export default function PostItem({post}:{post:UserPostProps}) {
  const formattedDate = new Date(post.createdAt).toLocaleString("en-GB", {
          day: "2-digit",
          month: "short",
          year: "numeric",
          hour: "2-digit",
          minute: "2-digit",
        });
        return (
          <div key={post.postId} className="bg-white p-6 rounded-lg shadow-lg border border-gray-100">
            <div className="flex items-center mb-3">
              <div className="w-8 h-8 bg-gray-200 rounded-full mr-3"></div>
              <Link to={`/profile/${post.userId}`} className="font-semibold text-padel-primary">{post.userName}</Link>
              <p className="text-xs text-gray-500">{}</p>
              <span className="text-xs text-gray-400 ml-auto">{formattedDate}</span>
            </div>
            <p className="text-gray-700">{post.postContent}</p>
          </div>
        ); 
}
