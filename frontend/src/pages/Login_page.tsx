import { useEffect, useState } from "react";
import keycloak from "../keycloak";

export default function LoginPage() {
  const [authenticated, setAuthenticated] = useState<boolean>(false);

  useEffect(() => {
  keycloak.init({ onLoad: "login-required" }).then((auth: any) => {
    setAuthenticated(auth);

    if (auth) {
      console.log("Token:", keycloak.token);

      fetch("http://localhost:5000", {
        headers: {
          Authorization: `Bearer ${keycloak.token}`,
        },
      })
        .then((res) => res.text())
        .then((data) => console.log("API says:", data));
    }
  });
}, []);
return(
  <div> Log in </div>
);

}



