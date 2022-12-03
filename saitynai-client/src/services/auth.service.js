import https from "../https-common";

class AuthDataService {
  login(data) {
    return https.post("/login", data);
  }

  register(data) {
    return https.post("/register", data);
  }
}

export default new AuthDataService();
