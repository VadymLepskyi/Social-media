import Keycloak from "keycloak-js";

const keycloak = new Keycloak({
  url: "http://localhost:8080/",
  realm: "Padel_Realm",
  clientId: "myclient",
});

export default keycloak;
