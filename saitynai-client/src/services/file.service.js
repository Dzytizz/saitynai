import https from "../https-common";
import { useEffect } from "react";

class FileDataService {
  uploadImages(data) {
    //console.log(https.defaults);
    https.defaults.headers.common["Content-type"] = "multipart/form-data";
    //https.defaults.headers.common["Accept"] = "multipart/form-data";
    // console.log(https.defaults.headers.common);
    console.log(https.defaults.headers);
    return https.post("/files", data);
  }

  delete(data) {
    return https.delete(`/files${data}`);
  }
}

export default new FileDataService();
