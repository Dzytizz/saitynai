import https from "../https-common";

class AdvertisementDataService {
  getAll(gameId) {
    return https.get(`/games/${gameId}/advertisements`);
  }

  get(gameId, id) {
    return https.get(`/games/${gameId}/advertisements/${id}`);
  }

  create(gameId, data) {
    return https.post(`/games/${gameId}/advertisements`, data);
  }

  update(gameId, id, data) {
    return https.put(`/games/${gameId}/advertisements/${id}`, data);
  }

  delete(gameId, id) {
    return https.delete(`/games/${gameId}/advertisements/${id}`);
  }
}

export default new AdvertisementDataService();
