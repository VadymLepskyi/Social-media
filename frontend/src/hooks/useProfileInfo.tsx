import { useEffect, useState } from "react";
import keycloak from "../keycloak"
import {UseProfileInterface} from "../interfaces/interfaces"

export function useProfile() {
  const [profile, setProfile] = useState<UseProfileInterface|null>(null);
  const [error, setError] = useState<Error|null>(null);
  useEffect(() => {
    async function loadProfile() {
      try {
        const response = await fetch("http://localhost:5145/api/UserProfile/getProfile",{
           headers: {
                Authorization: `Bearer ${keycloak.token}`, // add Keycloak token
            },
        });
        if (!response.ok) {
          throw new Error("Failed to fetch profile");
        }
        const data = await response.json();
        setProfile(data);
      } catch (err: unknown) {
        if (err instanceof Error) {
          setError(err);
        } else {
          setError(new Error(String(err))); 
        }
      }
    }
    loadProfile();
  }, []);
  return { profile, error };
}
