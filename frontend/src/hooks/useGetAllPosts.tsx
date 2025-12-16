import { useEffect, useState } from "react";
import keycloak from "../keycloak";
import { UserPostProps } from "../interfaces/interfaces";

type PostPage = "HomePage" | "CommunityPage";

export default function useGetAllPosts(page: PostPage) {
    const [posts, setPosts] = useState<UserPostProps[] | null>(null);
    const [error, setError] = useState<Error | null>(null);

    useEffect(() => {
        async function fetchPosts() {
            try {
                let url = "";

                if (page === "HomePage") {
                    url = "http://localhost:5145/api/UserPost/retrieveUsersPosts";
                }

                if (page === "CommunityPage") {
                    url = "http://localhost:5145/api/CommunityPost/retrieveUsersPosts";
                }

                const res = await fetch(url, {
                    headers: {
                        Authorization: `Bearer ${keycloak.token}`,
                    },
                });

                if (!res.ok) {
                    throw new Error("Failed to fetch posts");
                }

                const data = await res.json();
                setPosts(data);
            } catch (err) {
                setError(err instanceof Error ? err : new Error(String(err)));
            }
        }

        fetchPosts();
    }, [page]);

    return { posts, error };
}
