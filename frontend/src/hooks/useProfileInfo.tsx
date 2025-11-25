import { useEffect, useState } from "react";

export function useProfile() {
  const [profile, setProfile] = useState(null);
  const [error, setError] = useState<any>(null);

  useEffect(() => {
    async function loadProfile() {
      try {
        const response = await fetch("http://localhost:5145/api/UserProfile/getProfile");

        if (!response.ok) {
          throw new Error("Failed to fetch profile");
        }

        const data = await response.json();
        setProfile(data);
      } catch (err) {
        setError(err);
      }
    }

    loadProfile();
  }, []);

  return { profile, error };
}
