import { useEffect, useState } from "react";
import keycloak from "../keycloak"
import {UseProfileProps} from "../interfaces/interfaces"

export function useProfile(userId?: string) {
  const [profile, setProfile] = useState<UseProfileProps | null>(null);
  const [error, setError] = useState<Error | null>(null);
  useEffect(() => {
    const url = userId 
      ? `http://localhost:5145/api/UserProfile/${userId}`
      : "http://localhost:5145/api/UserProfile/me";

    async function loadProfile() {
      try {
        const response = await fetch(url, {
          headers: { Authorization: `Bearer ${keycloak.token}` },
        });
        if (!response.ok) throw new Error("Failed to fetch profile");
        setProfile(await response.json());
      } catch (err: unknown) {
        setError(err instanceof Error ? err : new Error(String(err)));
      }
    }

    loadProfile();
  }, [userId]);
  return { profile, error };
}


