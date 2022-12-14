import https from "../https-common";

class GameDataService {
  getAll() {
    return https.get("/games");
  }

  get(id) {
    return https.get(`/games/${id}`);
  }

  create(data) {
    console.log(https.defaults.headers);
    return https.post("/games", data);
  }

  update(id, data) {
    return https.put(`/games/${id}`, data);
  }

  delete(id) {
    return https.delete(`/games/${id}`);
  }
}

export default new GameDataService();
