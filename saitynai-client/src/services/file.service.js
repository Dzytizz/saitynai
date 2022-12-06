import https from "../https-common";

class FileDataService {
  uploadImages(data) {
    https.defaults.headers.common["Content-type"] = "multipart/form-data";
    console.log(https.defaults.headers.common);
    return https.post("/files", data);
  }

  delete(data) {
    return https.delete(`/files${data}`);
  }
}

export default new FileDataService();
