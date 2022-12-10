import https from "../https-common";

class CommentDataService {
  getAll(gameId, advertisementId) {
    return https.get(
      `/games/${gameId}/advertisements/${advertisementId}/comments`
    );
  }

  get(gameId, advertisementId, id) {
    return https.get(
      `/games/${gameId}/advertisements/${advertisementId}/comments/${id}`
    );
  }

  create(gameId, advertisementId, data) {
    return https.post(
      `/games/${gameId}/advertisements/${advertisementId}/comments`,
      data
    );
  }

  update(gameId, advertisementId, id, data) {
    return https.put(
      `/games/${gameId}/advertisements/${advertisementId}/comments/${id}`,
      data
    );
  }

  delete(gameId, advertisementId, id) {
    return https.delete(
      `/games/${gameId}/advertisements/${advertisementId}/comments/${id}`
    );
  }
}

export default new CommentDataService();
